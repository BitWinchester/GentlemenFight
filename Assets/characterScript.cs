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
    public string throwButton = "Throw_P1";
    public string dashButton = "Dash_P1";
    public float speed = 6.0F;
    public float rotateSpeed = 16f;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    public float dashTime = 1f;

    public MatchStart matchStartScript;
    public string playerScore;

    

    public float complimentSpawnTime = 10f;
    public GameObject[] compliments;
    public GameObject hitBox;
    public GameObject attackVolumeRight;
    public GameObject attackVolumeLeft;
    private Vector3 moveDirection = Vector3.zero;
    private Vector3 lookDirection = Vector3.zero;
    private Vector3 facing = Vector3.zero;
    private CharacterController controller;
    private Rigidbody rb;
    public bool bDead = false;

    public Animator anim;


    public AudioSource AudioS;
    public AudioSource AudioS2;
    public AudioClip punchHit;
    public AudioClip punchMiss;
    public AudioClip jump;
    public AudioClip[] complimentsOnDeath;
    public bool isPunchingRight;
    public bool isPunchingLeft;

    public Winner winnerScript;



    private void Start()
    {

        controller = GetComponent<CharacterController>();
        rb = GetComponentInParent<Rigidbody>();
        

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


            if (lookDirection != Vector3.zero)
            {
                facing = lookDirection;
            }
            else if (moveDirection != Vector3.zero)
            {
                facing = moveDirection;
            }

            if (Input.GetButton(jumpButton))
            {
                AudioS.PlayOneShot(jump);
                moveDirection.y = jumpSpeed;
                
            }

        }

        if (facing != Vector3.zero)
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(facing), Time.deltaTime * rotateSpeed);
    }



    void ButtonTesting()
    {
        if (Input.GetAxis(punchRightButton) > 0)
        {
            if (!isPunchingRight)
            {
                isPunchingRight = true;
                AudioS.PlayOneShot(punchMiss);
            }
            anim.SetBool("bRightPunch", true);
            attackVolumeRight.SetActive(true);

        }
        if (Input.GetAxis(punchRightButton) < 0.1)
        {
            isPunchingRight = false;
            anim.SetBool("bRightPunch", false);
            attackVolumeRight.SetActive(false);
        }

        if (Input.GetAxis(punchLeftButton) > 0)
        {
            if (!isPunchingLeft)
            {
                isPunchingLeft = true;
                AudioS2.PlayOneShot(punchMiss);
            }

            anim.SetBool("bLeftPunch", true);
            attackVolumeLeft.SetActive(true);
        }
        if (Input.GetAxis(punchLeftButton) < 0.1)
        {
            isPunchingLeft = false;
            anim.SetBool("bLeftPunch", false);
            attackVolumeLeft.SetActive(false);
        }




        if (Input.GetButton(throwButton))
        {

        }

        if (Input.GetButtonDown(dashButton))
        {
            AudioS2.clip = complimentsOnDeath[Random.Range(0, complimentsOnDeath.Length)];
            AudioS2.Play();
        }

    }

    void Dash()
    {

    }

    public void Death()
    {
        if(playerScore == "Player1")
        {
            MatchStart.p2Score++;
            MatchStart.NextRound();
        }else
        {
            MatchStart.p1Score++;
            MatchStart.NextRound();
        }
       
        winnerScript.ShowWinningFx();
        AudioS.clip = punchHit;
        AudioS.Play();
        Compliment();
        bDead = true;
        Destroy(hitBox);
        Destroy(attackVolumeRight);
        Destroy(attackVolumeLeft);
        Destroy(this);
        rb.isKinematic = false;
        rb.AddForce(transform.forward * -5000f);
        anim.SetBool("isDead", true);

    }

    public void Compliment()
    {
        complimentSpawnTime = Time.time + Random.Range(4f, 8f);
        GameObject temp = Instantiate(compliments[Random.Range(0, compliments.Length)], gameObject.transform);
        Destroy(temp, 3f);
    }

    public void AudioCompliment()
    {
        AudioS2.clip = complimentsOnDeath[Random.Range(0, complimentsOnDeath.Length)];
        AudioS2.Play();
    }

}
