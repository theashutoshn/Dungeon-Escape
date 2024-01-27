using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy, IDamageable
{
    
    private Vector3 _currentTarget;
    private SpriteRenderer _mossSprite;
    private Animator _mossAnim;
    
    public int Health { get; set; }

    public void Damage()
    {

    }

   public void Start()
    {
        _mossSprite = GetComponentInChildren<SpriteRenderer>();
        _mossAnim = GetComponentInChildren<Animator>();

    }

    public override void Update()
    {
        // this is not working, need to solve the error
        if (_mossAnim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
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
            _mossSprite.flipX = true;
        }
        else if (_currentTarget == PointB.position)
        {
            _mossSprite.flipX = false;
        }

        //movement of sprite
        if (transform.position == PointA.position)
        {
            _currentTarget = PointB.position;
            _mossAnim.SetTrigger("Idle");         
        }
        else if (transform.position == PointB.position)
        {
            _currentTarget = PointA.position;
            _mossAnim.SetTrigger("Idle");
        }

        transform.position = Vector3.MoveTowards(transform.position, _currentTarget, speed * Time.deltaTime);
    }
}
