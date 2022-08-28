using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockTurret : MonoBehaviour
{
    public int startHealth = 30;
    public float hitRate = 1f;
    private float hitCountdown = 0f;
    public string enemieTag = "Enemy";
    private float health;
    private HashSet<Enemy> targets = new HashSet<Enemy>();

    public void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.1f);
        health = startHealth;
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemieTag);
        foreach (GameObject enemie in enemies)
        {
            if (Vector3.Distance(transform.position, enemie.transform.position) <= 3)
            {
                targets.Add(enemie.GetComponent<Enemy>());
                Enemy e = enemie.GetComponent<Enemy>();
                if (e != null)
                {
                    e.Stop();
                }
            }
        }
    }

    void Update()
    {
        if (targets == null) return;
        if (hitCountdown <= 0)
        {
            GetHit();
            hitCountdown = 1f / hitRate;
        }
        hitCountdown -= Time.deltaTime;
        foreach (Enemy target in targets)
        {
            if (target.getHealth() <= 0f)
            {
                targets.Remove(target);
            }
        }
    }

    public void GetHit()
    {
        health -= targets.Count;
        if (health <= 0)
        {
            Destroy(gameObject);
            CeepMoving();
        }
    }

    public void CeepMoving()
    {
        foreach (Enemy target in targets)
        {
            target.CunticontinueMoving();
        }
    }
}
