using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, idamageable {

    public NavMeshAgent nav;
    public GameObject target;
    public int currentHealth;
    public int Maxhealth;
    public int attackDamage = 5;
    public int scoreAdded;
    Scoreholder tim;
	// Use this for initialization
	void Start ()
    {
        tim = FindObjectOfType<Scoreholder>();
        nav = GetComponent<NavMeshAgent>();
        target = FindObjectOfType<Player>().gameObject;
	}

    public bool editor;
	void Update ()
    {
        if(editor)
        {
            editor = false;
            takedamage(2);
        }
        nav.destination = target.transform.position;
	}
    public void takedamage(int damagetaken)
    {
        currentHealth -= damagetaken;
        die();
    }
    public void die()
    {
        if (currentHealth <= 0)
        {
           tim.score += scoreAdded;
           Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision other)
    {
       idamageable damage = other.gameObject.GetComponent<idamageable>();
        if (damage != null)
        {
            damage.takedamage(attackDamage);
        }
    }
}
