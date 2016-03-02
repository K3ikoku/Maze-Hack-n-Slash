using UnityEngine;
using System.Collections;

// Gustaf Wall

public class Movement : MonoBehaviour
{

    [SerializeField] private float mMoveSpeed;

    private Rigidbody mPlayerRigidbody;
    private Animator mAnim;
    private AudioSource mAudio;
    
    private float mCamRayLength = 100f;
    private float mMoveH;
    private float mMoveV;
    private int mFloorMask;
    private Ray mCamRay;
    private RaycastHit mFloorHit;
    private Vector3 mPlayerToMouse;
    private Vector3 mMovement;
    private Quaternion mNewRot;

    

    void Awake()
    {
        //Find all the needed components of the player
        mFloorMask = LayerMask.GetMask("Floor");
        mPlayerRigidbody = GetComponent<Rigidbody>();
        mAnim = GetComponent<Animator>();
        mAudio = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        // Get the axis inputs for moving the character around
        mMoveH = Input.GetAxisRaw("Horizontal");
        mMoveV = Input.GetAxisRaw("Vertical");

        //Activate functions for moving and turning the characters aswell as animations and sound
        Turning();
        Move(mMoveH, mMoveV);
        Animating(mMoveH, mMoveV);
        PlayAudio();
    }

    void Turning()
    {

        mCamRay = Camera.main.ScreenPointToRay(Input.mousePosition); //Define so the raycast goes from main camera to mouse position on screen
        if(Physics.Raycast (mCamRay, out mFloorHit, mCamRayLength, mFloorMask)) //Check if raycast hits the ground
        {
           
            mPlayerToMouse = mFloorHit.point - transform.position; //Define the position of the mouse
            mPlayerToMouse.y = 0f; //Freeze the y axis of the position

            //Give the player a new rotation based on the position of the mouse
            mNewRot = Quaternion.LookRotation(mPlayerToMouse);
            mPlayerRigidbody.MoveRotation(mNewRot);

        }
    }

    void Move(float h, float v)
    {
        //Set the movement variable to match the inputs of the WASD keys and move the player accordingly
        mMovement.Set(h, 0f, v);
        mMovement = mMovement.normalized * mMoveSpeed * Time.deltaTime;

        mPlayerRigidbody.MovePosition(transform.position + mMovement);

    }

    void Animating(float h, float v)
    {
        //Check if the player is moving and set it to true if it is and call the animator
        bool mRunning = h != 0f || v != 0f; 
        //mAnim.SetBool("IsRunning", mRunning);
    }

    void PlayAudio()
    {
        //Add code for later auido for running
    }
}
