
using UnityEngine;

public class IncomePoints : MonoBehaviour
{
    public static Transform[] inpoints;

    void Awake()
    {
        inpoints = new Transform[transform.childCount];
        for (int i = 0; i < inpoints.Length; i++)
        {
            inpoints[i] = transform.GetChild(i);
        }
    }

}
