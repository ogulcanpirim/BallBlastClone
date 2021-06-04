using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
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
}
