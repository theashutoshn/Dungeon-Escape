using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy, IDamageable
{

    private Vector3 _currentTarget;
    private SpriteRenderer _skeletonSprite;
    private Animator _skeletonAnim;
    private Player _player;
    public int Health { get; set; }


    //--------------------------------------------//
    public void Start()
    {
        _skeletonSprite = GetComponentInChildren<SpriteRenderer>();
        _skeletonAnim = GetComponentInChildren<Animator>();
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        //assign health property to our enemy health
        Health = base.health;
    }


    public void Damage()
    {
        Debug.Log("Damage");
        _skeletonAnim.SetTrigger("Hit");
        isHit = true;
        _skeletonAnim.SetBool("InCombat", true);


        

        // substract 1 from health
        Health -= 1;
        
        // if health is less then 1
        if(Health < 1)
        {
            // destroy the object+
            Destroy(this.gameObject);
        }
       

    }

    public override void Update()
    {

        // this is not working, need to solve the error
        if (_skeletonAnim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            return;
        }

        Movement();
        CheckDistance();


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

        
        

        if (isHit == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, _currentTarget, speed * Time.deltaTime);
        }
        

    }

    private void CheckDistance()
    {
        float distance = Vector3.Distance(transform.localPosition, _player.transform.localPosition);
        Debug.Log("Distance" + distance);
        if(distance > 1f)
        {
            isHit = false;
            _skeletonAnim.SetBool("InCombat", false);
        }
        else
        {
            isHit = true;
            _skeletonAnim.SetBool("InCombat", true);
        }
    }
    
}
