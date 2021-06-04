using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    private GameObject settings;
    private float screenHeight, screenWidth;
    public GameObject ball;
    void Awake()
    {
        settings = GameObject.Find("Game Settings");
        screenHeight = settings.GetComponent<GameSettings>().screenHeight;
        screenWidth = settings.GetComponent<GameSettings>().screenWidth;
        Instantiate(ball, new Vector3(screenWidth, screenHeight,0), Quaternion.identity);
        
    }

    void Update()
    {
        
    }
}
