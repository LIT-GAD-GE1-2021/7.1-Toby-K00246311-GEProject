using UnityEngine;
using System.Collections;

public class GolemController : MonoBehaviour
{
    public int charHealth = 5;
    private bool isDead;
    private bool hasDied;

    public float jumpSpeed;
    public float horizontalSpeed = 10;
    public LayerMask whatIsGround;
    public Transform groundcheck;
    private float groundRadius = 0.5f;
    public float fallMultiplier = 5.0f;

    private bool grounded;
    private bool jump;
    private bool isRunning;

    public bool facingRight = true;

    private float hAxis;

    private Rigidbody2D theRigidBody;

    private Animator theAnimator;


    void Start()
    {
       
        jump = false;
        grounded = false;
        isRunning = false;

      
        theRigidBody = GetComponent<Rigidbody2D>();
        theAnimator = GetComponent<Animator>();

    }

    void Update()
    {
        DeathDetection();

        theAnimator.SetBool("isDead", isDead);

        theAnimator.SetBool("hasDied", hasDied);

        jump = Input.GetKeyDown(KeyCode.Space);

        hAxis = Input.GetAxis("Horizontal");


        theAnimator.SetFloat("hspeed", Mathf.Abs(hAxis));

        Collider2D colliderWeCollidedWith = Physics2D.OverlapCircle(groundcheck.position, groundRadius, whatIsGround);

   
     
        grounded = (bool)colliderWeCollidedWith;

        theAnimator.SetBool("ground", grounded);

        float yVelocity = theRigidBody.velocity.y;

        theAnimator.SetFloat("vspeed", yVelocity);

        theAnimator.SetBool("running", isRunning);


        if (Input.GetKeyDown(KeyCode.LeftShift) && isDead == false)
        {
            horizontalSpeed = 25;
            isRunning = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift) && isDead == false)
        {
            horizontalSpeed = 10;
            isRunning = false;
        }



        if (grounded)
        {
            if ((hAxis > 0) && (facingRight == false) && isDead == false)
            {
                Flip();
            }
            else if ((hAxis < 0) && (facingRight == true) && isDead == false)
            {
                Flip();
            }
        }

        if (grounded && !jump && isDead == false)
        {
            theRigidBody.velocity = new Vector2(horizontalSpeed * hAxis, theRigidBody.velocity.y);
        }
        else if (grounded && jump && isDead == false)
        {

            theRigidBody.velocity = new Vector2(theRigidBody.velocity.x, jumpSpeed);
        }


        if (theRigidBody.velocity.y < 0)
        {

            theRigidBody.velocity += Vector2.up * Physics2D.gravity.y * fallMultiplier * Time.deltaTime;

        }

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
        if (charHealth <= 1 && isDead == false)
        {
            hasDied = true;
            isDead = true;
            Invoke("FalsifyBool", 0.2f);
            Debug.Log("Golem is Dead");
        }
    }

    private void FalsifyBool()
    {
        hasDied = false;
    }


    private void Flip()
    {

        facingRight = !facingRight;

        
        Vector3 theScale = transform.localScale;

       
        theScale.x *= -1;

        
        transform.localScale = theScale;
    }

   
}
