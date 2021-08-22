using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class GameManager : EnumManager
{
    [Header("UI COMPONENTS")]

    public Button startGameButton;
    


    [Header("GAME COMPONENTS")]
    public GameObject player;
    private bool isReady;
    private int waveCount;
    [Header("ARRAYS FOR THE GAME")]
    public GameObject[] objectsDontDestroy = new GameObject[1];
    public GameObject[] uiObjects = new GameObject[2];


    [Header("Timers")]
    private float timeToStart;
    public Text CounteToInicialize;

    void Awake()
    {
        SetStateGame(STATE_GAME.INICIALIZING);
        timeToStart = 5;
        isReady = false;
    }
    public void Inicialize()
    {
        if (GetStateGame() == STATE_GAME.INICIALIZING)
        {
            this.isReady = startGameButton.GetComponent<UserButton>().GetReady();

        }
        CountToInicialize();
    }
    public void CountToInicialize()
    {
        if (isReady)
        {
            this.timeToStart -= Time.deltaTime;
            this.CounteToInicialize.text = timeToStart.ToString("0");

            if (timeToStart <= 0)
            {
                isReady = false;
                SetStateGame(STATE_GAME.CHANGE_SCENE);

                DontDestroyOnLoad(objectsDontDestroy[0]);
                DontDestroyOnLoad(objectsDontDestroy[1]);

                ChangeScene("Cenadojogo");

                FindPlayer();

                SetStateGame(STATE_GAME.WAITING_TO_START);
                InicializeGame();
            }
        }
    }

    public void InicializeGame()
    {
        if (GetStateGame() == STATE_GAME.WAITING_TO_START)
        {
            uiObjects[2].SetActive(false);
            uiObjects[3].SetActive(false);

            for (int i = 0; i <= 2; i++)
            {
                uiObjects[i].SetActive(true);
                return;
            }

        }
    }
    public void FindPlayer()
    {
        this.player = GameObject.FindGameObjectWithTag("Player");
    }
    
    public void startGame()
    {

    }

    #region Game_paused

    public void GameIsPaused(bool isPaused)
    {
        if (isPaused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    #endregion

    #region SceneManager
    public void ChangeScene(string param)
    {
        if (GetStateGame() == STATE_GAME.CHANGE_SCENE)
        {
            SceneManager.LoadSceneAsync(param);

        }
    }
    #endregion
    void Update()
    {
        Inicialize();
    }
}