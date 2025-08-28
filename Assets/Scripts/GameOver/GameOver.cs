using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject GameOverCanvas;

    private bool isGameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver) return;

        if(GameFlow.score <= 0)
        {
            TriggerGameOver();
        }
    }

    void TriggerGameOver()
    {
        isGameOver = true;
        Time.timeScale = 0f;
        GameOverCanvas.SetActive(true);
        Debug.Log("Game Over!");
    }

    public void RestartGame()
    {
        GameFlow.score = 50;
        GameFlow.plateNum = 0;
        GameFlow.plateXpos = 1;
        GameFlow.emptyPlateNow = -1;

        for (int i = 0; i < GameFlow.orderTimer.Length; i++)
        {
            GameFlow.orderTimer[i] = 20f;
            GameFlow.orderValue[i] = 0;
            GameFlow.plateValue[i] = 0;
        }

        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("MainMenu");
        Debug.Log("Exiting to main menu");
    }
}
