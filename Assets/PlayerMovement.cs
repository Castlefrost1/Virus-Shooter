using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float timer = 0f;

    public float moveSpeed = 5f;
    public int back;

    public Rigidbody2D rb;
    public Camera cam;

    public AudioClip audio;
    AudioSource audioSource;

    Vector2 movement;
    Vector2 mousePos;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<ItemPickup>() != null)
        {
            // GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            // Destroy(effect, 0.5f);
            // Instantiate(explosion, bullet.position, transform.rotation = Quaternion.identity);
            if (audio != null)
            {
                audioSource.PlayOneShot(audio, 0.5f);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyBehavior>() != null)
        {
            // GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            // Destroy(effect, 0.5f);
            // Instantiate(explosion, bullet.position, transform.rotation = Quaternion.identity);
            FindObjectOfType<GameManager>().EndGame();
            DestroyObject();
        }
    }

    void DestroyObject()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (rb.rotation < 90 && rb.rotation > -90 && back == 1)
        {
            flip();
            back = 2;
        }
        else if
        (rb.rotation > 90 && rb.rotation < -90 && back == 2)
        {
            flip();
            back = 1;
        }
        this.timer += Time.deltaTime;

        //function untuk membalikkan karakter secara vertical untuk menghadap ke kiri dan ke kanan
        void flip()
        {
            
            Vector3 player = transform.localScale;
            player.x *= -1;
            transform.localScale = player;
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
    }
}
