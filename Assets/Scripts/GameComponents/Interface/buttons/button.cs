using System;
using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class button : MonoBehaviour
{
    [SerializeField] private bool isReady;
    public Text buttonText;
    public InputField inputName;
    private string userName;

    public void IsReady()
    {
        isReady = !isReady;
        buttonText.text = isReady ? "READY" : "UNREADY";
        CreateUser();
    }
    public void CreateUser()
    {
        if (isReady)
        {
            userName = inputName.text;
            Debug.Log("[+] CREATE USER - " + userName + " | " + DateTime.Now);
        }
        else
        {
            Debug.Log("[-] DELETE USER - " + userName + " | " + DateTime.Now);
            userName = "none";
        }
        Debug.Log("Actually user is " + userName);
    }
    public string GetUserName() => this.userName;
    public bool GetReady() => this.isReady;

}
