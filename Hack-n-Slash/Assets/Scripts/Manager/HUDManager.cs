using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    [SerializeField] private PlayerClass mPlayer;
    [SerializeField] private RawImage mHPBar;
    private float mHPPercentage;


    // Update is called once per frame
    void Update ()
    {
        //Check the max hp of the player and the current hp
        mHPPercentage = mPlayer.mCurrentHealth / mPlayer.mPlayerHealth;
        mHPPercentage *= 100;

        mHPBar.rectTransform.sizeDelta = new Vector2(mHPPercentage, 100); // Change the size of the healthbar based on current hp
	}
}
