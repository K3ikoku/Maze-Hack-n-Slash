using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerClass : PrimeCharacterClass
{
    // Sebastian Karlsson
    [SerializeField] private float mExpToLevelUp = 100f;
    [SerializeField] private float mExperience;
    [SerializeField] private float mCurrentHealth;
    [SerializeField] private float mLevel;
    [SerializeField] private Text mLvlText;
    [SerializeField] private float mFlashSpeed;
    [SerializeField] private float mBaseDamage;
    [SerializeField] private float mAttackCooldown = 0.5f;
    [SerializeField] private Image mDamageImage;


    private float mDmgBuff;
    private float mHpBuff;
    private AudioSource mAudio;
    private bool mLevelUp = false;
    private Color mLvlUpColor = new Color(255f, 255f, 255f, 200f);
    private float mAttackTimer=1;
    private string mSelfTag;
    private string mOtherTag;
    private bool mIsAttacking;
    private bool mDamaged;

    public float MovementSpeed
    {
        get { return mMovementSpeed; }
        set { mMovementSpeed = value; }
    }

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
        get { return mBaseDamage; }

        private set { mBaseDamage = value; }
    }

    public float Level
    {
        get { return mLevel; }
        private set { mLevel += value; }
    }

    void Awake()
    {
        //Sebastian
        mSelfTag = gameObject.transform.tag;

        if (mSelfTag == "Player")
        {
            mOtherTag = "Enemy";
        }
        else if (mSelfTag == "Enemy")
        {
            mOtherTag = "Player";
        }
        // end Sebastian

        MaxHealth = mHealth;
        mBaseDamage = mDamage;
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
        ////Debug key for adding experience
        //if (Input.GetMouseButtonDown(1))
        //{
        //    Experience = 20;
        //}
        //Check if the player has gained enough experience to level up
        if (Experience >= ExpToLevelUp)
        {
            LevelUp();
        }

        //Check if leveled up and show the text in the level up text in the middle of the screen
        if (mLevelUp)
        {
            mLvlText.color = mLvlUpColor;
        }
        else
        {
            mLvlText.color = Color.Lerp(mLvlText.color, Color.clear, mFlashSpeed * Time.deltaTime);
        }
        mLevelUp = false;

        //Sebastian Karlsson
        //Cooldown for Attack
        if (mAttackTimer > 0)
        {
            mAttackTimer -= Time.deltaTime;
            
        }
        //Call script from weapon who is a child object to the player!
        if (Input.GetKey(KeyCode.F) && mAttackTimer <= 0)
        {
            mAttackTimer = mAttackCooldown;
            
            transform.GetComponentInChildren<MeleeAttack>().Attack((Damage * 1.25f) , 1.5f , mSelfTag, mOtherTag);// going to add the player damage here
        }

        // If the player takes damage flash the red color over the screen
        if(mDamaged)
        {
            mDamageImage.color = new Color(1f, 0f, 0f, 0.1f);
        }
        else
        {
            mDamageImage.color = Color.Lerp(mDamageImage.color, Color.clear, 0.5f * Time.deltaTime);
        }
        mDamaged = false;


    }
    // Gustaf Wall
    public override void TakeDamage(float damage) // Override parents Take damage function
    {
        base.TakeDamage(damage);

        mDamaged = true;

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

    void LevelUp()
    {
        mLevelUp = true;
        mExperience -= mExpToLevelUp; //Remove the exp to level up from the experience variable
        ExpToLevelUp = 0; //Increase the amount of exp needed to level up
        Level = 1; //Increment the players level with one
        mCurrentHealth = mHealth;
        CalculateStats();  
    }

    void CalculateStats()
    {
        //Calculate how much to increment stats based on level and add them to the variables
        mDmgBuff = 2;
        mHpBuff = 5;
        
               
        Damage += mDmgBuff;
        MaxHealth += mHpBuff;
        CurrentHealth += mHpBuff;
        Debug.Log(Level + " " + Damage + " " + MaxHealth);
    }
}
