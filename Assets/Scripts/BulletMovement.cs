using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public bool triggered = false;
    private float bulletSpeed = 5.0f;
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
                Destroy(collision.gameObject);
            triggered = true;
        }
    }
}
