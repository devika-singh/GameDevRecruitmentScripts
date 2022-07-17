using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private bool isGameOpenedFirstTime;
    private void Start()
    {
        isGameOpenedFirstTime = true;
    }
    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    public void playTut()
    {
        SceneManager.LoadScene("Tutorial");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
    public void playMainLevel()
    {
        SceneManager.LoadScene("MainLevel");
       // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);

    }
}
