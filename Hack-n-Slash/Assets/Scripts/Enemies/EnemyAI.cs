using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour
{
    public float playerDist;
    public float enemyLookDist;
    public float attackDist;
    public float enemyMoveSpeed;
    public float damping;
    public Transform playerTarget;
    Rigidbody theRidgidBody;
    Renderer myRender;





    // Use this for initialization
    void Start()
    {
        myRender = GetComponent<Renderer>();
        theRidgidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        playerDist = Vector3.Distance(playerTarget.position, transform.position);

        if(playerDist < enemyLookDist)
        {
            myRender.material.color = Color.yellow;
            lookAtPlayer();
        }

        if(playerDist < attackDist)
        {
            myRender.material.color = Color.red;
            attackPlayer();
            print("Attck!");
        }
        else
        {
            myRender.material.color = Color.blue;
        }
    }

    void lookAtPlayer()
    {
        Quaternion rotation = Quaternion.LookRotation(playerTarget.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
    }

    void attackPlayer()
    {
        theRidgidBody.AddForce(transform.forward * enemyMoveSpeed);
    }
}
