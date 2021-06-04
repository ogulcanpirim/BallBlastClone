using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{ 
    public float screenWidth, screenHeight;
    void Awake()
    {
        Vector3 screen;
        screen = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        screenWidth = screen.x;
        screenHeight = screen.y;
        
    }

    void Update()
    {

        foreach (GameObject go in GameObject.FindObjectsOfType<GameObject>())
        {
            if (go.gameObject.name.Contains("(Clone)"))
            {
                if (go.transform.position.y > screenHeight + 2.0f)
                    Destroy(go);
            }
        }
        
    }
}
