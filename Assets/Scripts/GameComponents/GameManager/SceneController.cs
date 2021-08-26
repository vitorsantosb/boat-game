using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [Header("Interface")]
    public Text counter;
    private float counterTimer;
    public GameObject buttonToChangeScene;
    
    [Header("Butão")]
    [SerializeField] private bool isReady_;
    public Text buttonText;
    public InputField inputName;
    [SerializeField] private static string userName;


    void Awake()
    {
        this.counterTimer = 5;
        this.isReady_ = false;
    }

    public void SetSceneToGo(string param) => SceneManager.LoadSceneAsync(param);

    public void SetSceneToGo(int param) => SceneManager.LoadSceneAsync(param);
    
    #region Timers
    public void TimeToStart()
    {
        if (isReady_)
        {
            counterTimer -= Time.deltaTime;
            counter.text = counterTimer.ToString("0");
            if (counterTimer <= 0)
            {
                isReady_ = false;
                buttonToChangeScene.SetActive(true);
            }
        }
    }
    #endregion
    #region Player Register
    public void IsReady()
    {
        isReady_ = !isReady_;
        buttonText.text = isReady_ ? "READY" : "UNREADY";
        CreateUser();
    }
    public void CreateUser()
    {
        if (isReady_)
        {
            userName = inputName.text;
            Debug.Log("[+] CREATE USER - " + userName + " | " + DateTime.Now);
        }
        else
        {
            Debug.Log("[-] DELETE USER - " + userName + " | " + DateTime.Now);
            userName = null;
        }
        Debug.Log("Actually user is " + userName);
    }
    public static string GetUserName() => userName;

    #endregion
    private void Update()
    {
        TimeToStart();
    }
}
