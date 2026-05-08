using UnityEngine;
public class Bullet : MonoBehaviour
{
    public float lifeTime = 3f;
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(1);
            }
            Destroy(gameObject);
        }
    }
}
