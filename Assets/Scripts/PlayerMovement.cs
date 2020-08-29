using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private float movement;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = (Input.GetAxisRaw("Horizontal"));

        Vector2 newPos = new Vector2(transform.position.x + movement, transform.position.y);

        transform.position = Vector2.MoveTowards(transform.position, newPos, 1f);
    }
}
