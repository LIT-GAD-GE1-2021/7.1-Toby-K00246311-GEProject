using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public static LevelManager instance;
    public GameObject door;
    public doorController doorCon;
    public bool hasKey;
    private bool doorOpened;
    private bool doorClosed = true;

    public Animator doorAnimator;

    private void Awake()
    {
        instance = this;
    }

    public void KeyCollected()
    {
        hasKey = true;

        Debug.Log("Key Collected");
    }

    public void UsedKey()
    {
        hasKey = false;
        Debug.Log("Key Used");
    }

}
