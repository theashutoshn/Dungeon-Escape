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

    }
    public void Damage()
    {

        if (isDead == true)
        {
            return;
        }


        Health -= 1;
        animator.SetTrigger("Hit");
        isHit = true;
        animator.SetBool("InCombat", true);
        if (Health < 1)
        {
            isDead = true;
            animator.SetTrigger("Death");
            //Destroy(this.gameObject);

            //spawn the diamond
            GameObject diamond = Instantiate(diamondsPrefab, transform.position, Quaternion.identity) as GameObject;

            // change the value of gems value accorfing to moss giant
            diamond.GetComponent<Diamond>().gems = base.gems;
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












