using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public GameObject hitEffect, dropItem;

    public Rigidbody2D enemy;

    public float speed;

    private Transform target;

    private int dropRate = 2;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Bullet>() != null)
        {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            if (Random.Range(0, 10) <= dropRate)
            {
                GameObject dropper = Instantiate(dropItem, transform.position, Quaternion.identity);
                Destroy(dropper, 3f);
            }
            DestroyObject();
            Destroy(collision.gameObject);
            Points.instance.AddPoints();
            Destroy(effect, 0.5f);
            // Instantiate(explosion, bullet.position, transform.rotation = Quaternion.identity);
            // Destroy(collision.gameObject);
            // Points.instance.AddPoints();
        }
    }

    void DestroyObject()
    {
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    /*public void AddSpeed()
    {
        speed += 1;
        if (speed > 6)
        {
            speed = 6;
        }
    }*/

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        Vector2 lookDir = target.position - transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        enemy.rotation = angle + 180f;
    }
}
