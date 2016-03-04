using UnityEngine;
using System.Collections;

public class PrimeCharacterClass : MonoBehaviour
{

    [SerializeField]protected float mHealth = 100;
    [SerializeField]protected float mDamage = 20;
    [SerializeField]protected float mMovementSpeed = 6;



    public virtual void TakeDamage(float damage)
    {
    }
}
