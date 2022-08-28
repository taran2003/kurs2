using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Income : MonoBehaviour
{
    
    public float speed = 10f;

    private Transform target;
    private int wavepointIndex = 0;

    int moniToGive = 1;

    void Start()
    {
        target = IncomePoints.inpoints[0];

    }
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        if (Vector3.Distance(transform.position, target.position) <= 0.4)
        {
            GetNextWaypoint();
        }
    }
    void GetNextWaypoint()
    {
        if (wavepointIndex >= IncomePoints.inpoints.Length - 1)
        {
            Destroy(gameObject);
            PlayrStats.money+=moniToGive;
            return;
        }

        wavepointIndex++;
        target = IncomePoints.inpoints[wavepointIndex];
    }
}
