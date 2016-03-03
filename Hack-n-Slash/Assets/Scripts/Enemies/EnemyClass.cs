﻿using UnityEngine;
using System.Collections;

public class EnemyClass : PrimeCharacterClass
{
    [SerializeField] private float mEHealth;
    [SerializeField] private float mCurrentHealth;

	// Use this for initialization
	void Awake ()
    {
        mEHealth = mHealth;
        mCurrentHealth = mEHealth;
        	
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(Input.GetMouseButtonDown(0))
        {
            TakeDamage(10);
        }
	}

    //Take damage funktion called from objects causing damage
    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);

        Debug.Log("The enemy took " + damage + " damage");


        mCurrentHealth -= damage; //Subtract the damage dealt from the current health

        if (mCurrentHealth <= 0) //Check if current health is 0 or less and run Death function if true
        {
            Debug.Log("Enemy died");
            //Death();
        }    
    }
}
