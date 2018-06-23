using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterScript : MonoBehaviour

{
 public Camera myCamera;
//camerContainer is used to make an orbit camera , holding the camera but placed right on top of the player 

public float speed = 6.0F;
public float rotationSpeed = 10f;
public float jumpSpeed = 8.0F;
public float gravity = 20.0F;
public bool isDebugMode;
private Vector3 moveDirection = Vector3.zero;
private CharacterController controller;
public bool isAimingMode = false;


void Start()
{
    controller = GetComponent<CharacterController>();
    myCamera = FindObjectOfType<Camera>();
}

void Update()
{

    if (controller.isGrounded)
    {
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        moveDirection = myCamera.transform.TransformDirection(moveDirection);
        moveDirection *= speed;

        Turning();

        if (Input.GetButton("Jump"))
            Jumping();

    }
    moveDirection.y -= gravity * Time.deltaTime;
    controller.Move(moveDirection * Time.deltaTime);

    if (isDebugMode)
        Debug.DrawLine(this.transform.position, new Vector3(this.transform.position.normalized.x, 0, 0) * 1);



}

public void MouseLookTurning()
{
    Ray camRay = myCamera.ScreenPointToRay(Input.mousePosition);
    RaycastHit hit;
    if (Physics.Raycast(camRay, out hit, 200f))
    {
        //Will only show in game with gizmos enabled on the game view
        Debug.DrawLine(transform.position, hit.point, Color.red);
        Vector3 playerToMouse = hit.point - transform.position;

        playerToMouse.y = 0f;
        Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
        transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * rotationSpeed);
        //transform.rotation = newRotation;

    }

}

public void TurnToFaceMoveDirection()
{
    if (moveDirection != Vector3.zero)
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveDirection), Time.deltaTime * rotationSpeed);
        //transform.rotation = Quaternion.LookRotation(moveDirection);
    }
}


void Turning()
{
    //Turning is based on holding down a key ( though of as aiming) 
    if (Input.GetMouseButton(1))
    {
        isAimingMode = true;
        MouseLookTurning();
    }
    else
    {
        isAimingMode = false;
        TurnToFaceMoveDirection();
    }
}

void Jumping()
{
    moveDirection.y = jumpSpeed;
}
}
