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
    private int nextBall = 1;
    
    

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
           
            pos.x += nextBall*ballEnterSpeed  * Time.deltaTime;
            newBall.transform.position = pos;
            
        }

        if (newBall != null && inScreen(newBall))
        {
            newBall.GetComponent<CircleCollider2D>().enabled = true;
            newBall.GetComponent<Rigidbody2D>().gravityScale = 1;
        }
        FindBall();

        
    }


    void generateNewBall()
    {
        nextBall *= -1;
        newBall = Instantiate(ball, new Vector3(-width * 1.3f*nextBall, spawnHeight, 0), Quaternion.identity);
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

    void FindBall()
    {
        GameObject ballEx;
        ballEx = GameObject.Find("Ball(Clone)");
        if (ballEx == null)
        generateNewBall();
       
    }
}
