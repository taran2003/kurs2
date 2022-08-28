using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;
    public float bufSpeed = 10f;
    public int startHealth = 100;
    private float health;
    private Transform target;
    private int wavepointIndex = 0;
    public Image healthBar;

    public void TakeDamage(int amount)
    {
        health -= amount;
        healthBar.fillAmount = health / startHealth;
        if(health <=0)
        {
            Die();
        }
    }

    public float getHealth()
    {
        return health;
    }

    void Die()
    {
        
        Destroy(gameObject);
        WaveSpawner.EnemyAlive--;
    }

    public void Stop()
    {
        speed = 0;
    }

    public void CunticontinueMoving()
    {
        speed = bufSpeed;
    }

    void Start()
    {
        target = Waypoints.points[0];
        health = startHealth;
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        if(Vector3.Distance(transform.position,target.position) <= 0.4)
        {
            GetNextWaypoint();
        }
    }

   void GetNextWaypoint()
    {
        if(wavepointIndex >= Waypoints.points.Length-1)
        {
            EndPath();
            return;
        }

        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }

    void EndPath()
    {
        PlayrStats.Lives--;
        WaveSpawner.EnemyAlive--;
        Destroy(gameObject);
    }
}
