using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearSave : MonoBehaviour
{
    public SceneFader fader;
    public void Clear()
    {
        FileWork.Write("Save.txt","1", false);
        fader.FadeTo("LevelSelect");
    }
}
