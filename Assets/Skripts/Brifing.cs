using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brifing : MonoBehaviour
{
    public void Close()
    {
        this.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
}
