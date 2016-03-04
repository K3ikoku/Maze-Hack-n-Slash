using UnityEngine;
using System.Collections;

public class EnemyClass : PrimeCharacterClass
{
    [SerializeField] private float mEHealth;
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
    {
        mEHealth = mHealth;
        mCurrentHealth = mEHealth;
        mPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerClass>();
        

    }

    // Update is called once per frame
    void Update()
    {

	    
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
