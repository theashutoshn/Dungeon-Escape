using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidEffect : MonoBehaviour
{

    public void Start()
    {
        Destroy(this.gameObject, 5.0f);
    }
    public void Update()
    {
        transform.Translate(Vector3.right * 3 * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="Player")
        {
            IDamageable hit = other.GetComponent<IDamageable>();

            if(hit != null)
            {
                hit.Damage();
                Destroy(this.gameObject);
            }
        }


    }
}
