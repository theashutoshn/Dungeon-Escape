using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rb2d;
    private float _jumpForce = 5f;
    [SerializeField]
    private bool _grounded = false;
    [SerializeField]
    private LayerMask _groundLayer;
    private bool _resetJump = false;
    [SerializeField]
    private float _playerSpeed = 2.5f;
    private PlayerAnimation _playerAnim;

    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _playerAnim = GetComponent<PlayerAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        CheckGround();


    }

   void Movement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && _grounded == true)
        {
            _rb2d.velocity = new Vector2(_rb2d.velocity.x, _jumpForce);
            _grounded = false;
            _resetJump = true;
            StartCoroutine(ResetJumpRoutine());
        }

        _rb2d.velocity = new Vector2(horizontalInput * _playerSpeed, _rb2d.velocity.y);

        _playerAnim.Move(horizontalInput);
    }

    void CheckGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1f, _groundLayer.value);

        // Debug.DrawRay(transform.position, Vector2.down * 1f, Color.green);

        if (hit.collider != null)
        {
            // Debug.Log("Hit: " + hit.collider.name);

            if (_resetJump == false)
            {
                _grounded = true;
            }

        }
    }

    IEnumerator ResetJumpRoutine()
    {
        yield return new WaitForSeconds(0.1f);
        _resetJump = false;
    }

}
