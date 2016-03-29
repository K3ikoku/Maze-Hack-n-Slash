using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    [SerializeField] private PlayerClass mPlayer;
    [SerializeField] private RawImage mHPBar;
    [SerializeField] private RawImage mXPBar;
    private float mHPPercentage;
    private float mXPPercentage;

    public void FixHud()
    {
        mPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerClass>();
    }
    // Update is called once per frame
    void Update ()
    {
        //Check the max hp of the player and the current hp
        mHPPercentage = mPlayer.CurrentHealth / mPlayer.MaxHealth;
        mHPPercentage *= 100;

        mHPBar.rectTransform.sizeDelta = new Vector2( mHPPercentage, 100); // Change the size of the healthbar based on current hp

        //Check the xp of the player and the xp needed for next level up
        mXPPercentage = mPlayer.Experience / mPlayer.ExpToLevelUp;
        mXPPercentage *= 100;

        mXPBar.rectTransform.sizeDelta = new Vector2(mXPPercentage, 100); // Change the size of the xp bar based on current xp

	}
}
