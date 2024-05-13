using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    protected Transform pointA, pointB;

    protected Vector3 currentTarget;
    protected Animator animator;
    protected SpriteRenderer spriteRenderer;

    public virtual void Init()
    {
        animator = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    public void Start()
    {
        Init();
    }



    public virtual void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            Debug.Log("Animation State");
            return;
        }

        Movement();
    }

    public virtual void Movement()
    {
        float move = speed * Time.deltaTime;

        if (transform.position == pointA.position)
        {
            currentTarget = pointB.position;
            //_animator.SetTrigger("Idle");
            spriteRenderer.flipX = false;


        }
        else if (transform.position == pointB.position)
        {
            currentTarget = pointA.position;
            //_animator.SetTrigger("Idle");
            spriteRenderer.flipX = true;

        }

        transform.position = Vector3.MoveTowards(transform.position, currentTarget, move);

    }

   

}
