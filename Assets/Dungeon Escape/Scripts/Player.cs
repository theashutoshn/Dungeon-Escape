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

    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        if(Input.GetKeyDown(KeyCode.Space) && _grounded == true)
        {
            _rb2d.velocity = new Vector2(_rb2d.velocity.x, _jumpForce);
            _grounded = false;
        }

        
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.8f, _groundLayer.value);

        Debug.DrawRay(transform.position, Vector2.down * 0.8f, Color.green);

        if (hit.collider != null)
        {
            Debug.Log("Hit: " + hit.collider.name);
            _grounded = true;
        }



        _rb2d.velocity = new Vector2(horizontalInput, _rb2d.velocity.y);

    }
}
