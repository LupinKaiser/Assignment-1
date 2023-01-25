using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpSpeed = 8f;
    private float direction = 0f;
    private Rigidbody2D player;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool isTouchingGround;

    private Animator playerAnimator;
    //public GameObject deathEffect;
    public int maxHealth = 3;
    public float currentHealth;
    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        direction = Input.GetAxis("Horizontal");

        if (direction > 0f)
        {
            player.velocity = new Vector2(direction * speed, player.velocity.y);
        }
        else if (direction < 0f)
        {
            player.velocity = new Vector2(direction * speed, player.velocity.y);
        }
        else
        {
            player.velocity = new Vector2(0, player.velocity.y);
        }

        if (Input.GetButtonDown("Jump") && isTouchingGround)
        {
            player.velocity = new Vector2(player.velocity.x, jumpSpeed);
        }

        playerAnimator.SetFloat("Speed", Mathf.Abs(player.velocity.x));
        playerAnimator.SetBool("OnGround", isTouchingGround);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Win")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (collision.tag == "Space")
        {
            //SceneManager.LoadScene("Fail");
        }
        if (collision.tag == "Enemy")
        {
            currentHealth = currentHealth - 1;
            healthBar.setHealth(currentHealth);
            FindObjectOfType<AudioManager>().Play("PlayerHit");
            if(currentHealth <= 0)
            {
                SceneManager.LoadScene("Fail");
            }

        }
        if (collision.tag == "Void")
        {
           //SceneManager.LoadScene("Fail");
        }
    }

}
