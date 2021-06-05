using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{ 
    public float screenWidth, screenHeight;
    public GameObject cube;
    void Awake()
    {
        Vector3 screen;
        screen = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        screenWidth = screen.x;
        screenHeight = screen.y;

        //Floor
        GameObject floor = Instantiate(cube, Vector3.zero, Quaternion.identity);
        floor.GetComponent<SpriteRenderer>().enabled = false;
        floor.transform.localScale = new Vector3(screenWidth * 2, 0.5f, 0);
        float size = floor.GetComponent<SpriteRenderer>().bounds.size.y;
        floor.transform.position = new Vector3(0,-(screenWidth / 2) + size / 2,0);
        floor.name = "Floor";

        //Left Wall
        GameObject leftWall = Instantiate(cube, Vector3.zero, Quaternion.Euler(new Vector3(0,0,90)));
        leftWall.transform.localScale = new Vector3(screenHeight * 2, 0.5f, 0);
        size = leftWall.GetComponent<SpriteRenderer>().bounds.size.x;
        leftWall.transform.position = new Vector3(-(screenWidth) - size / 2, 0, 0);
        leftWall.name = "Left Wall";

        //Right Wall
        GameObject rightWall = Instantiate(cube, Vector3.zero, Quaternion.Euler(new Vector3(0, 0, 90)));
        rightWall.transform.localScale = new Vector3(screenHeight * 2, 0.5f, 0);
        size = rightWall.GetComponent<SpriteRenderer>().bounds.size.x;
        rightWall.transform.position = new Vector3(+(screenWidth) + size / 2, 0, 0);
        rightWall.name = "Right Wall";
    }

    void Update()
    {

        foreach (GameObject go in GameObject.FindObjectsOfType<GameObject>())
        {
            if (go.gameObject.name.Contains("Bullet(Clone)"))
            {
                if (go.transform.position.y > screenHeight + 2.0f)
                    Destroy(go);
                if (go.gameObject.GetComponent<BulletMovement>().triggered)
                    Destroy(go);
            }
        }
        
    }
}
