using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{

    Rigidbody2D rb;
    float horizontalMove;
    float verticalMove;
    public float speed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        verticalMove = Input.GetAxisRaw("Vertical");
        horizontalMove = Input.GetAxisRaw("Horizontal");
        float moveSpeed = speed * Time.deltaTime;
        if (verticalMove != 0)
        {
            transform.position = Vector2.MoveTowards(transform.position,
                new Vector2(transform.position.x, transform.position.y + verticalMove), moveSpeed);
        }
        if (horizontalMove != 0)
        {
            transform.position = Vector2.MoveTowards(transform.position,
                new Vector2(transform.position.x + horizontalMove, transform.position.y), moveSpeed);
        }
    }
}
