using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Spider : Enemy, IDamageable
{

    public GameObject acidPrefab;

    public int Health {  get; set; }
    // Use for Initialization
    public override void Init()
    {
        base.Init();
        Health = base.health;
    }

    public override void Update()
    {
        
    }
    public void Damage()
    {
        if (isDead == true)
        {
            return;
        }


        Health -= 1;
        if(Health < 1)
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

    public override void Movement()
    {
       
    }

    public void Attack()
    {
        Instantiate(acidPrefab, transform.position, Quaternion.identity);
    }
}
