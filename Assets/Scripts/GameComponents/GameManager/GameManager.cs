using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GameManager : EnumManager
{
    [Header("Game components")]
    public Text[] ui_Text = new Text[1];
    public Text counter;
    public GameObject player , enemyPrefab;
    public GameObject initial_interface;
    public GameObject[] buttons = new GameObject[1];

    public static GameObject scoreUI;
    private static float scoreMultiply;

    [Header("Timers vars")]
    private bool startGame;
    private float timerToInit;


    [Header("Spawn Config")]
    private int spawnCount;

    private float unitySpawnTimer;
    public Transform spawnHierarchy;
    [SerializeField] private List<GameObject> spawnTransform = new List<GameObject>();

    [Header("canvas")] 
    public GameObject canvasUI;
    
    private float countDown;
    private float countAux;
    private int enemyCount;

    private static GameObject interfaceGameOver;
    
    private static GameObject[] childres = new GameObject[2];
    public GameObject[] insertInChild = new GameObject[2];
    
    public GameObject ui_Ref;
    public static GameObject ui_REF;
    public static GameObject InterfaceGaymeOver => interfaceGameOver;

    [Header("Kraken Config")] 
    public GameObject tentacleSpawnHierarchy;
    
    public List<Transform> tentacleSpawn = new List<Transform>();
    public GameObject tentacleClone;
    void Awake()
    {
        //spawn vars
        this.countDown = 2.5f;
        this.spawnCount = 5;
        this.unitySpawnTimer = 2.5f; //1.2

        foreach (Transform child in spawnHierarchy.transform)
        {
            spawnTransform.Add(child.gameObject);
        }

        foreach (Transform krackChild in tentacleSpawnHierarchy.transform)
        {
            tentacleSpawn.Add(krackChild);
        }
        
        //Timer vars
        this.init_game = false;
        this.timerToInit = 3;
        
        //Find Objects
        player = GameObject.FindWithTag("Player");
        interfaceGameOver = GameObject.FindWithTag("Interface");
        interfaceGameOver.SetActive(false);
        
        
        //Score vars
        scoreMultiply = 1.1f;
        scoreUI = GameObject.FindWithTag("Score");
        
        //search interfaces
        childres[0] = insertInChild[0];
        childres[1] = insertInChild[1];

        ui_REF = ui_Ref;
    }
    public void InicializeGame()
    {
        //ESTADO ATUAL DO JOGO
        if (GetStateGame() == STATE_GAME.INICIALIZING)
        {
            // VERIFICO SE O PLAYER != NULO
            if (player != null)
            {
                init_game = true;
                ui_Text[0].text = SceneController.GetUserName();
                SetStateGame(STATE_GAME.READY_TO_START);
            }
        }
    }
    
    #region Timers
    public void CounteToInicialize()
    {
        if (GetStateGame() == STATE_GAME.READY_TO_START)
        {
            if (init_game)
            {
                timerToInit -= Time.deltaTime;
                counter.text = timerToInit.ToString("0");
                if (timerToInit <= 0)
                {
                    init_game = false;
                    Inicialize();
                }

            }
        }
    }
    void Countdown()
    {
        if (GetStateGame() == STATE_GAME.WAITING)
        {
            countDown -= Time.deltaTime;
            if (countDown <= 0)
            {
                SetStateGame(STATE_GAME.SPAWNING);

                StartCoroutine(CreateUnitys(unitySpawnTimer));
                countDown = Random.Range(.8f, countAux);
                if (turn_count >= 2)
                {
                    StartCoroutine(SpawnTentacle(3));
                }
            }
        }
    }

    public float turn_timer = 60f;
    private int turn_count;
    private bool turnOn = false;
    
    
    private void TurnController()
    {
        if (turnOn)
        {
            turn_timer -= Time.deltaTime;
           // Debug.Log(turn_timer); 
           
           
           if (turn_timer <= 0)
            {
                turn_count++;
                ui_Text[1].text = turn_count.ToString("0");
                
                
                
                unitySpawnTimer = unitySpawnTimer - 0.2f;
                if(unitySpawnTimer <= .50f)
                {
                    unitySpawnTimer = .50f;
                }

                switch (turn_count)
                {
                    case 10:
                    {
                        UpdateScoreMultiply(0.2f);
                        break;
                    }
                    case 15:
                    {
                        UpdateScoreMultiply(0.4f);
                        break;
                    }
                    case 20:
                    {
                        UpdateScoreMultiply(0.8f);
                        break;
                    }
                }
                turn_timer = 10f;
            }
            
        }
    }


    #endregion
    #region Button
    [SerializeField] private bool init_game;
    public Text buttonText;

    public void StartGame()
    {
        init_game = !init_game;
        buttonText.text = init_game ? "STARTING" : "START";

        SetStateGame(STATE_GAME.INICIALIZING);

        InicializeGame();
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ReturnToMenu()
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void RestartGame()
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
    
    #endregion
    #region IN GAME REGION
    /*
        Controlador do jogo
    */
    public void Inicialize()
    {
        initial_interface.SetActive(false);
        SetStateGame(STATE_GAME.INGAME);
        
        SetStateGame(STATE_GAME.SPAWNING);
        turnOn = true;
        StartCoroutine(CreateUnitys(.86f));
    }
    #endregion

    #region SPAWN UNITS
    IEnumerator CreateUnitys(float delay)
    {
        if (GetStateGame() == STATE_GAME.SPAWNING)
        {
            for (int i = 0; i < spawnCount; i++)
            {
                GameObject obj = Instantiate(enemyPrefab,
                   spawnTransform[Random.Range(i, spawnTransform.Count - 1)].transform.position,
                   spawnTransform[Random.Range(i, spawnTransform.Count - 1)].transform.rotation);
                
                
                //reseta a gravidade dos inimigos, para evitar o acumulo da velocidade dos barcos
                obj.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, Random.Range(-.5f, 0.5f));
                obj.GetComponent<Rigidbody2D>().gravityScale = .05f + Random.Range(0f, .2f);
                obj.GetComponent<Movement2D>().SetSpeed(Random.Range(4f, 10f));
                obj.GetComponent<EnemyBoat>().SetSteerAmplitude(Random.Range(1, 10));
                
                enemyCount++;
                yield return new WaitForSeconds(delay);
            }
            SetStateGame(STATE_GAME.WAITING);
        }
    } 
    
    #endregion

    #region Interface calling
    
    public static IEnumerator FinishGame(float time, GameObject gameOverUI)
    {

        yield return new WaitForSeconds(time);
        gameOverUI.SetActive(true);
        ChangeChildrenPosition(childres);
    }
    public void SetSceneToGo(string param) => SceneManager.LoadSceneAsync(param);


    #endregion

    #region ScoreRegister

    public void UpdateScoreMultiply(float increment) => scoreMultiply += increment;

    public static float result = 0;
    public static IEnumerator Score(float points)
    {

        
        if (scoreMultiply >= 2.5f)
        {
            scoreMultiply = 2.5f;
        }
        result += points * scoreMultiply;


        yield return new WaitForSecondsRealtime(.1f);
        
        scoreUI.gameObject.GetComponent<Text>().text = result.ToString();
    }

    #endregion
    #region Update
    void Update()
    {
        Countdown();
        CounteToInicialize();
        TurnController();
    }
    #endregion

   
    
    public void QuitGame()
    {
        Application.Quit();
    }

    public static void EnableOrDisableGameObject(bool param, GameObject obj) => obj.SetActive(param);

    //public Vector2 offset;
    
    public static void ChangeChildrenPosition(GameObject[] child)
    {
        print(childres[0] + " " + childres[1] + " " + childres.Length);
        child[0].transform.GetChild(3).SetParent(child[1].transform);
        //child[1].transform.GetChild(1).position = new Vector2(child[1].transform.position.x - 400, child[1].transform.position.y - 212);
        Transform rectTransformchild = child[1].transform.GetChild(1);

        
        rectTransformchild.position = new Vector2(ui_REF.transform.position.x, ui_REF.transform.position.y);
    }

   
    public IEnumerator SpawnTentacle(float delay)
    {
        if (GetStateGame() == STATE_GAME.SPAWNING)
        {
            for (int index = 0; index < tentacleSpawn.Count; index++)
            {
                GameObject obj = Instantiate(tentacleClone,
                    new Vector2(tentacleSpawn[Random.Range(index, tentacleSpawn.Count - 1)].transform.position.x,
                        tentacleSpawn[Random.Range(index, tentacleSpawn.Count - 1)].transform.position.y),
                    Quaternion.identity);

                yield return new WaitForSecondsRealtime(delay);
                Destroy(obj, 12);

            }
        }

    }
    
    
}