using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterScript : MonoBehaviour

{
    public Camera myCamera;
    public string horizontalAxis = "Horizonal_P1";
    public string verticalAxis = "Vertical_P1";
    public string rsHorizontalAxis = "RS_Horizonal_P1";
    public string rsVerticalAxis = "RS_Vertical_P1";
    public string jumpButton = "Jump_P1";
    public string punchRightButton = "Punch_R_P1";
    public string punchLeftButton = "Punch_L_P1";
    public string blockButton = "Block_P1";
    public string dashButton = "Dash_P1";
    public float speed = 6.0F;
    public float rotateSpeed = 16f;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    public float dashTime = 1f;
    private Vector3 moveDirection = Vector3.zero;
    private Vector3 lookDirection = Vector3.zero;
    private Vector3 facing = Vector3.zero;
    private CharacterController controller;

    public Animator anim;
    

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    void Update()
    {
       
            Debug.DrawRay(transform.position, lookDirection);


        //else if (moveDirection.sqrMagnitude > 0.1f)
        //{
        //    Vector3 facing = moveDirection;
        //    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(facing.x, 0, facing.z)), Time.deltaTime * rotateSpeed);
        //}

        CharacterMovementUpdate();
        controller.Move(moveDirection * speed * Time.deltaTime);
        
        moveDirection.y -= gravity * Time.deltaTime;
        
        ButtonTesting();


    }

    public void CharacterMovementUpdate()
    {
        if (controller.isGrounded)
        {
            lookDirection = new Vector3(Input.GetAxisRaw(rsHorizontalAxis), 0, Input.GetAxisRaw(rsVerticalAxis));
            lookDirection = myCamera.transform.TransformDirection(lookDirection);
            lookDirection.y = 0f;   
            lookDirection.Normalize();

            moveDirection = new Vector3(Input.GetAxisRaw(horizontalAxis), 0, Input.GetAxisRaw(verticalAxis));
            moveDirection = myCamera.transform.TransformDirection(moveDirection);
            moveDirection.y = 0f;
            moveDirection.Normalize();
            Debug.DrawRay(transform.position, moveDirection);


            if(lookDirection != Vector3.zero)
            {
                facing = lookDirection;
            }
            else if (moveDirection != Vector3.zero)
            {
                facing = moveDirection;
            }

            if (Input.GetButton(jumpButton))
                moveDirection.y = jumpSpeed;
        }

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(facing), Time.deltaTime * rotateSpeed);
    }



    void ButtonTesting()
    {
        if (Input.GetAxis(punchRightButton) > 0)
        {
            print("punch Right Hand");
            anim.SetBool("bRightPunch", true);
        }
        if (Input.GetAxis(punchRightButton) < 0.1)
        {
            
            anim.SetBool("bRightPunch", false);
        }

        if (Input.GetAxis(punchLeftButton) > 0)
        {
           
            anim.SetBool("bLeftPunch", true);
        }
        if (Input.GetAxis(punchLeftButton) < 0.1)
        {

            anim.SetBool("bLeftPunch", false);
        }




        if (Input.GetButton(blockButton))
        {
            print("BLocking!");
        }

        if (Input.GetButton(dashButton))
        {
            print("Dashing");
        }

    }

    void Dash()
    {
        
    }



}
