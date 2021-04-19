using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthAndDeath : MonoBehaviour
{
    public int charHealth = 5;

    private Animator theAnimator;

    private bool isDead;


    void Update()
    {
        DeathDetection();

        theAnimator.SetBool("isDead", isDead);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            charHealth -= 1;
            Debug.Log("Damage Taken");
        }

    }

    public void DeathDetection()
    {
        if (charHealth <= 1)
        {
            isDead = true;
            Debug.Log("Golem is Dead");
        }
    }

}
