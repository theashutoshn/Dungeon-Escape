using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField]
    protected int health;
    [SerializeField]
    protected int speed;
    [SerializeField]
    protected int gems;
    [SerializeField]
    protected Transform PointA, PointB;

    protected bool isHit = false;

    // varibale to store player distance
    protected Player player;

    public virtual  void Update()
    {
        // check distance between payer and enemy if > 2 then IsHit = false and Incomat = false

        



    
    }


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }


    

}



