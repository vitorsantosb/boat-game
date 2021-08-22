using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class GameManager : EnumManager
{
    [Header("UI-COMPONENTS")]

    public Button startGameButton;


    [Header("GAME COMPONENTS")]
    public GameObject player;
    public GameObject[] objectsDontDestroy = new GameObject[1];
    private bool isReady;
    private int waveCount;


    [Header("Timers")]
    private float timeToStart;
    public Text CounteToInicialize;

    void Awake()
    {
        SetStateGame(STATE_GAME.INICIALIZING);
        timeToStart = 15;
        isReady = false;
    }
    public void InicializeGame()
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
            }
        }
    }
    public void ChangeScene(string param)
    {
        if (GetStateGame() == STATE_GAME.CHANGE_SCENE)
        {
            SceneManager.LoadSceneAsync(param);
        }
    }
    public void FindPlayer()
    {
        this.player = GameObject.FindGameObjectWithTag("Player");

    }
    void Update()
    {
        InicializeGame();
    }
}