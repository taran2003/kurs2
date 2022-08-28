using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public float speed = 70f;
    public float expolosionRadius = 0f;
    public GameObject impactEfect;
    public int damage = 50;

    public void Seek(Transform target)
    {
        this.target = target;
    }

    void Update()
    {
        if(target==null)
        {
            Destroy(gameObject);
            return;
        }
        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;
        if(dir.magnitude<=distanceThisFrame)
        {
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized * distanceThisFrame,Space.World);
        transform.LookAt(target);
    }
    void HitTarget()
    {
        GameObject effect = (GameObject)Instantiate(impactEfect, transform.position, transform.rotation);
        Destroy(effect, 2f);
        if(expolosionRadius>0f)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }
    }
    void Explode()
    {
       Collider[] colliders = Physics.OverlapSphere(transform.position,expolosionRadius);
        foreach(Collider collider in colliders)
        {
            if(collider.tag=="Enemy")
            {
                Damage(collider.transform);
            }
        }
    }

    void Damage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();
        if (e != null)
        {
            e.TakeDamage(damage);
        }
        Destroy(gameObject);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,expolosionRadius);
    }
}
