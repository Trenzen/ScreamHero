using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    public float jumpForce;
    public Vector3 minYJump;
    public Vector3 maxYJump;
    public Vector3 endPoint;
    public float speed = 10f;
    private Rigidbody2D rb;
    public bool isGrounded;
    private float jumpTimeCounter;
    public float jumpTime;
    public bool isJumping;
    public static bool Fly;
    public Animator playerAnimation;
    private SpriteRenderer spriteColor;
    [SerializeField] private List<Color> playerColor;
    void Start()
    {
        spriteColor = this.GetComponent<SpriteRenderer>();
        rb = this.GetComponent<Rigidbody2D>();
        maxYJump = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        minYJump = Camera.main.ScreenToWorldPoint(Vector3.zero);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            isGrounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "SpawnPos")
        {
            Color changedColor = playerColor[Random.Range(0, playerColor.Count)];
            spriteColor.color = changedColor;
            GameConstants.count = 1;
            GameConstants.scoreKeeper = 1;
            GameConstants.spawnPosition = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "SpawnPos")
        {
            GameConstants.count = 0;
            GameConstants.scoreKeeper = 0;
            GameConstants.spawnPosition = false;
        }
    }

    void Update()
    {
        if (GameConstants.Activate == true)
        {
            Vector3 playerPos = this.transform.position;
            endPoint = new Vector3(this.transform.position.x, minYJump.y, this.transform.position.z);
            if (playerPos.y <= endPoint.y)
            {
                SceneManager.LoadScene(0);
            }
            this.transform.position = new Vector3(this.transform.position.x, Mathf.Clamp(this.transform.position.y, minYJump.y, maxYJump.y - 3f), this.transform.position.z);
            if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
            {
                isJumping = true;
                Fly = true;
                transform.Translate(Vector2.right * speed * Time.deltaTime);
                jumpTimeCounter = jumpTime;
                rb.velocity = Vector2.up * jumpForce;
            }
            if (Input.GetKey(KeyCode.Space) && isJumping == true)
            {
                if (jumpTimeCounter > 0)
                {
                    Fly = true;
                    transform.Translate(Vector2.right * speed * Time.deltaTime);
                    rb.velocity = Vector2.up * jumpForce;
                    jumpTimeCounter -= Time.deltaTime;
                }
                else
                {
                    Fly = false;
                    isJumping = false;
                }
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                Fly = false;
                isJumping = false;
            }


            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Stationary && touch.deltaPosition.magnitude < 100f && isJumping == true)
                {
                    if (jumpTimeCounter > 0)
                    {
                        transform.Translate(Vector2.right * speed * Time.deltaTime);
                        rb.velocity = Vector2.up * jumpForce;
                        jumpTimeCounter -= Time.deltaTime;
                        Fly = true;
                    }
                    else
                    {
                        isJumping = false;
                        Fly = false;
                    }
                }
                else if (touch.phase == TouchPhase.Ended)
                {
                    Debug.Log("Lifted");
                    isJumping = false;
                    Fly = false;
                }
                if (isGrounded == true && touch.phase == TouchPhase.Began)
                {
                    isJumping = true;
                    Fly = true;
                    transform.Translate(Vector2.right * speed * Time.deltaTime);
                    jumpTimeCounter = jumpTime;
                    rb.velocity = Vector2.up * jumpForce;
                }
            }


            if (isGrounded == true)
            {
                playerAnimation.SetBool("isJumping", false);
            }
            if (isGrounded == false)
            {
                playerAnimation.SetBool("isJumping", true);
            }
        }
    }
}
