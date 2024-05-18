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

    public void Damage()
    {
        
    }

    public override void Movement()
    {
       
    }

    public void Attack()
    {
        Instantiate(acidPrefab, transform.position, Quaternion.identity);
    }
}
