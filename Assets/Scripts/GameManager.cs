using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    List<GameObject> backgrounds;

    void Start()
    {
        backgrounds = new List<GameObject>();
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
    }

    public void AddBackground(GameObject background)
    {
        backgrounds.Add(background);
    }

}
