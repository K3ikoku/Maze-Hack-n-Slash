using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour
{
    float mDamage;
    string mTarget;
    private float mTimer = 0;
    
    
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

    void FixedUpdate()
    {

    }

    //Update is called once per frame
    void Update()
    {

        if (mTimer >= 0.5f)
        {
            GameObject.Destroy(gameObject);

        }
        else
        {
            mTimer += Time.deltaTime;
        }



    }
}
