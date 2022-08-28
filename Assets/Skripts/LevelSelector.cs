using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public SceneFader fader;
    public Button[] levelButton;

    private void Start()
    {
        int levelReached = int.Parse(FileWork.ReadFile("Save.txt"));
        for (int i = 0; i < levelButton.Length; i++)
        {
            if (i + 1 > levelReached) levelButton[i].interactable = false;
        }
    }

    public void Select(string levelName)
    {
        fader.FadeTo(levelName);
    }
}
