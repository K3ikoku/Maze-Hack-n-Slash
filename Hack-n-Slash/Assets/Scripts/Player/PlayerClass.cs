using UnityEngine;
using System.Collections;

public class PlayerClass : PrimeCharacterClass
{
    // Sebastian Karlsson
    [SerializeField] private float mExpToLevelUp = 100f;
    [SerializeField] private float mExperience;
    [SerializeField] private float mCurrentHealth;

    public float Experience
    {
        get { return mExperience; }

        set { mExperience = value; }
    }
    
    public float ExpToLevelUp
    {
        get { return mExpToLevelUp; }

        private set { mExpToLevelUp += 200f; }
    }   

    public float MaxHealth
    {
        get { return mHealth; }

        private set { mHealth = value; }
    }

    public float CurrentHealth
    {
        get { return mCurrentHealth; }

        set { mCurrentHealth = value; }
    }

    public float Damage
    {
        get { return mDamage; }

        private set { mDamage = value; }
    }

    


    private AudioSource mAudio;

    void Awake()
    {
        MaxHealth = mHealth;
        CurrentHealth = MaxHealth;
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
        if(CurrentHealth >= MaxHealth)
        {
            CurrentHealth = MaxHealth;
        }

        if(Input.GetMouseButtonDown(1))
        {
            TakeDamage(Damage);
        }

        ExpToLevelUp = 0f;
        Debug.Log(ExpToLevelUp);
	
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
