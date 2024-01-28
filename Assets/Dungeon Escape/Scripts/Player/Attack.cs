using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private bool _canDamage = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hit:" + other.name);

        IDamageable hit = other.GetComponent<IDamageable>();

        if(hit != null)
        {
            if(_canDamage == true)
            {
                hit.Damage();
                _canDamage = false;
                StartCoroutine(DamageReset());
            }
            
        }
    }

    IEnumerator DamageReset()
    {
        yield return new WaitForSeconds(0.5f);
        _canDamage = true;
    }
}
