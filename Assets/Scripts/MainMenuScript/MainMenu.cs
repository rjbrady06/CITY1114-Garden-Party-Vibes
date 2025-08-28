using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Player has quit the game");
    }
}
