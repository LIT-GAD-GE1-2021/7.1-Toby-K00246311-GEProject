using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyHoleController : MonoBehaviour
{
    private bool keyIn;
    public Animator theAnimator;

    void Update()
    {
        theAnimator.SetBool("keyIn", keyIn);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (keyIn == false && collision.gameObject.tag == "Player" && LevelManager.instance.hasKey == true)
        {
            keyIn = true;
            LevelManager.instance.UsedKey();
        }
    }
}

