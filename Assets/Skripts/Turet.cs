using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turet : MonoBehaviour
{
    private Transform target =null;
    [Header("Attributes")]
    public float range = 15f;
    public float fireRate = 1f;
    private float fireCountdown = 0f;
    [Header("Enimy Set up")]
    public string enemieTag = "Enemy";
    public Transform partToRotate;
    public float turnSpeed = 10f;
    [Header("Bulet")]
    public GameObject bulletPrefab;
    public Transform firePoint;

    void Start()
    {
        InvokeRepeating("UpdateTarget",0f,0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemieTag);
        for(int i=0;i<enemies.Length;i++)
        {
            if(Vector3.Distance(transform.position, enemies[i].transform.position)<=range)
            {
                target = enemies[i].transform;
                break;
            }
        }
    }

    void Update()
    {
        if (target == null) return;
        //target lock on
        Vector3 dir = target.position - transform.position;
        Quaternion lookPosition = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation,lookPosition,Time.deltaTime* turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        if(fireCountdown<=0)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }
        fireCountdown -= Time.deltaTime;
    }

    void Shoot()
    {
        GameObject bulletGo = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGo.GetComponent<Bullet>();
        if (bullet != null) bullet.Seek(target);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position,range);
    }
}
