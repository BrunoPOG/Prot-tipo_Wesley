using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
   
    [Header("Key Setup")]
    public KeyCode keyCodeUp = KeyCode.UpArrow;
    public KeyCode keyCodeDown = KeyCode.DownArrow;
    public KeyCode keyCodeLeft = KeyCode.LeftArrow;
    public KeyCode keyCodeRight = KeyCode.RightArrow;
    public KeyCode keyCodeRun = KeyCode.RightArrow;
   // public bool teste = true;
    public Animator animator;
    public bool JumpAnimation;
    public ParticleSystem particleSystem;

    private bool _isRunning = false;

    [Header("Setup")]
    public SOPlayerSetup soPlayerSetup;

    [Header("JumpCoLLISION")]
    public Collider2D collider2D;
    //public float disToGround;
   // public float spaceToGround = .1f;
    public bool isOnGround;


    /*private void Awake()
    {
        if(collider2D != null)
        {
            disToGround = collider2D.bounds.extents.y;
        }
    }*/

    /* private bool IsGrounded()
     {
         // Debug.DrawRay(transform.position, -Vector2.up, Color.magenta, disToGround + spaceToGround);

         // return Physics2D.Raycast(transform.position, -Vector2.up, 0.1f);
         teste = Physics2D.Raycast(transform.position, -Vector2.up, 0.1f);
         if (teste != null)
         {
             return true;
         }
         else
             return false;
     }*/




    private void OnCollisionEnter2D(Collision2D other) 
    { 
        if  (other.gameObject.tag == "platForm")
        { 
            isOnGround = true;    
        } 
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if(col.gameObject.tag != "Enemy")
        isOnGround = false;
    }





    private void Update()
    {
        //IsGrounded();
        HandleJump();
       // Debug.Log(myRigidbody.velocity); 
        HandleMoviment();

    }

    private void HandleMoviment()
    {
        if (Input.GetKey(keyCodeRun))
        {
            soPlayerSetup._currentSpeed = soPlayerSetup.speedRun;
            animator.speed = 1.5f;
        }
        else
        {
            soPlayerSetup._currentSpeed = soPlayerSetup.speed;
            animator.speed = 1;
        }
            

        

        _isRunning = Input.GetKey(keyCodeRun);


        if (Input.GetKey(keyCodeLeft))
        {

            myRigidbody.velocity = new Vector2(Input.GetKey(keyCodeRun) ? -soPlayerSetup.speedRun : -soPlayerSetup.speed, myRigidbody.velocity.y);
            animator.SetBool(soPlayerSetup.BoolRun, true);
            if(myRigidbody.transform.localScale.x != 1)
            {
                myRigidbody.transform.DOScaleX(1, .02f);
            }

        }
        else if (Input.GetKey(keyCodeRight))
        {

            myRigidbody.velocity = new Vector2(Input.GetKey(keyCodeRun) ? soPlayerSetup.speedRun : soPlayerSetup.speed, myRigidbody.velocity.y);
            animator.SetBool(soPlayerSetup.BoolRun, true);
            if(myRigidbody.transform.localScale.x != -1)
            {
                myRigidbody.transform.DOScaleX(-1, .02f);
            }
            // myRigidbody.velocity = new Vector2(_currentSpeed, myRigidbody.velocity.y);
            // myRigidbody.MovePosition(myRigidbody.position - velocity * Time.deltaTime);
        }
        else
        {
            animator.SetBool(soPlayerSetup.BoolRun, false);
        }

        if (myRigidbody.velocity.x > 0)
        {
            myRigidbody.velocity += soPlayerSetup.friction;
        }
        else if (myRigidbody.velocity.x < 0)
        {
            myRigidbody.velocity -= soPlayerSetup.friction;
        }
    }



    private void HandleJump()
    {
        
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
               var x = Vector2.up * soPlayerSetup.forceJump;
                myRigidbody.velocity = x;
            // JumpAnimation = myRigidbody.velocity.y != 0;
           // myRigidbody.transform.localScale = new Vector2(-1f,1f);
            myRigidbody.transform.DOScaleX(-1, .001f);
            if (myRigidbody.transform.localScale.x != -1)
            {
                myRigidbody.transform.DOScaleX(1, .02f);
            }
            else if(myRigidbody.transform.localScale.x != 1)
            {
                myRigidbody.transform.DOScaleX(-1, .02f);
            }

            //


            DOTween.Kill(myRigidbody.transform);
            
                HandleScaleJump();
                JumpVFX();
               if(myRigidbody.velocity.y > 0)
            {
                animator.SetBool("JumpComplet", true);
               // Debug.Log("animação");
                Invoke(nameof(AnimationJumpFalseT), 0.5f);
                Invoke(nameof(AnimationJumpFalse), 0.7f);

            }
        }
     


    }

    private void JumpVFX()
    {
        if (particleSystem != null) particleSystem.Play();
    }


    private void HandleScaleJump()
    {
        myRigidbody.transform.DOScaleY(soPlayerSetup.JumpScaleY, soPlayerSetup.AnimationDuration).SetLoops(2, LoopType.Yoyo).SetEase(soPlayerSetup.ease);
        myRigidbody.transform.DOScaleX(soPlayerSetup.JumpScaleX, soPlayerSetup.AnimationDuration).SetLoops(2, LoopType.Yoyo).SetEase(soPlayerSetup.ease);
        
    }

    private void AnimationJumpFalse()
    {
        // animator.SetTrigger("Idle");
        animator.SetBool("JumpFalling", false);
        animator.SetBool("JumpComplet", false);
    } 
    private void AnimationJumpFalseT()
    {
        // animator.SetTrigger("Idle");
        animator.SetBool("JumpFalling", true);
    }

}
