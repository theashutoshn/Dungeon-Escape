using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    // Start is called before the first frame update
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
            hit.Damage();
        }
    }
}
