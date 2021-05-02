using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthAndDeath : MonoBehaviour
{
    public float charHealth = 5.0f;
    public float charMaxHealth = 5.0f;

    private Animator theAnimator;

    private bool isDead;

    public AudioSource damageSound;


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
            damageSound.Play();
            Debug.Log("Health is at " + charHealth.ToString());
        }

    }

    public void DeathDetection()
    {
        if (charHealth <= 0)
        {
            isDead = true;
            Debug.Log("Golem is Dead");
        }
    }

}
