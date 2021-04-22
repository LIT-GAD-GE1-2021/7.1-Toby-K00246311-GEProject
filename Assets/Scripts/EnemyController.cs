using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Rigidbody2D theRB;
    public Transform tForm;
    private bool moveLeft;
    private bool facingRight = true;
    private Vector2 scaleRight = new Vector2(1, 1), scaleLeft = new Vector2(-1, 1);

    void Update()
    {
        MoveLeftAndRight();
        Flip();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "WallR")
        {
            moveLeft = true;

        }

        if (collision.gameObject.tag == "WallL")
        {
            moveLeft = false;

        }
    }

    public void MoveLeftAndRight()
    {
        if (moveLeft == false)
        {
            facingRight = true;
            theRB.velocity = Vector2.right * 6;
        }
        if (moveLeft == true)
        {
            facingRight = false;
            theRB.velocity = Vector2.left * 6;
        }
    }

   public void Flip()
    {
        if (facingRight == true)
        {
            tForm.localScale = scaleRight;
        }

        if (facingRight == false)
        {
            tForm.localScale = scaleLeft;
        }
    }

}
