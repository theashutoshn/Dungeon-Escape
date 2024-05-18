using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy, IDamageable
{
    public int Health { get; set; }


    // Use for initilization
    public override void Init()
    {
        base.Init();
        Health = base.health;
        
    }

    public override void Movement()
    {
        base.Movement();

        Vector3 Direction = player.transform.position - transform.position;

        if (Direction.x > 0 && animator.GetBool("InCombat") == true)
        {
            spriteRenderer.flipX = false;
        }
        else if (Direction.x < 0 && animator.GetBool("InCombat") == true)
        {
            spriteRenderer.flipX = true;
        }
    }
    public void Damage()
    {
        Health -= 1;
        animator.SetTrigger("Hit");
        isHit = true;
        animator.SetBool("InCombat", true);
        if (Health < 1)
        {
            Destroy(this.gameObject);
        }
        
    }










    // private bool _switch;

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












