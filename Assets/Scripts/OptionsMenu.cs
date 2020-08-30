using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{

    int index;
    int subIndex;
    int totalOptions = 3;

    float yMovement;
    float xMovement;

    private void Start()
    {
        yMovement = (0.331f * Screen.height + 2.3f);
        xMovement = (0.148f * Screen.width + 13.32f);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow)
            && index < totalOptions - 1 && subIndex == 0)
        {
            FindObjectOfType<AudioManager>().Play("Sails");
            index++;
            transform.position = new Vector2(transform.position.x,
                transform.position.y - yMovement);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) &&
            index < totalOptions -1 && subIndex == 0)
        {
            FindObjectOfType<AudioManager>().Play("Sails");
            subIndex++;
            transform.position = new Vector3(transform.position.x + xMovement,
                transform.position.y);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) &&
            index < totalOptions - 1 && subIndex == 1)
        {
            FindObjectOfType<AudioManager>().Play("Sails");
            subIndex--;
            transform.position = new Vector3(transform.position.x - xMovement,
                transform.position.y);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow)
            && index > 0 && subIndex == 0)
        {
            FindObjectOfType<AudioManager>().Play("Sails");
            index--;
            transform.position = new Vector2(transform.position.x,
                transform.position.y + yMovement);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            ChangeSoundSettings();
        }

    }

    void ChangeSoundSettings()
    {
        if (index == 0 && subIndex == 0)
        {
            FindObjectOfType<AudioManager>().musicOn = true;
            FindObjectOfType<AudioManager>().SetMusic(true);
        }
        else if (index == 0 && subIndex == 1)
        {
            FindObjectOfType<AudioManager>().musicOn = false;
            FindObjectOfType<AudioManager>().SetMusic(false);
        }
        else if (index == 1 && subIndex == 0)
        {
            FindObjectOfType<AudioManager>().sfxOn = true;
        }
        else if (index == 1 && subIndex == 1)
        {
            FindObjectOfType<AudioManager>().sfxOn = false;
        }
        else if (index == 2)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
