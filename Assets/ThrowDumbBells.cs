using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowDumbBells : MonoBehaviour
{

    public characterScript cs;
    public GameObject proj;
    public Transform spawnPoint;
    public float speed = 50f;
    public Animator anim;
    public float fireRate = 1f;
    private float nextFire;
    // Use this for initialization
    void Start()
    {
        cs = GetComponentInParent<characterScript>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown(cs.throwButton) && Time.time > nextFire && cs.bDead == false)
        {
            nextFire = Time.time + fireRate;
            GameObject temp = Instantiate(proj, new Vector3(spawnPoint.position.x, spawnPoint.position.y, spawnPoint.position.z), Quaternion.identity);
            temp.GetComponentInParent<Rigidbody>().velocity = spawnPoint.forward * speed;
            temp.GetComponentInParent<Rigidbody>().angularVelocity = transform.right * speed;
            anim.SetTrigger("Throw");
        }
    }




}
