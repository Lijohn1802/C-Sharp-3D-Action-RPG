using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ThirdPersonController : MonoBehaviour
{
    public CharacterController controller;
    private float speed;
    public float walkingspeed = 6f;
    float turnSmoothTime=0.1f;
    float turnsmoothVelocity;
    public Transform cam;
    public Animator anim;
    float horizontal;
    float vertical;
    Vector3 direction;
    float targetAngle;
    Vector3 moveDir;
    void Start()
    {
        speed = walkingspeed;
    }
    void Update()
    {
        anim.SetFloat("speed", direction.magnitude);
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");
            direction = new Vector3(horizontal, 0f, vertical).normalized;
        Jumping();
        Crouch();
        Run();
        transform.rotation = Quaternion.Euler(cam.eulerAngles.x,cam.eulerAngles.y,0f);

        if(Input.GetMouseButton(1))
        {
            transform.rotation = Quaternion.Euler(cam.eulerAngles.x,cam.eulerAngles.y,0f);
        }
        if(Input.GetMouseButtonUp(1))
        {
            float targetAngle = Mathf.Atan2(direction.x,direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnsmoothVelocity, turnSmoothTime);
           // transform.rotation = Quaternion.Euler(0f, angle, 0f);
        }
        if(direction.magnitude >= 0.1f && controller.isGrounded)
        {
            targetAngle = Mathf.Atan2(direction.x,direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir * speed * Time.deltaTime);
            if(crouching == true)
            {
                anim.SetBool("CrouchWalking", true);
            }            
            if(crouching == false)
            {
                anim.SetBool("IsWalking", true);
            }
            if(!Input.GetMouseButton(1))
            {
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnsmoothVelocity, turnSmoothTime);
                //transform.rotation = Quaternion.Euler(0f, angle, 0f);
            }
        }
        if(direction.magnitude<=0.0f)
        {
            anim.SetBool("IsWalking", false);
            anim.SetBool("CrouchWalking", false);
        }
    }
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;
    private Vector3 savedmovement; 
    void Jumping()
    {
        controller.Move(moveDirection * Time.deltaTime);
        if(!controller.isGrounded)
        {
            targetAngle = Mathf.Atan2(savedmovement.x,savedmovement.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir * speed * Time.deltaTime);
        }
        if (controller.isGrounded && Input.GetKeyDown(KeyCode.Space)) 
        {           
            savedmovement = direction;
            anim.SetTrigger("Jump");
            moveDirection.y = jumpSpeed;
        }
        moveDirection.y -= gravity * Time.deltaTime;
    }
    private bool crouching; 
    void Crouch()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl)) 
        {
            anim.SetBool("Crouch",true);
            speed = walkingspeed / 2; 
            crouching  = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftControl)) 
        {
            anim.SetBool("Crouch",false);
            speed = walkingspeed; 
            crouching = false; 
        }
    }

    public float runningspeed;
    void Run()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)) 
        {
            anim.SetBool("Run",true);
            speed = runningspeed; 
        }
        if (Input.GetKeyUp(KeyCode.LeftShift)) 
        {
            anim.SetBool("Run",false);
            speed = walkingspeed; 
        }
    }
}
