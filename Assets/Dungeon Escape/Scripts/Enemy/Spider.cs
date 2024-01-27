using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDamageable
{
    private Vector3 _currentTarget;
    private SpriteRenderer _spiderSprite;
    private Animator _spiderAnim;

    public int Health { get; set; }

    public void Damage()
    {

    }
    public void Start()
    {
        _spiderSprite = GetComponentInChildren<SpriteRenderer>();
        _spiderAnim = GetComponentInChildren<Animator>();
    }

    public override void Update()
    {
        // this is not working, need to solve the error
        if (_spiderAnim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            return;
        }



        Movement();
    }

    void Movement()
    {

        //flipping of sprite
        if (_currentTarget == PointA.position)
        {
            _spiderSprite.flipX = true;
        }
        else if (_currentTarget == PointB.position)
        {
            _spiderSprite.flipX = false;
        }

        //movement of sprite
        if (transform.position == PointA.position)
        {
            _currentTarget = PointB.position;
            _spiderAnim.SetTrigger("Idle");
        }
        else if (transform.position == PointB.position)
        {
            _currentTarget = PointA.position;
            _spiderAnim.SetTrigger("Idle");
        }

        transform.position = Vector3.MoveTowards(transform.position, _currentTarget, speed * Time.deltaTime);
    }
}
