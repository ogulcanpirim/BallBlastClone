using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BallMovement : MonoBehaviour
{
    private const float ballInitialSpeed = 400f;
    private float ballSpeed;
    private float ballAngle = 70;
    private float widthSpeed;
    private int firstHealth;
    private int health = 80;
    private GameObject ballHealth;
    void Start()
    {
        ballHealth = transform.GetChild(0).gameObject;
        firstHealth = health;
        ballSpeed = ballInitialSpeed + (transform.localScale.x * 100);
    }

    void Update()
    {
        if (this.GetComponent<Rigidbody2D>().velocity.x != 0)
            widthSpeed = this.GetComponent<Rigidbody2D>().velocity.x;

        ballHealth.transform.position = this.transform.position;
        ballHealth.GetComponent<TextMeshPro>().SetText(health.ToString());

        if (widthSpeed < 0 && ballAngle < 90)
            ballAngle = 180 - ballAngle;

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

    public int getFirstHealth()
    {
        return firstHealth;
    }

    public void setHealth(int newHealth)
    {
        health = newHealth;
    }

    public int getHealth()
    {
        return health;
    }
}
