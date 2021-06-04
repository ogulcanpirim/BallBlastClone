using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject bullet;
    private float playerSpeed = 5.0f;
    private GameObject settings;
    private float widthBound, heightBound;
    private Vector3 playerSize;
    public float bulletNumber = 5;
    public float bulletPeriod = 0.15f;
    private float nextBulletTime = 0.0f;
    
    void Awake()
    {
        settings = GameObject.Find("Game Settings");
        widthBound = settings.GetComponent<GameSettings>().screenWidth;
        heightBound = settings.GetComponent<GameSettings>().screenHeight;
        playerSize = this.GetComponent<SpriteRenderer>().bounds.size;
        transform.position = new Vector3(0, -heightBound + playerSize.y / 2, 0);
    }

    void Update()
    {

        Vector3 pos = transform.position;

        //PC Control
        if (Input.GetKey(KeyCode.LeftArrow) && pos.x > -widthBound + playerSize.x / 2)
            pos.x -= playerSpeed * Time.deltaTime;
        else if (Input.GetKey(KeyCode.RightArrow) && pos.x < widthBound - playerSize.x / 2)
            pos.x += playerSpeed * Time.deltaTime;

        /*Space Control
        if (Input.GetKeyDown(KeyCode.Space))
            Instantiate(bullet, new Vector3(pos.x, pos.y + playerSize.y / 2, 0), Quaternion.identity);
        */
        if (Time.time > nextBulletTime)
        {
            Instantiate(bullet, new Vector3(pos.x, pos.y + playerSize.y / 2, 0), Quaternion.identity);
            nextBulletTime += bulletPeriod;
        }
        transform.position = pos;


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("vuruldum !");
    }
}
