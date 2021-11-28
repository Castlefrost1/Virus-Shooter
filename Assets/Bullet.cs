using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;
    // public Transform bullet;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyBehavior>() != null)
        {
            // GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            // Destroy(effect, 0.5f);
            // Instantiate(explosion, bullet.position, transform.rotation = Quaternion.identity);
            // Destroy(collision.gameObject);
            // Points.instance.AddPoints();
        }
        // DestroyObject();
    }

    void DestroyObject()
    {
        Destroy(gameObject);
    }

    void Update()
    {
        Invoke("DestroyObject", 5f);
    }
}
