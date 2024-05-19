using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Skeleton : Enemy, IDamageable

{
    public int Health {  get; set; }
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
        Debug.Log("Damage()");
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

}
