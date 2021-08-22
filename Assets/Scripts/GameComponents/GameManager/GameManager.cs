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
    private bool isReady;
    private int waveCount;


    [Header("Timers")]
    private float timeToStart;
    public Text CounteToInicialize;

    void Awake()
    {
        SetStateGame(STATE_GAME.INICIALIZING);
        timeToStart = 5;

    }
    public void InicializeGame()
    {

    }
    public void CountToInicialize(){
        if(isReady){
            timeToStart = Time.deltaTime;
            CounteToInicialize.text = timeToStart.ToString("0");
            if(timeToStart <= 0){
                isReady = false;
            }
            ChangeScene("Cena do jogo");
        }
    }
    public void ChangeScene(string param){
        SceneManager.LoadScene(param);
    }
}