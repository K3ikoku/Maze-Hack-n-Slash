using UnityEngine;
using System.Collections;

public class PlayerClass : PrimeCharacterClass
{
    [SerializeField] private float mCurrentHealth;

    void Awake()
    {
        mCurrentHealth = mHealth;
    }

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(mCurrentHealth >= mHealth)
        {
            mCurrentHealth = mHealth;
        }

        if(Input.GetMouseButtonDown(1))
        {
            TakeDamage(10);
        }
	
	}

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);

        Debug.Log("The player took " + damage + " damage");
        mCurrentHealth -= damage;

        if(mCurrentHealth <= 0)
        {
            Debug.Log("Player died");
            //Death();
        }
    }
}
