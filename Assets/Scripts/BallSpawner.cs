using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    private float spawnHeight;
    private float width, height;
    private float ballEnterSpeed = 3.0f;
    public GameObject settings;
    public GameObject ball;
    private GameObject newBall;
    void Awake()
    {
        settings = GameObject.Find("Game Settings");
        width = settings.GetComponent<GameSettings>().screenWidth;
        height = settings.GetComponent<GameSettings>().screenHeight;
        spawnHeight = height * 0.60f;
        generateNewBall();
    }
 
    void Update()
    {
                
        if (newBall != null && !inScreen(newBall))
        {
            Vector3 pos = newBall.transform.position;
            pos.x += ballEnterSpeed * Time.deltaTime;
            newBall.transform.position = pos;
        }

        if (newBall != null && inScreen(newBall))
        {
            newBall.GetComponent<CircleCollider2D>().enabled = true;
            newBall.GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }


    void generateNewBall()
    {
        newBall = Instantiate(ball, new Vector3(-width * 1.3f, spawnHeight, 0), Quaternion.identity);
        newBall.GetComponent<CircleCollider2D>().enabled = false;
        newBall.GetComponent<Rigidbody2D>().gravityScale = 0;
        
    }

    bool inScreen(GameObject go)
    {
        Vector2 size = go.GetComponent<SpriteRenderer>().bounds.size;
        if ((go.transform.position.x > -width + size.x / 2) && (go.transform.position.x < width - size.x / 2))
            return true;
        return false;
    }
}
