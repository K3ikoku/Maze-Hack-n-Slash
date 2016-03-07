using UnityEngine;
using System.Collections;

public class EnemyClass : PrimeCharacterClass
{
    [SerializeField] private float mEHealth;
    [SerializeField] private float mCurrentHealth;
    [SerializeField] private float mWaitTime = 1;
    [SerializeField] private int mEmunity = 0;
    [SerializeField] private float mExp = 10;

    private PlayerClass mPlayer;



    public float Health
    {
        get { return mCurrentHealth; }

        set { mCurrentHealth = value; }
    }    
    


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
