using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour
{
    private TMP_InputField nick;

    public void StartGame ()
    {
        nick = GameObject.Find("Username").GetComponent<TMP_InputField>();
        GameManager.GetPlayer(nick.text);
        SceneManager.LoadScene(1);
    }

    public void CreateUser()
    {
        Application.OpenURL("https://hidden-bastion-61343.herokuapp.com");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
