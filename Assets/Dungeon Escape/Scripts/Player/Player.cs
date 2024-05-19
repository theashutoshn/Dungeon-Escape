using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    private Rigidbody2D _rb2d;
    private float _jumpForce = 7f;
    [SerializeField]
    private bool _grounded = false;
    [SerializeField]
    private LayerMask _groundLayer;
    private bool _resetJump = false;
    [SerializeField]
    private float _playerSpeed = 2.5f;
    private PlayerAnimation _playerAnim;
    private SpriteRenderer _playerSprite;
    private SpriteRenderer _swordAnimSprite;

    public int Health 
    {
        get; set;
    }



    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _playerAnim = GetComponentInChildren<PlayerAnimation>();
        _playerSprite = GetComponentInChildren<SpriteRenderer>();
        _swordAnimSprite = transform.GetChild(1).GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        CheckGround();
        Attack();

    }

   void Movement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        Flip(horizontalInput);

        if (Input.GetKeyDown(KeyCode.Space) && _grounded == true)
        {
            _rb2d.velocity = new Vector2(_rb2d.velocity.x, _jumpForce);
            _grounded = false;
            _resetJump = true;
            StartCoroutine(ResetJumpRoutine());
            _playerAnim.Jumping(true);
        }

        _rb2d.velocity = new Vector2(horizontalInput * _playerSpeed, _rb2d.velocity.y);

        _playerAnim.Move(horizontalInput);
    }

    void CheckGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1f, _groundLayer.value);

        Debug.DrawRay(transform.position, Vector2.down * 1f, Color.green);

        if (hit.collider != null)
        {
            //Debug.Log("Hit: " + hit.collider.name);

            if (_resetJump == false)
            {
                _playerAnim.Jumping(false);
                _grounded = true;
            }

        }
    }

    void Flip(float horizontalInput)
    {
        //if(horizontalInput > 0)
        // faceright true
        //if(horizontalInput < 0)
        // faceright false

        if(horizontalInput > 0)
        {
            _playerSprite.flipX = false;
            _swordAnimSprite.flipY = false;

            // Need to understand this more ///
            /* Vector3 newPos = _swordAnimSprite.transform.localPosition;
            newPos.x = 1.01f;
            _swordAnimSprite.transform.localPosition = newPos;
            */
        }
        else if (horizontalInput < 0)
        {
            _playerSprite.flipX = true;
            _swordAnimSprite.flipY = true;

           /* Vector3 newPos = _swordAnimSprite.transform.localPosition;
            newPos.x = -1.01f;
            _swordAnimSprite.transform.localPosition = newPos;
           */
        }
    }

    IEnumerator ResetJumpRoutine()
    {
        yield return new WaitForSeconds(0.1f);
        _resetJump = false;
    }

    void Attack()
    {
        if (Input.GetMouseButtonDown(0) && _grounded == true)
        {
            _playerAnim.PlayerAttack();

        }
    }

    public void Damage()
    {
        
        
    }
}
