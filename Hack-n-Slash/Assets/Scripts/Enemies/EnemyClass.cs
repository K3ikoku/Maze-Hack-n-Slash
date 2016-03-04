using UnityEngine;
using System.Collections;

public class EnemyClass : PrimeCharacterClass
{
    [SerializeField] private float mEHealth;
    [SerializeField] protected float mCurrentHealth;

    public float Health
    {
        get { return mCurrentHealth; }

        set { mCurrentHealth = value; }
    }

=======
    [SerializeField] private float mCurrentHealth;
    [SerializeField] private float mExp = 10;
>>>>>>> 16885fcd65c402b8d2e2c0c0167add0ed953351d

    private PlayerClass mPlayer;

    // Use this for initialization
    void Awake()
    {
        mEHealth = mHealth;
        mCurrentHealth = mEHealth;
        mPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerClass>();
        

    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
	    
	}
=======
        if (Input.GetMouseButtonDown(0))
        {
            TakeDamage(10);
        }
    }
>>>>>>> 16885fcd65c402b8d2e2c0c0167add0ed953351d

    //Take damage funktion called from objects causing damage
    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);

        Debug.Log("The enemy took " + damage + " damage");


        mCurrentHealth -= damage; //Subtract the damage dealt from the current health

        if (mCurrentHealth <= 0) //Check if current health is 0 or less and run Death function if true
        {
            Debug.Log("Enemy died");
            Death();
        }
    }

    // Johan Jansson
    public override void Death()
    {
        GameObject.Destroy(gameObject);
        mPlayer.mExperience += mExp;
        Debug.Log("Enemy died giving the player " + mExp + " and now has a total of " + mPlayer.mExperience);

    }
}
