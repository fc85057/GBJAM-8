using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonMenu : MonoBehaviour
{

    int index = 0;
    int totalOptions = 3;
    public float yMovement;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) && index < totalOptions - 1)
        {
            FindObjectOfType<AudioManager>().Play("Sails");
            index++;
            transform.position = new Vector2(transform.position.x, transform.position.y - yMovement);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && index > 0)
        {
            FindObjectOfType<AudioManager>().Play("Sails");
            index--;
            transform.position = new Vector2(transform.position.x, transform.position.y + yMovement);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            switch(index)
            {
                case 0:
                    SceneManager.LoadScene("MainGame");
                    break;
                case 1:
                    SceneManager.LoadScene("Tutorial");
                    break;
                case 2:
                    SceneManager.LoadScene("Options");
                    break;
                default:
                    return;

            }
        }

    }
}
