using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    Collider2D coll;
    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<Collider2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
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
            StartCoroutine("Die");
        }
    }

    private IEnumerator Die()
    {

        coll.enabled = false;

        for (int i = 0; i < 3; i++)
        {
            sr.enabled = false;
            yield return new WaitForSeconds(0.2f);
            sr.enabled = true;
            yield return new WaitForSeconds(0.2f);
        }

        Destroy(gameObject);
    }



}
