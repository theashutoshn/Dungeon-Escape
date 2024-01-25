using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _anim;
    private Animator _swordAnim;
    void Start()
    {
        _anim = GetComponentInChildren<Animator>();
        _swordAnim = transform.GetChild(1).GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move(float move)
    {
        _anim.SetFloat("Move", Mathf.Abs(move));
    }

    public void Jumping(bool jump)
    {
        if(jump == true)
        {
            _anim.SetBool("Jump", true);
        }
        else if (jump == false)
        {
            _anim.SetBool("Jump", false);
        }
    }

    public void PlayerAttack()
    {
        _anim.SetTrigger("Attack");
        _swordAnim.SetTrigger("SwordArc");
    }
}

