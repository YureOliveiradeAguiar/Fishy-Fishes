using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using System;

public class LogicScript : MonoBehaviour
{
    public float playerScore;
    public TextMeshProUGUI textMeshPro;
    public PlayerScript playerScript;
    public GameObject gameOverScreen;
    public GameObject pauseScreen;
    public GameObject victoryScreen;
    public InputActionReference pause;
    public float timerMinutes;
    public float timerSeconds;
    void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
        textMeshPro.text = "10cm";
        timerMinutes = 0;
        timerSeconds = 0;
    }
    private void FixedUpdate()
    {
        timerSeconds += Time.deltaTime;
        if (timerSeconds > 59)
        {
            timerSeconds = 0;
            timerMinutes += 1;
        }
    }
    public void addScore()
    {
        playerScore = playerScript.playerSize * 10;
        textMeshPro.text = playerScore.ToString("0.00") + "cm";
    }
    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        Time.timeScale = 0;
    }
    private void OnEnable()
    {
        pause.action.started += PausingGame;
    }
    private void OnDisable()
    {
        pause.action.started -= PausingGame;
    }
    public void PausingGame(InputAction.CallbackContext obj)
    {
        if (Time.timeScale > 0)
        {
            pauseScreen.SetActive(true);
            Time.timeScale = 0;
        } else
        {
            pauseScreen.SetActive(false);
            Time.timeScale = 1;
        }
    }
    //This part manages te ingame buttons:
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
    }
    public void ContinueGame()
    {
        pauseScreen.SetActive(false);
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
    }
    public void ReturnToMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
