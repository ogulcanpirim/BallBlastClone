using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{

    private float ballSpeed = 600.0f;
    private float ballAngle = 45;
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.GetComponent<Rigidbody2D>().AddForce(new Vector2(1, 1) * ballSpeed);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        this.GetComponent<Rigidbody2D>().AddForce(new Vector2(Mathf.Cos(ballAngle), Mathf.Sin(ballAngle)) * ballSpeed);
    }
}
