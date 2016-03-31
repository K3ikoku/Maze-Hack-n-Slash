using UnityEngine;
using System.Collections;


public class EnemyClass : PrimeCharacterClass
{
    [SerializeField] private float mEHealth;
    [SerializeField] private float mCurrentHealth;
    [SerializeField] private float mWaitTime = 1;
    [SerializeField] private float mExp = 10;
    [SerializeField] private float mAttackCooldown = 2;
    [SerializeField] private GameObject mBlood;
    [SerializeField] private float mMaxSpeed;
    [SerializeField] private int mHealtBoost = 25;

    [FMODUnity.EventRef]
    [SerializeField] private string mSoundDie = "event:/EnemyDie";
    public float MaxSpeed
    {
        get { return mMaxSpeed; }
        set { mMaxSpeed = value; }
    }


    private float mStunTime;
    private float mStunDur = 0.5f;
    private float mAttackTimer = 1;
    private string mSelfTag;
    private string mOtherTag;
    private PlayerClass mPlayer;
    private Win_condition mManager;
    private Pathfinding.RichAI mRichAi;

    private Animator mAnim;


    public float Health
    {
        get { return mCurrentHealth; }

        set { mCurrentHealth = value; }
    }    
    


    // Use this for initialization
    void Awake()
    {
        //Sebastian
        var Install = GameObject.FindGameObjectWithTag("Install").GetComponent<Installations>();
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
        mEHealth = mHealth + (Install.Level * mHealtBoost-mHealtBoost);
        mCurrentHealth = mEHealth;
        Debug.Log(mEHealth +" Level is "+ Install.Level);
        mPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerClass>();
        mManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<Win_condition>();
        mRichAi = GetComponent<Pathfinding.RichAI>();
        mManager.EnemiesLeft = 1;
        mAnim = GetComponent<Animator>();

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
        if (mAttackTimer <= 0 && mStunTime <=0 && Vector3.Distance(mPlayer.transform.position, transform.position) < 3.0f)
        {
            mAttackTimer = mAttackCooldown;

            transform.GetComponentInChildren<MeleeAttack>().Attack(10, 1.5f, mSelfTag, mOtherTag);// going to add the player damage here
            mAnim.SetTrigger("EnemyAttack");
        }

    }


    void OnCollider(Collision other)
    {
        if (other.transform.tag == "Player")
        {
            PlayerClass mPlayer = other.transform.GetComponent<PlayerClass>();

            mPlayer.TakeDamage(10,0);
            mAnim.SetTrigger("EnemyGetHit");
        }
    }


      
    //Take damage funktion called from objects causing damage
    public override void TakeDamage(float damage, int chance)
    {
        Vector3 mBloodPos = transform.position;
        mBloodPos.z += 0.2f;
        Instantiate(mBlood, mBloodPos, transform.rotation);

        if(mCurrentHealth == Health)
        {
            mRichAi.StartChasing();
        }
        if (chance >= 4)
        {
            mStunTime = mStunDur;
            Debug.Log("Stunned");

        }
                
        base.TakeDamage(damage, chance);
        Debug.Log("The enemy took " + damage + " damage"); 
        mCurrentHealth -= damage; //Subtract the damage dealt from the current health

        if (mCurrentHealth <= 0) //Check if current health is 0 or less and run Death function if true
        {
            FMODUnity.RuntimeManager.PlayOneShot(mSoundDie, transform.position);
            mAnim.SetTrigger("EnemyDeath");
            Debug.Log("Enemy died");
            Death();
        }
    }

    // Johan Jansson
    public override void Death()
    {
        mManager.EnemiesLeft = -1;
        mPlayer.Experience = mExp;
        Debug.Log("Enemy died giving the player " + mExp);
        GameObject.Destroy(gameObject);
    }
}
