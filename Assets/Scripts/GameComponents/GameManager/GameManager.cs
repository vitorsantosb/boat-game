using System;
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
    public GameObject[] buttons = new GameObject[2];

    [Header("GAME COMPONENTS")]
    public GameObject player;
    private bool isReady;
    private int waveCount;
    [Header("ARRAYS FOR THE GAME")]
    public GameObject[] objectsDontDestroy = new GameObject[3];
    public GameObject[] uiObjects = new GameObject[2];
    public List<GameObject> enemySpawn = new List<GameObject>();

    [Header("Timers")]
    private float timeToStart;
    public Text CounteToInicialize;

    [Header("TimerInGame")]
    private float timer;
    public Text counter;


    void Awake()
    {
        SetStateGame(STATE_GAME.INICIALIZING);
        this.timeToStart = 5;
        this.timer = 3;
        this.isReady = false;
    }
    public void Inicialize()
    {
        if (GetStateGame() == STATE_GAME.INICIALIZING)
        {
            this.isReady = startGameButton.GetComponent<UserButton>().GetReady();

        }
        CountToInicialize();
    }


    public void InicializeGame()
    {
        Debug.Log("Procurando jogador...");
        if (GetStateGame() == STATE_GAME.WAITING_TO_START)
        {
            uiObjects[0].SetActive(false);
        }
    }
    private bool search;
    public void FindPlayer()
    {
        if (search)
        {
            if (player != null)
            {
                this.player = GameObject.FindGameObjectWithTag("Player");
                Debug.Log("[+] - Player adicionado a manager - " + "object name: " + player.gameObject.name + "Hora: " + DateTime.Now);
                search = false;
                return;

            }
        }
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
    #region Timers
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

                SetStateGame(STATE_GAME.WAITING_TO_START);

                InicializeGame();
                search = true;
            }
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
        FindPlayer();
    }
}