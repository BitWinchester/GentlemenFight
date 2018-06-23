using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterScript : MonoBehaviour

{

    public string horizontalAxis = "Horizonal_P1";
    public string verticalAxis = "Vertical_P1";
    public string jumpButton = "Jump_P1";
    public string punchRightButton = "Punch_R_P1";
    public string punchLeftButton = "Punch_L_P1";
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
        controller.Move(moveDirection * Time.deltaTime);

        if (Input.GetAxis(punchRightButton) > 0 )
        {
            print("punch Right Hand");
        }

        if (Input.GetAxis(punchLeftButton) > 0)
        {
            print("punch Left Hand");
        }


    }

    public void CharacterMovementUpdate()
    {
        moveDirection = new Vector3(Input.GetAxis(horizontalAxis), 0, Input.GetAxis(verticalAxis));
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed;
        if (Input.GetButton(jumpButton))
            moveDirection.y = jumpSpeed;
    }

    

}
