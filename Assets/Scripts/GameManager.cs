using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    Ship ship;
    List<GameObject> backgrounds;
    bool isPaused;

    void Start()
    {
        backgrounds = new List<GameObject>();
        ship = GameObject.FindWithTag("Player").GetComponent<Ship>();
    }

    void Update()
    {
        Debug.Log(backgrounds.Count);
        if (backgrounds.Count > 2)
        {
            GameObject toRemove = backgrounds[0];
            backgrounds.Remove(toRemove);
            Destroy(toRemove);
            // backgrounds[0].gameObject.SetActive(false);
        }
        if (ship.health <= 0)
        {
            StartCoroutine(GameOver());
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    public void AddBackground(GameObject background)
    {
        backgrounds.Add(background);
    }

    /*
    void GameOver()
    {
        Camera.main.GetComponent<CameraController>().enabled = false;
        GameObject.Find("Barriers").GetComponent<CameraController>().enabled = false;
        FindObjectOfType<UIManager>().isEnabled = false;
        FindObjectOfType<UIManager>().GameOver();
        ship.enabled = false;
    }
    */

    IEnumerator GameOver()
    {
        Camera.main.GetComponent<CameraController>().enabled = false;
        GameObject.Find("Barriers").GetComponent<CameraController>().enabled = false;
        FindObjectOfType<UIManager>().isEnabled = false;
        FindObjectOfType<UIManager>().GameOver();
        ship.enabled = false;

        yield return new WaitForSeconds(5f);

        SceneManager.LoadScene("MainMenu");
    }

    void Pause()
    {
        if (isPaused)
        {
            Time.timeScale = 1f;
            FindObjectOfType<UIManager>().Pause(isPaused);
            isPaused = false;
        }
        else
        {
            Time.timeScale = 0f;
            FindObjectOfType<UIManager>().Pause(isPaused);
            isPaused = true;
        }
        
    }

}
