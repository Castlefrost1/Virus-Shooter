using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{

    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>() != null)
        {
            // GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            // Destroy(effect, 0.5f);
            // Instantiate(explosion, bullet.position, transform.rotation = Quaternion.identity);
            Destroy(gameObject);
            Points.instance.AddItem();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
