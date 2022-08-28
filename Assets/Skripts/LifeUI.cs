using UnityEngine.UI;
using UnityEngine;

public class LifeUI : MonoBehaviour
{
    public Text livesText;
    
    void Update()
    {
        livesText.text ="Lives:" +  PlayrStats.Lives.ToString();

    }
}
