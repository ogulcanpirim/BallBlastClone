using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float playerSpeed = 3.0f;
    private GameObject settings;
    private float widthBound, heightBound;
    private Vector3 playerSize;
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

        transform.position = pos;


    }
}
