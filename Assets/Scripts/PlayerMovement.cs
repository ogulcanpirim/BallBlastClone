using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject bullet;
    private float playerSpeed = 3.0f;
    private GameObject settings;
    private float widthBound, heightBound;
    private Vector3 playerSize;
    public float bulletNumber = 1;
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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            for (int i = 0; i < bulletNumber; i++)
            {
                Instantiate(bullet, new Vector3(pos.x, pos.y + playerSize.y / 2, 0), Quaternion.identity);
            }
        }

        transform.position = pos;


    }
}
