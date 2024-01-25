using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy
{
    private bool _switch = false;
    private Vector3 _currentTarget;
    private SpriteRenderer _mossSprite;
    private Animator _mossAnim;
    
   public void Start()
    {
        _mossSprite = GetComponentInChildren<SpriteRenderer>();
        _mossAnim = GetComponentInChildren<Animator>();
    }

    public override void Update()
    {
        if(_mossAnim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            Debug.Log("Idle ANiamtion Stop");
            return;
        }
        Movement();
    }

    void Movement()
    {
        if (transform.position == PointA.position)
        {
            _currentTarget = PointB.position;
            _mossSprite.flipX = false;
        }
        else if (transform.position == PointB.position)
        {
            _currentTarget = PointA.position;
            _mossSprite.flipX = true;
        }

        transform.position = Vector3.MoveTowards(transform.position, _currentTarget, speed * Time.deltaTime);
    }
}
