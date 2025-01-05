using UnityEngine;
using System.Collections;

public class PlayerMK1 : MonoBehaviour
{
    /// <summary>
    /// Variables and Components
    /// </summary>


    //Variables
    public float _theGravity = -9.8f; // Gravity force
    public float _theJumpPower = 5f; // Jump force
    private int _TheSpriteIndex = 0; // Current sprite index
    public float _theJumpCooldown = 1f; // Cooldown duration in seconds
    private Vector2 _theDirection; // Movement direction
    private bool _bCanJump = true; // Tracks if the player can jump
    //Components
    public Rigidbody2D _rb2d; // Reference to Rigidbody2D
    private SpriteRenderer _theSpriteRenderer; // SpriteRenderer component
    public Sprite[] theSpritesArr; // Array of sprites for animation


    ///
    // Class Functions
    ///
    void Jump()
    {
        // Apply jump power directly
        _rb2d.linearVelocity = new Vector2(_rb2d.linearVelocity.x, _theJumpPower);

        // Start the jump cooldown
        StartCoroutine(JumpCooldownCoroutine());
    }

    void ApplyGravity()
    {
        if (_rb2d.gravityScale == 0)
        {
            // Apply manual gravity if built-in gravity is disabled
            _rb2d.linearVelocity += new Vector2(0, _theGravity * Time.fixedDeltaTime);
        }
    }

    void AnimateSprite()
    {
        // Cycle through the sprite array for animation
        _TheSpriteIndex = (_TheSpriteIndex + 1) % theSpritesArr.Length;
        _theSpriteRenderer.sprite = theSpritesArr[_TheSpriteIndex];
    }

    IEnumerator JumpCooldownCoroutine()
    {
        _bCanJump = false; // Disable jumping
        yield return new WaitForSeconds(_theJumpCooldown); // Wait for the cooldown duration
        _bCanJump = true; // Re-enable jumping
    }

    /// <summary>
    ///  MonoBehaviour
    /// </summary>


    void Start()
    {
        // Get the SpriteRenderer component
        _theSpriteRenderer = GetComponent<SpriteRenderer>();

        // Start sprite animation loop
        if (theSpritesArr.Length > 0)
        {
            InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
        }
    }

    void Update()
    {
        // Jump input
        if (Input.GetKeyDown(KeyCode.Space) && _bCanJump)
        {
            Jump();
        }
    }

    void FixedUpdate()
    {
        ApplyGravity();
    }


}

