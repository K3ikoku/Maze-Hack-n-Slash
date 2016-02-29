using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour

    // Gustaf Wall

{

    [SerializeField] private Transform mTarget;
    [SerializeField] private float mSmoothing = 3;

    Vector3 mOffset;

    void Start()
    {
        //Set the offset of the camera to the standard location above the player
        mOffset = transform.position - mTarget.position;
    }

    void FixedUpdate()
    {
        //Make the camera follow the player and smooth it with a lerp
        Vector3 mTargetCamPos = mTarget.position + mOffset;
        transform.position = Vector3.Lerp(transform.position, mTargetCamPos, mSmoothing * Time.deltaTime);
    }
}
