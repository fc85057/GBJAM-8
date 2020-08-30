using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Ship>().TakeDamage(1);
        }
        else if (collision.tag == "Projectile")
        {
            FindObjectOfType<AudioManager>().Play("Impact");
            Destroy(collision.gameObject);
        }
    }

}
