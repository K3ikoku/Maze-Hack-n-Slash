using UnityEngine;
using System.Collections;

using Pathfinding;

public class AstarAI : MonoBehaviour
{
    public Vector3 mTargetPos;
    private Seeker mSeeker;
    private CharacterController mController;
    public Path mPath;
    public float mSpeed = 100;
    public float mNextWaypointDistance = 3;
    public int mCurrentWaypoint = 0;



	// Use this for initialization
	public void Start ()
    {
        mSeeker = GetComponent<Seeker>();
        mController = GetComponent<CharacterController>();

        mSeeker.StartPath(transform.position, mTargetPos, OnPathComplete);
	}

    public void OnPathComplete ( Path p)
    {
        Debug.Log("Yay, we got a path back. Did it have an error?: " + p.error);

        if(!p.error)
        {
            mPath = p;

            mCurrentWaypoint = 0;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(mPath == null)
        {
            return;
        }

        if(mCurrentWaypoint >= mPath.vectorPath.Count)
        {
            Debug.Log("End of path reached");
            return;
        }

        Vector3 mDir = (mPath.vectorPath[mCurrentWaypoint] - transform.position).normalized;
        mDir *= mSpeed * Time.deltaTime;

        mController.SimpleMove(mDir);

        if(Vector3.Distance(transform.position, mPath.vectorPath[mCurrentWaypoint]) < mNextWaypointDistance)
        {
            mCurrentWaypoint++;
            return;
        }
	
	}
}
