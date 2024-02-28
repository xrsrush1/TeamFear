using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class GameObjectController : MonoBehaviour
{
    public GameObject[] gameObjects;
    private int currentIndex = 0;

    void Start()
    {
        // Ensure only the first object is active at the start
        DisableAllExceptCurrent();
    }

    public void CycleGameObjects()
    {
        // Disable the current object
        gameObjects[currentIndex].SetActive(false);

        // Move to the next object
        currentIndex = (currentIndex + 1) % gameObjects.Length;

        // Enable the next object
        gameObjects[currentIndex].SetActive(true);
    }

    void DisableAllExceptCurrent()
    {
        // Disable all game objects except the current one
        for (int i = 0; i < gameObjects.Length; i++)
        {
            if (i != currentIndex)
            {
                gameObjects[i].SetActive(false);
            }
            else
            {
                gameObjects[i].SetActive(true);
            }
        }
    }
}
