using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannonball : MonoBehaviour
{

    public float force = 5f;

    private Rigidbody2D rb;
    private Collider2D coll;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        FindObjectOfType<AudioManager>().Play("Shoot");
    }

    
    void Update()
    {
        rb.AddForce(new Vector2(force, force / 2));
        // rb.AddForce(Vector2.right);
        // rb.AddForce(transform.forward * force);
        // rb.AddForce(Vector2.right * force);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Barrier")
        {
            Destroy(gameObject);
        }

    }

}
