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
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    void Update()
    {

        if (controller.isGrounded)
        {
            CharacterMovementUpdate();
        }
     
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * speed *  Time.deltaTime);
       
        ButtonTesting();









    }

    public void CharacterMovementUpdate()
    {
        moveDirection = new Vector3(Input.GetAxis(horizontalAxis), 0, Input.GetAxis(verticalAxis));
        moveDirection = myCamera.transform.TransformDirection(moveDirection);
        moveDirection.y = 0f;
        //moveDirection.Normalize();
        //var forward = myCamera.transform.forward;
       // var right = myCamera.transform.right;

        //project forward and right vectors on the horizontal plane (y = 0)
            //forward.y = 0f;
            //right.y = 0f;
            //forward.Normalize();
            //right.Normalize();

    
        //var desiredMoveDirection = forward * moveDirection.z + right * moveDirection.x; //this is the direction in the world space we want to move:

        //now we can apply the movement:
        //transform.Translate(desiredMoveDirection * speed * Time.deltaTime);
        //controller.Move(moveDirection * speed * Time.deltaTime);



        //moveDirection *= speed;
        Debug.DrawRay(transform.position, moveDirection);



        if (Input.GetButton(jumpButton))
            moveDirection.y = jumpSpeed;
    }

    void ButtonTesting()
    {
        if (Input.GetAxis(punchRightButton) > 0)
        {
            print("punch Right Hand");
        }

        if (Input.GetAxis(punchLeftButton) > 0)
        {
            print("punch Left Hand");
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

    

}
