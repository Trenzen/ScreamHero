using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerBounce : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float jumpForce;
    [SerializeField] private Button PlayButton;
    [SerializeField] private Text highScoreRef;
    // Start is called before the first frame update
    private void Awake()
    {
        highScoreRef.text = "High Score: " + PlayerPrefs.GetInt("HighScoreKeeper", 0).ToString();
        PlayButton.onClick.AddListener(LetsPlay);
    }
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    void LetsPlay()
    {
        SceneManager.LoadScene(1);
    }
}
