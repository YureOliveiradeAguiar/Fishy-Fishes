using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLogicScript : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadSceneAsync(1);
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
