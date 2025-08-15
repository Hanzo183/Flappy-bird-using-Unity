using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private int spriteIndex;
    public float flapForce = 5f;
    private Rigidbody2D rb;

    
    private GameManager gameManager;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();

      
        gameManager = FindObjectOfType<GameManager>();
    }

    
    private void OnEnable()
    {
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;

        
        CancelInvoke(nameof(AnimateSprite));
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
    }

   
    private void OnDisable()
    {
       
        CancelInvoke(nameof(AnimateSprite));
    }

    public void OnJump(InputValue value)
    {
    
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, flapForce);
    }

    private void AnimateSprite()
    {
        spriteIndex++;

        if (spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }

        spriteRenderer.sprite = sprites[spriteIndex];
    }

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            gameManager.GameOver();
        }
        else if (other.gameObject.tag == "Score")
        {
            gameManager.IncreaseScore();
        }
    }
}
