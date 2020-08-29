using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    Ship ship;
    GameObject hud;
    int health = 3;

    float timeElapsed;
    TimeSpan timeSpan;

    public Text timeText;

    // Start is called before the first frame update
    void Start()
    {
        ship = GameObject.FindWithTag("Player").GetComponent<Ship>();
        hud = GameObject.Find("HUD");
    }

    // Update is called once per frame
    void Update()
    {

        UpdateTime();

        if (health != ship.health)
        {
            health = ship.health;
            ChangeHealth(health);
        }
    }

    void ChangeHealth(int health)
    {
        if (health == 2)
        {
            hud.transform.Find("Skull3").gameObject.SetActive(false);
        }
        else if (health == 1)
        {
            hud.transform.Find("Skull2").gameObject.SetActive(false);
        }
        else if (health <= 0)
        {
            hud.transform.Find("Skull1").gameObject.SetActive(false);
        }
    }

    void UpdateTime()
    {
        timeElapsed += Time.deltaTime;
        timeSpan = TimeSpan.FromSeconds(timeElapsed);
        timeText.text = timeSpan.ToString(@"mm\:ss");
    }

}
