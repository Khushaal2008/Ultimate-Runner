using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   private CharacterController controller;
   private Vector3 direction;
   public float forwardSpeed;
   public float maximumSpeed = 25;

   private int desiredLane = 1;
   public float laneDistance = 2;

   public float jumpForce;
   public float Gravity = -20;

   private bool isRolling = false;

   public Animator animator;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!PlayerManager.isGameStarted)
            return;

        direction.z = forwardSpeed;
        animator.SetTrigger("isRunning");
        animator.SetBool("isJumping",false);
        animator.SetBool("isCarHit",false);
        animator.SetBool("isFrontFall",false);

    if(forwardSpeed<maximumSpeed)
        forwardSpeed += 0.5f * Time.deltaTime;

        if(controller.isGrounded)
        {
        if(SwipeManager.swipeUp || Input.GetKeyDown(KeyCode.UpArrow))
            {
            Jump();
            
            }
            else{
                animator.SetBool("isJumping",false);
            }
        }
        else
        {
            direction.y += Gravity * Time.deltaTime;
        }

        

        if(SwipeManager.swipeDown && !isRolling || Input.GetKeyDown(KeyCode.DownArrow))
        {
            StartCoroutine(Slide());
        }

        if(SwipeManager.swipeRight || Input.GetKeyDown(KeyCode.RightArrow))
        {
            desiredLane++;
            if(desiredLane == 3)
                desiredLane = 2;
            
        }

        if(SwipeManager.swipeLeft || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            desiredLane--;
            if(desiredLane == -1)
                desiredLane = 0;
            
        }

      Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        if(desiredLane == 0)
        {
            targetPosition += Vector3.left * laneDistance;

        }
        else if(desiredLane == 2)
        {
            targetPosition += Vector3.right * laneDistance;
        }

        /*transform.position = targetPosition;
        controller.center = controller.center;*/
        if(transform.position != targetPosition)
        {
        Vector3 diff = targetPosition - transform.position;
        Vector3 moveDir = diff.normalized * 25 * Time.deltaTime;
        if(moveDir.sqrMagnitude < diff.sqrMagnitude)
        controller.Move(moveDir);
        else
        controller.Move(diff);
        }
        

    controller.Move(direction * Time.deltaTime);

    }

 

    private void Jump()
    {
        direction.y = jumpForce;
       animator.SetBool("isJumping",true);
    }

    

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.transform.tag == "Obj")
        {
            PlayerManager.gameOver = true;
            direction.z = 0;
            forwardSpeed = 0;
            animator.SetBool("isCarHit",true);

        }

        if(hit.transform.tag == "CarObj")
        {

            PlayerManager.gameOver = true;
            direction.z = 0;
            forwardSpeed = 0;
            animator.SetBool("isFrontFall",true);
        }
        
    }

    private IEnumerator Slide()
    {
        isRolling = true;
        controller.center = new Vector3(0,0.37f,0);
        controller.height = 0.1f;
        controller.radius = 0.4f;
        animator.SetBool("isRolling",true);
        yield return new WaitForSeconds(0.8F);
        animator.SetBool("isRolling",false);
        controller.center = new Vector3(0,0.96f,0);
        controller.height = 2;
        controller.radius = 0.5f;
        isRolling = false;
    }
}
