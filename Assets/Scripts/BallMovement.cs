using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{

    private float ballSpeed = 600.0f;
    private float ballAngle = 70;
    private float widthSpeed;
    void Start()
    {

    }

    void Update()
    {
        if (this.GetComponent<Rigidbody2D>().velocity.x != 0)
            widthSpeed = this.GetComponent<Rigidbody2D>().velocity.x;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("Wall"))
        {
            Vector2 velocity = this.GetComponent<Rigidbody2D>().velocity;
            velocity.x = -widthSpeed;
            ballAngle = 180 - ballAngle;
            this.GetComponent<Rigidbody2D>().velocity = velocity;
        }
        else
        {
            this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            this.GetComponent<Rigidbody2D>().AddForce(new Vector2(Mathf.Cos(Mathf.Deg2Rad * ballAngle), Mathf.Sin(Mathf.Deg2Rad * ballAngle)) * ballSpeed);
            
        }
    }
}
