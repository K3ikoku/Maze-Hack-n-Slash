using UnityEngine;
using System.Collections;

public class MovementScript : MonoBehaviour {

    [SerializeField] private float mMoveSpeed;
    [SerializeField] private Rigidbody mPlayerRigidbody;


    private float mCamRayLength = 100f;
    private int mFloorMask;
    private Ray mCamRay;
    private RaycastHit mFloorHit;
    private Vector3 mPlayerToMouse;
    private Vector3 mMovePos;
    Quaternion mNewRot;

    void Awake()
    {
        mFloorMask = LayerMask.GetMask("Floor");
    }

    void FixedUpdate()
    {
        Turning();
        Move();
    }

    void Turning()
    {
        mCamRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast (mCamRay, out mFloorHit, mCamRayLength, mFloorMask))
        {
           
            mPlayerToMouse = mFloorHit.point - transform.position;
            mPlayerToMouse.y = 0f;
            Debug.Log(mPlayerToMouse);

            mNewRot = Quaternion.LookRotation(mPlayerToMouse);
            mPlayerRigidbody.MoveRotation(mNewRot);
            Debug.Log(mNewRot);


            //mMovePos = mFloorHit.point;
            //mMovePos.y = 0f;

            //mMovePos = mMovePos.normalized * mMoveSpeed * Time.deltaTime;

            //mPlayerRigidbody.MovePosition(transform.position + mMovePos);

        }
    }

    void Move()
    {
    }
}
