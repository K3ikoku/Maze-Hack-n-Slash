using UnityEngine;
using System.Collections;

public class MeleeAttack : MonoBehaviour {
    GameObject Target;
    [SerializeField] private float mAttackCooldown = 1;
    [SerializeField] private float mAttackRange = 2.5f;
    [Range(-1f, 1f)] [SerializeField] private float mAttackArc;
    private string mSelfTag;
    private string mOtherTag;
    private float mMeleeRange = 1.5f;
    private float mMeleeDamage = 15;    
    private float mAttackTimer = 0;

    public void Attack ()
    {
        AttackMelee();

    }

    

    // Use this for initialization
    void Awake ()
    {
        
        mSelfTag = gameObject.transform.parent.tag;

        if (mSelfTag == "Player")
        {
            mOtherTag = "Enemy";
        }
        else if (mSelfTag == "Enemy")
        {
            mOtherTag = "Player";
        }

        
        Debug.Log("my tag is "+mSelfTag+" other tag is "+mOtherTag);

    }
	
	// Update is called once per frame
	void Update ()
    {

        if (mAttackTimer > 0)
        {
            mAttackTimer -= Time.deltaTime;
        }


       
        //if(Input.GetKey(KeyCode.F) && mAttackTimer <= 0)
        //{
            
        //    AttackMelee();
        //}
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, mMeleeRange);
    }

    protected void AttackMelee()
    {
        mAttackTimer = mAttackCooldown;
        Collider[] colliders = Physics.OverlapSphere(transform.position, mMeleeRange);

        foreach (Collider hit in colliders)
        {
         

            if (hit.transform.tag == mOtherTag)
            {
                float distance = Vector3.Distance(hit.transform.position, transform.position);
                Vector3 dir = (hit.transform.position - transform.position).normalized;
                float direction = Vector3.Dot(dir, transform.forward);                
                    if (distance < mAttackRange && direction > mAttackArc)
                    {
                        EnemyClass mEnemy = hit.transform.GetComponent<EnemyClass>();
                        mEnemy.TakeDamage(mMeleeDamage);
                    }

            }
         } 
    }

}
