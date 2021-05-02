using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    void Update()
    {
        doorAnimator.SetBool("doorOpened", doorOpened);
        doorAnimator.SetBool("doorClosed", doorClosed);
        
        if(Input.GetKeyDown("r"))
        {
            SceneManager.LoadScene("GameEnginesProject");
        }
    }

    public void KeyCollected()
    {
        hasKey = true;

        Debug.Log("Key Collected");
    }

    public void UsedKey()
    {
        doorClosed = false;
        doorOpened = true;
        hasKey = false;
        Debug.Log("Key Used");
    }

}
