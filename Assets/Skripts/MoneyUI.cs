using UnityEngine;
using UnityEngine.UI;


public class MoneyUI : MonoBehaviour
{
    public Text money;
    void Update()
    {
        money.text = "Oxygen:" + PlayrStats.money.ToString();
    }
}
