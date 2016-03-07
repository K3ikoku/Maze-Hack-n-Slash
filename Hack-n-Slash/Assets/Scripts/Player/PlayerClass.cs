﻿using UnityEngine;
using System.Collections;

public class PlayerClass : PrimeCharacterClass
{
    // Sebastian Karlsson
    [SerializeField] public float mExpToLevelUp = 100f;
    [SerializeField] public float mExperience;
    [SerializeField] public float mPlayerHealth;
    [SerializeField] public float mCurrentHealth;


    private AudioSource mAudio;

    void Awake()
    {
        mPlayerHealth = mHealth;
        mCurrentHealth = mPlayerHealth;
        mAudio = GetComponent<AudioSource>();
    }

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        // Gustaf Wall
        // Check if the players HP is higher than the max hp and set it to max hp
        if(mCurrentHealth >= mHealth)
        {
            mCurrentHealth = mHealth;
        }

        if(Input.GetMouseButtonDown(1))
        {
            TakeDamage(10);
        }
	
	}
    // Gustaf Wall
    public override void TakeDamage(float damage) // Override parents Take damage function
    {
        base.TakeDamage(damage);

        Debug.Log("The player took " + damage + " damage"); // Print out amount of damage taken
        mCurrentHealth -= damage;

        // Check if the players hp is larger than 0 and run death script if not
        if(mCurrentHealth <= 0)
        {
            Debug.Log("Player died");
            Death();
        }
    }

    // Johan Jansson
    public override void Death()
    {
        base.Death();
        Debug.Log("Player has died");
        GameObject.Destroy(gameObject);
        Application.Quit(); //Exit game


    }
}
