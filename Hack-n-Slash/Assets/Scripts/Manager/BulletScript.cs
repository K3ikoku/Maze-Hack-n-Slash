using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour
{
    private float mDamage;
    private string mTarget;
    private int mChance = Random.Range(0, 5);
    
    
	// Use this for initialization
	public void Startlate (float damage, string target)
    {
        mTarget = target;
        mDamage = damage;

        

	}
    void OnCollisionEnter (Collision other)
    {
        

       if (other.transform.tag == mTarget)
        {
            
            if (mTarget == "Enemy")
            {
                var Enemy = other.transform.GetComponentInParent<EnemyClass>();
                Enemy.TakeDamage(mDamage,mChance);
                DestroyObject(gameObject);
            }
            if (mTarget == "Player")
            {
                var Player = other.transform.GetComponent<PlayerClass>();
                Player.TakeDamage(mDamage,0);
                DestroyObject(gameObject);

            }
            
            
            Debug.Log("Damage is " + mDamage + " and Target is " + mTarget);
        }

        else
        {
           GameObject.Destroy(gameObject);
        }
    }

}
