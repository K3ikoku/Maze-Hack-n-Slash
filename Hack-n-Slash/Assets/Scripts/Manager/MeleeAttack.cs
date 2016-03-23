using UnityEngine;
using System.Collections;

public class MeleeAttack : MonoBehaviour {
    GameObject Target;
    //[SerializeField] private float mAttackCooldown = 1;
    [SerializeField] private float mAttackRange = 2.5f;
    [Range(-1f, 1f)] [SerializeField] private float mAttackArc;
    private string mSelfTag;
    private string mOtherTag;
    private float mMeleeRange = 1.5f;
    private float mMeleeDamage;
    private int mChance; 
    //private float mAttackTimer = 0;

    public void Attack (float damage, float range, string self, string other)
    {        
        mMeleeDamage = damage;
        mMeleeRange = range;
        mSelfTag = self;
        mOtherTag = other;
        AttackMelee();
    }

    

    // Use this for initialization
    void Awake ()
    {
        
    }
	
	// Update is called once per frame
	void Update ()
    {

       
        
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, mMeleeRange);
    }

    protected void AttackMelee()
    {
        //Debug.Log("my tag is " + mSelfTag + " other tag is " + mOtherTag);
        Collider[] colliders = Physics.OverlapSphere(transform.position, mMeleeRange);
        

        foreach (Collider hit in colliders)
        {

            if (hit.transform.tag == mOtherTag)
            {
                float distance = Vector3.Distance(hit.transform.position, transform.position);
                Vector3 dir = (hit.transform.position - transform.position).normalized;
                float direction = Vector3.Dot(dir, transform.forward);
               
                if (distance < mAttackRange && direction > mAttackArc && mOtherTag == "Enemy")
                    {
                        mChance = Random.Range(3, 5);
                        EnemyClass mEnemy = hit.transform.GetComponentInParent<EnemyClass>();
                        mEnemy.TakeDamage(mMeleeDamage, mChance);
                        Debug.Log("numbers i got is "+mChance);
                        
                    }
                if (distance < mAttackRange && direction > mAttackArc && mOtherTag == "Player")
                {
                    PlayerClass mEnemy = hit.transform.GetComponentInParent<PlayerClass>();
                    mEnemy.TakeDamage(mMeleeDamage, 0);

                }
            }
         } 
    }

}
