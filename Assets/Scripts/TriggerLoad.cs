﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerLoad : MonoBehaviour
{

    bool triggerEntered;
    public GameObject levelPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!triggerEntered && collision.tag == "Player")
        {
            GameObject newBackground = Instantiate(levelPrefab, new Vector3(transform.position.x + 5,
                transform.position.y, transform.position.z), Quaternion.identity);
            FindObjectOfType<GameManager>().AddBackground(newBackground);
            triggerEntered = true;
        }
        
    }

}
