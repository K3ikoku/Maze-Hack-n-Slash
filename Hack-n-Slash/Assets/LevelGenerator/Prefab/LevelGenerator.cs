using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class LevelGenerator : MonoBehaviour {

    //level generation
    [SerializeField] private GameObject[] mTiles;
    [SerializeField] private GameObject mWall;
    //[SerializeField] private GameObject mPlayer;
    [SerializeField] private GameObject mEnemy;
    [SerializeField] private GameObject mExit;
    [SerializeField] private GameObject mNavmesh;

    public List <Vector3> mCreatedTiles;

    [SerializeField] private bool mEnableRandom = false;

    [SerializeField]
    private int mRandomSeed = 1337;
    [SerializeField]
    private int mTileAmount = 40;
    [SerializeField]
    private int mTileSize = 16;

    [SerializeField]
    private float mChanceUp = 0.25f;
    [SerializeField]
    private float mChanceRight = 0.5f;
    [SerializeField]
    private float mChanceLeft = 0.75f;
    [SerializeField]
    private float mWaitTime;

    private NavmeshManager mNavManager;

    //Wall generation
    private float mMinX = 999999;
    private float mMaxX = 0;
    private float mMinZ = 999999;
    private float mMaxZ = 0;
    private float mAmountX;
    private float mAmountZ;
    [SerializeField]
    private float mExtraWallX = 20;
    [SerializeField]
    private float mExtraWallZ = 20;

    //Character generation
    [SerializeField]
    private int mMonsterSpawn = 5;

    void Start()
    {

        StartCoroutine(GenerateLevel());
        if(mEnableRandom == true)
        {
        Random.seed = mRandomSeed;
        }
    }

    void Awake()
    {
        mNavManager = mNavmesh.GetComponent<NavmeshManager>();
    }

    IEnumerator GenerateLevel()
    {

        for(int i = 0; i < mTileAmount; i++)
        
        {
            float dir = Random.Range(0f, 1f);
            int tile = Random.Range(0, mTiles.Length);


            CreateTile(tile);
            CallMoveGen(dir);

            yield return new WaitForSeconds(mWaitTime);

            if(i == mTileAmount - 1)
            {
                Finish();

            }


        }

        yield return 0;
    }

    void CallMoveGen(float ranDir)
    {
        if(ranDir < mChanceUp)
        {
            MoveGen(0);
        }else if(ranDir < mChanceRight)
        {

            MoveGen(1);
        }
        else if (ranDir < mChanceLeft)
        {

            MoveGen(2);
        }else
        {
            MoveGen(3);
        }

    }


    void MoveGen(int dir)
    {
        switch (dir)
        {
            case 0:

                transform.position = new Vector3(transform.position.x, 0 ,transform.position.z + mTileSize);
                break;

            case 1:

                transform.position = new Vector3(transform.position.x + mTileSize,0 ,transform.position.z);
                break;

            case 2:

                transform.position = new Vector3(transform.position.x - mTileSize,0 , transform.position.z);
                break;

            case 3:

                transform.position = new Vector3(transform.position.x,0 , transform.position.z - mTileSize);
                break;
        }

        // Angle method, with Sin and Cos
        /*float angle = dir * Mathf.PI / 2;

        transform.position = new Vector3(
            transform.position.x + Mathf.RoundToInt(Mathf.Cos(angle)) * tileSize, 
            transform.position.y + Mathf.RoundToInt(Mathf.Sin(angle)) * tileSize, 
            0
        );*/

        
    }

    void CreateTile(int tileIndex)
    {
        if (!mCreatedTiles.Contains(transform.position))
        {
            GameObject tileObject;

            tileObject = Instantiate(mTiles[tileIndex], transform.position, transform.rotation) as GameObject;

            mCreatedTiles.Add(tileObject.transform.position);

        }
        else
        {
            mTileAmount++;
        }
        

    }

    void Finish()
    {
        PlaceCharacter();
        CreateWallValues();
        CreateWall();
        mNavManager.CreateNavmesh();

    }

    void PlaceCharacter()
    {

        transform.position = mCreatedTiles[0];
        //    Instantiate(mPlayer, transform.position, transform.rotation);
        transform.position = mCreatedTiles[mCreatedTiles.Count - 1];
        Instantiate(mExit, transform.position, transform.rotation);

        for (int i = 0; i < mMonsterSpawn; i++)
        {
            transform.position = mCreatedTiles[Random.Range(6, mCreatedTiles.Count)];
            Instantiate(mEnemy, transform.position, transform.rotation);

        }





}

void CreateWallValues()
    {
        for(int i = 0; i < mCreatedTiles.Count; i++)
        {
            if (mCreatedTiles[i].z < mMinZ)
            {
                mMinZ = mCreatedTiles[i].z;

            }
            if (mCreatedTiles[i].z> mMaxZ)
            {
                mMaxZ = mCreatedTiles[i].z;

            }
            if (mCreatedTiles[i].x < mMinX)
            {
                mMinX = mCreatedTiles[i].x;

            }
            if (mCreatedTiles[i].x > mMaxX)
            {
                mMaxX = mCreatedTiles[i].x;

            }
            mAmountX = ((mMaxX - mMinX) / mTileSize) + mExtraWallX;
            mAmountZ = ((mMaxZ - mMinZ) / mTileSize) + mExtraWallZ;


        }
    }

    void CreateWall()
    {
        for(int x = 0; x < mAmountX; x++)
        {
            for (int y = 0; y < mAmountZ; y++)
            {
                if(!mCreatedTiles.Contains(new Vector3((mMinX -(mExtraWallX*mTileSize)/2)+(x * mTileSize),0, (mMinZ - (mExtraWallZ * mTileSize) / 2) + (y * mTileSize))))
                    {

                    Instantiate(mWall, new Vector3((mMinX - (mExtraWallX * mTileSize) / 2) + (x * mTileSize),0, (mMinZ - (mExtraWallZ * mTileSize) / 2) + (y * mTileSize)), transform.rotation);

                    }


            }
        }
        


    }

}
