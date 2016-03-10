using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {
    float mDamage;
    string mTarget;
    


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
                Enemy.TakeDamage(mDamage);
                DestroyObject(gameObject);
            }
            if (mTarget == "Player")
            {
                var Player = other.transform.GetComponent<PlayerClass>();
                Player.TakeDamage(mDamage);
                DestroyObject(gameObject);

            }
            
            
            Debug.Log("Damage is " + mDamage + " and Target is " + mTarget);
        }
        else
        {
            GameObject.Destroy(gameObject);
        }




    }


	// Update is called once per frame
	void Update ()
    {
	    


	}
}
