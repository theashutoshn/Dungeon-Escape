using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy
{
    private Vector3 _currentTarget;
    // private bool _switch;
    private SpriteRenderer _spriteRenderer;
    private Animator _anim;

    private void Start()
    {
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _anim = GetComponentInChildren<Animator>();
    }

    public override void Update()
    {
        if (_anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            Debug.Log("Animation State");
            return;
        }

        Movement();
    }

    public void Movement()
    {
        


        float move = speed * Time.deltaTime;

        if(transform.position == pointA.position)
        {
            _currentTarget = pointB.position;
            _anim.SetTrigger("Idle");
            _spriteRenderer.flipX = false;
            

        }
        else if (transform.position == pointB.position)
        {
            _currentTarget = pointA.position;
            _anim.SetTrigger("Idle");
            _spriteRenderer.flipX = true;
            
        }

        transform.position = Vector3.MoveTowards(transform.position, _currentTarget, move);


        /* if (transform.position == pointA.position)
        {
            Debug.Log("Point A");
            _switch = false;
            _spriteRenderer.flipX = false;

        }
        else if (transform.position == pointB.position)
        {
            Debug.Log("Point B");
            _switch = true;
            _spriteRenderer.flipX = true;

        }

       if(_switch == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, pointB.position, move);
        }
        else if (_switch == true) 
        {
            transform.position = Vector3.MoveTowards(transform.position, pointA.position, move);

        }
        */
    }
}
