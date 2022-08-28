using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinLevel : MonoBehaviour
{
    public Text roundsText;
    public SceneFader sceneFader;
    public string nextLevel;

    void OnEnable()
    {
        roundsText.text = PlayrStats.Rounds.ToString();
    }

    public void NextLevel()
    {
        Time.timeScale = 1f;
        sceneFader.FadeTo(nextLevel);
    }

    public void Menu()
    {
        Time.timeScale = 1f;
        sceneFader.FadeTo("MainMenu");
    }
}