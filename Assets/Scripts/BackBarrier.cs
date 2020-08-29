using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackBarrier : MonoBehaviour
{

    BoxCollider2D coll;

    void Start()
    {
        coll = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponentInParent<Ship>().TakeDamage(1);
            collision.GetComponentInParent<Ship>().ResetPosition();
        }
    }
}
