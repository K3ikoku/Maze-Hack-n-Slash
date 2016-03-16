using UnityEngine;
using System.Collections;


public class EnemyClass : PrimeCharacterClass
{
    [SerializeField] private float mEHealth;
    [SerializeField] private float mCurrentHealth;
    [SerializeField] private float mWaitTime = 1;
    [SerializeField] private int mEmunity = 0;
    [SerializeField] private float mExp = 10;
    [SerializeField] private float mAttackCooldown = 2;
    private float mStunTime;
    private float mStunDur = 0.5f;
    private float mAttackTimer = 1;
    private string mSelfTag;
    private string mOtherTag;
    private PlayerClass mPlayer;
    private Pathfinding.RichAI mRichAi;

    


    public float Health
    {
        get { return mCurrentHealth; }

        set { mCurrentHealth = value; }
    }    
    


    // Use this for initialization
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
        mEHealth = mHealth;
        mCurrentHealth = mEHealth;
        mPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerClass>();

        mRichAi = GetComponent<Pathfinding.RichAI>();
        

    }

    // Update is called once per frame
    void Update()
    {
        //Sebastian Karlsson
        //Cooldown for Attack
        if (mAttackTimer > 0)
        {
            mAttackTimer -= Time.deltaTime;
        }
        //Stun Duration
        if (mStunTime > 0)
        {
            mStunTime -= Time.deltaTime;
            mAttackTimer = mAttackCooldown;
        }

        //Call script from weapon who is a child object to the player!
        if (mAttackTimer <= 0 && mStunTime <=0)
        {
            mAttackTimer = mAttackCooldown;

            transform.GetComponentInChildren<MeleeAttack>().Attack(10, 1.5f, mSelfTag, mOtherTag);// going to add the player damage here
        }

    }


    void OnCollider(Collision other)
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
        if(mCurrentHealth == Health)
        {
            mRichAi.StartChasing();
        }

        mStunTime = mStunDur;
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
        mPlayer.Experience = mExp;
        Debug.Log("Enemy died giving the player " + mExp);

    }
}
