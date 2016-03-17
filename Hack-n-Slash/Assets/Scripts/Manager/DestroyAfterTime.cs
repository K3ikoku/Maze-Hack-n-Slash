using UnityEngine;
using System.Collections;

public class DestroyAfterTime : MonoBehaviour
{
    [SerializeField] private float mTimeUntilDestroy;
    private float mTimer;

    void Update()
    {
        if (mTimer >= mTimeUntilDestroy)
        {
            GameObject.Destroy(gameObject);

        }
        else
        {
            mTimer += Time.deltaTime;
        }

    }
}
