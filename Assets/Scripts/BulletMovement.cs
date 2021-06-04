using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public bool triggered = false;
    private float bulletSpeed = 5.0f;
    public GameObject ball;
    void Start()
    {
        
    }

    void Update()
    {
        Vector3 pos = transform.position;
        pos.y += bulletSpeed * Time.deltaTime;
        transform.position = pos;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("Ball"))
        {
            int health = collision.gameObject.GetComponent<BallMovement>().getHealth();
            collision.gameObject.GetComponent<BallMovement>().setHealth(health - 1);
            if (health - 1 == 0)
            {
                if (collision.gameObject.transform.localScale.x > 0.5)
                {
                    Vector3 ballPos = collision.gameObject.transform.position;
                    float ballSize = collision.gameObject.GetComponent<SpriteRenderer>().bounds.size.x;
                    GameObject rightBall = Instantiate(ball, new Vector3(ballPos.x - ballSize / 2, ballPos.y, 0), Quaternion.identity);
                    GameObject leftBall = Instantiate(ball, new Vector3(ballPos.x + ballSize / 2, ballPos.y, 0), Quaternion.identity);
                    rightBall.transform.localScale = collision.gameObject.transform.localScale / 2;
                    leftBall.transform.localScale = collision.gameObject.transform.localScale / 2;
                    rightBall.GetComponent<Rigidbody2D>().velocity = collision.gameObject.GetComponent<Rigidbody2D>().velocity;
                    leftBall.GetComponent<Rigidbody2D>().velocity = collision.gameObject.GetComponent<Rigidbody2D>().velocity;
                    Vector2 newVelocity = rightBall.GetComponent<Rigidbody2D>().velocity;
                    newVelocity.x = -newVelocity.x;

                    //ball direction left or right ?
                    if (collision.gameObject.GetComponent<Rigidbody2D>().velocity.x < 0)
                        leftBall.GetComponent<Rigidbody2D>().velocity = newVelocity;
                    else
                        rightBall.GetComponent<Rigidbody2D>().velocity = newVelocity;

                    //health
                    int firstHealth = collision.gameObject.GetComponent<BallMovement>().getFirstHealth();
                    leftBall.GetComponent<BallMovement>().setHealth(firstHealth / 2);
                    rightBall.GetComponent<BallMovement>().setHealth(firstHealth / 2);
                }
                Destroy(collision.gameObject);
                
            }
            triggered = true;
        }
    }
}
