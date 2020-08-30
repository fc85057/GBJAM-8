using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{

    public float speed = 1f;
    public int health = 3;
    public GameObject cannonball;

    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator animator;
    Transform barrel;

    bool sailsDown;
    bool invincible;
    float nextAttackTime;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        barrel = GameObject.Find("Barrel").transform;
        nextAttackTime = 0f;

        sailsDown = true;
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (sailsDown)
            {
                sailsDown = false;
                animator.SetBool("sailsDown", false);
            }
            else
            {
                sailsDown = true;
                animator.SetBool("sailsDown", true);
            }
            FindObjectOfType<AudioManager>().Play("Sails");
        }

        if (sailsDown)
        {
            transform.position = Vector2.MoveTowards(transform.position,
                new Vector2(transform.position.x + 1f,
                transform.position.y), (speed * Time.deltaTime));
        }

        if (Input.GetKey(KeyCode.LeftArrow) ||
            Input.GetKey(KeyCode.UpArrow))
        {
            transform.position = Vector2.MoveTowards(transform.position,
                new Vector2(transform.position.x,
                transform.position.y + 1f), (speed * Time.deltaTime));
        }

        if (Input.GetKey(KeyCode.RightArrow) ||
                Input.GetKey(KeyCode.DownArrow))
        {
            transform.position = Vector2.MoveTowards(transform.position,
                new Vector2(transform.position.x,
                transform.position.y - 1f), (speed * Time.deltaTime));
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            Fire();
        }


    }

    void Fire()
    {
        if (Time.time > nextAttackTime)
        {
            Instantiate(cannonball, barrel);
            nextAttackTime = Time.time + .5f;
        }
        
    }

    public void TakeDamage(int damage)
    {
        if (!invincible)
        {
            health -= damage;
            StartCoroutine("PlayDamageAnimation");
            FindObjectOfType<AudioManager>().Play("Hurt");
        }
    }

    public void ResetPosition()
    {
        transform.position = new Vector3(Camera.main.transform.position.x - 2f, 
            transform.position.y, transform.position.z);
    }

    IEnumerator PlayDamageAnimation()
    {

        invincible = true;

        for (int i = 0; i < 8; i++)
        {
            sr.enabled = false;
            yield return new WaitForSeconds(.2f);
            sr.enabled = true;
            yield return new WaitForSeconds(.2f);

        }

        invincible = false;


    }

}
