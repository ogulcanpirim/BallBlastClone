using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public GameObject bullet;
    private float playerSpeed = 15.0f;
    private GameObject settings;
    private float widthBound, heightBound;
    private Vector3 playerSize;
    public float bulletNumber = 5;
    public float bulletPeriod = 0.15f;
    private float nextBulletTime = 0.0f;

    private bool finished = false;
    private bool isMoving = false;
    private Rigidbody2D rb;
    private Vector3 playerPos;
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
        rb = GetComponent<Rigidbody2D>();
        playerPos = rb.position;
        
        isMoving = Input.GetMouseButton(0);

        if (isMoving)
        {
            playerPos.x = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;    
        }
        /*PC Control
        if (Input.GetKey(KeyCode.LeftArrow) && pos.x > -widthBound + playerSize.x / 2)
            pos.x -= playerSpeed * Time.deltaTime;
        else if (Input.GetKey(KeyCode.RightArrow) && pos.x < widthBound - playerSize.x / 2)
            pos.x += playerSpeed * Time.deltaTime;
        */
        
        
        if (Time.time > nextBulletTime && isMoving)
        {
            Instantiate(bullet, new Vector3(playerPos.x, playerPos.y + playerSize.y, 0), Quaternion.identity);
            nextBulletTime += bulletPeriod;
        }

        //Play Again
        if (Input.GetKeyDown(KeyCode.Space) && finished)
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("Main");
        }

    }

    void FixedUpdate()
    {
        if (isMoving)
        {
            this.GetComponent<Rigidbody2D>().MovePosition(Vector2.Lerp(rb.position, playerPos, playerSpeed * Time.fixedDeltaTime));
        }
        else if (rb != null)
        {
            rb.velocity = Vector2.zero;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //freeze scene
        Time.timeScale = 0;
        finished = true;
        
    }
}
