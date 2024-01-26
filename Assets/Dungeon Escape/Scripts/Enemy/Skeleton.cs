using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy
{

    private Vector3 _currentTarget;
    private SpriteRenderer _skeletonSprite;
    private Animator _skeletonAnim;

    public void Start()
    {
        _skeletonSprite = GetComponentInChildren<SpriteRenderer>();
        _skeletonAnim = GetComponentInChildren<Animator>();
    }

    public override void Update()
    {

        // this is not working, need to solve the error
        if (_skeletonAnim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
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
            _skeletonSprite.flipX = true;
        }
        else if (_currentTarget == PointB.position)
        {
            _skeletonSprite.flipX = false;
        }

        //movement of sprite
        if (transform.position == PointA.position)
        {
            _currentTarget = PointB.position;
            _skeletonAnim.SetTrigger("Idle");
        }
        else if (transform.position == PointB.position)
        {
            _currentTarget = PointA.position;
            _skeletonAnim.SetTrigger("Idle");
        }

        transform.position = Vector3.MoveTowards(transform.position, _currentTarget, speed * Time.deltaTime);
    }
}
