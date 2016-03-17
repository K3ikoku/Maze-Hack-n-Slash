using UnityEngine;
using System.Collections;

public class NavmeshManager : MonoBehaviour
{
    private AstarPath mAstarPath;
	// Use this for initialization
	void Awake ()
    {
        mAstarPath = GetComponent<AstarPath>();
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void CreateNavmesh()
    {
        mAstarPath.Scan();
    }
}
