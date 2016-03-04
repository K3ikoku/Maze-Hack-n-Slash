﻿using UnityEngine;
using System.Collections;

public class EnemyClass : PrimeCharacterClass
{
    [SerializeField] private float mEHealth;
<<<<<<< HEAD
    [SerializeField] private float mCurrentHealth;
    [SerializeField] private float mWaitTime = 1;
    [SerializeField] private int mEmunity = 0;

    // Use this for initialization
    void Awake ()
=======
    [SerializeField] protected float mCurrentHealth;
    [SerializeField] private float mExp = 10;


    public float Health
    {
        get { return mCurrentHealth; }

        set { mCurrentHealth = value; }
    }    
    

    private PlayerClass mPlayer;

    // Use this for initialization
    void Awake()
>>>>>>> 338bd91941b5606f26635fbf84d41bc05a579a47
    {
        mEHealth = mHealth;
        mCurrentHealth = mEHealth;
        mPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerClass>();
        

    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
	    if(Input.GetMouseButtonDown(0))
        {
            TakeDamage(20);
        }
	}


    void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Player" /*&& mEmunity == 0*/)
        {
            PlayerClass mPlayer = other.transform.GetComponent<PlayerClass>();

            mPlayer.TakeDamage(10);
        }
    }


=======

	    
	}

      
>>>>>>> 338bd91941b5606f26635fbf84d41bc05a579a47
    //Take damage funktion called from objects causing damage
    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        //mEmunity = 1;
        Debug.Log("The enemy took " + damage + " damage");
        //mWaitTime = Time.deltaTime;
        //mEmunity = 0;

        mCurrentHealth -= damage; //Subtract the damage dealt from the current health

        if (mCurrentHealth <= 0) //Check if current health is 0 or less and run Death function if true
        {
            Debug.Log("Enemy died");
<<<<<<< HEAD
            //Death();
            Destroy(gameObject);
        }    
=======
            Death();
        }
    }

    // Johan Jansson
    public override void Death()
    {
        GameObject.Destroy(gameObject);
        mPlayer.mExperience += mExp;
        Debug.Log("Enemy died giving the player " + mExp + " and now has a total of " + mPlayer.mExperience);

>>>>>>> 338bd91941b5606f26635fbf84d41bc05a579a47
    }
}
