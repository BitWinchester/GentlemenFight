using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterHittingGround : MonoBehaviour {

    public float delay = 3f;
    float countDown;
    bool hasExploded = false;
    public GameObject explosionFX;
    public float explosionRadius;
    public AudioSource audioS;
    public AudioClip bombExplodeAudio;
    public AudioClip bombCollision;


    private void Start()
    {
        audioS = GetComponent<AudioSource>();
        countDown = delay; 
    }
    private void OnCollisionEnter(Collision collision)
    {
        audioS.clip = bombCollision;
        audioS.Play();
    }
    private void Update()
    {
        countDown -= Time.deltaTime;

        if(countDown <= 0 && !hasExploded)
        {
            Explode();
            hasExploded = true;
        }

    }

    void Explode()
    {
        audioS.clip = bombExplodeAudio;
        audioS.Play();
        Instantiate(explosionFX, transform.position, transform.rotation);
        transform.GetChild(0).gameObject.SetActive(false);
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider nearbyObject in colliders)
        {
            characterScript cs = nearbyObject.GetComponent<characterScript>();

            if( cs != null)
            {
                nearbyObject.GetComponent<characterScript>().Death();
            }
           
        }
        Destroy(gameObject, 1.2f);
    }





}
