using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour {

    public int attackDamage = 25;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "enemy")
        {
            idamageable damage = other.GetComponent<idamageable>();
            if (damage != null)
            {
                damage.takedamage(attackDamage);
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            idamageable damage = collision.gameObject.GetComponent<idamageable>();
            if (damage != null)
            {
                damage.takedamage(attackDamage);
            }
        }
    }
}
