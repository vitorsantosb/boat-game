using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StartButton : MonoBehaviour
{

    [SerializeField] private bool startGame;
    public Text buttonText;

    public void StartGame(){
        startGame = !startGame;
        buttonText.text = startGame ? "STARTING" : "START";
    }
    
}
