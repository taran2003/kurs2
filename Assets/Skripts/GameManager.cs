using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public string nextLevel;
    public int levelToUnlock;
    public static bool gameEnded;
    public GameObject gameOverUI;
    public GameObject winLevelUI;
    public GameObject brifinglUI=null;
    public SceneFader fader;

    void Start()
    {
        gameEnded = false;
        if (brifinglUI != null)
        {
            brifinglUI.SetActive(true);
            Invoke("TheWorld", 0.8f);
        }
    }

    void Update()
    {
        if (gameEnded)
            return;

        

        if(PlayrStats.Lives <=0)
        {
            EndGame();
        }
    }
    void EndGame()
    {
        gameEnded = true;
        gameOverUI.SetActive(true);
        Invoke("TheWorld", 0.55f);
    }

    void TheWorld()
    {
        Time.timeScale = 0f;
    }

    public void WinLevel()
    {
        Debug.Log("LEVEL WON!");
        winLevelUI.SetActive(true);
        Invoke("TheWorld", 1f);
        FileWork.Write("Save.txt", levelToUnlock.ToString(), false);
    }
}
