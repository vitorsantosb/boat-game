using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [Header("Interface")]
    public Text counter, user;
    private float counterTimer;
    public GameObject buttonToChangeScene;
    public GameObject FirstCanvas_;
    public bool closeScene;
    [Header("Butão")]
    [SerializeField] private bool isReady_;
    public Text buttonText;
    public InputField inputName;
    [SerializeField] private static string userName;

    
    void Awake()
    {
        this.counterTimer = 5;
        this.isReady_ = false;
        this.closeScene = false;
        
       
    }

    public void SetSceneToGo(string param) => SceneManager.LoadSceneAsync(param);

    public void SetSceneToGo(int param) => SceneManager.LoadSceneAsync(param);

    public void SetSceneToGoDelay(string param)
    {
        StartCoroutine(LoadCenaA(3f, param));
    }

    IEnumerator LoadCenaA(float delay, string param)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadSceneAsync(param);
    }
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
    public void CreateUser()
    {
        
        if (closeScene)
        {
            userName = inputName.text;
            this.user.text = inputName.text;
            this.isReady_ = true;
            Debug.Log("[+] CREATE USER - " + userName + " | " + DateTime.Now);
        }
        else
        {
            user.text = "Guest";
            this.isReady_ = true;
            Debug.Log("[-] USER IS NOT DEFINED - GUEST USER - " + userName + " | " + DateTime.Now);
        }
        Debug.Log("Actually user is " + userName);
    }
    public static string GetUserName() => userName;


    public void QuitGame()
    {
        Application.Quit();
    }
    
    #endregion
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            AudioManager.Instance.Play("OceanMenu");
            FirstCanvas_.SetActive(false);
            if (inputName.placeholder == false)
            {
                this.closeScene = false;
                CreateUser();
                return;
            }
            this.closeScene = true;
            CreateUser();
            return;
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            FirstCanvas_.SetActive(true);
            return;
        }
        TimeToStart();
    }

    
    
}
