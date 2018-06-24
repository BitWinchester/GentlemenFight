using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterHittingGround : MonoBehaviour {

    public GameObject damageVolume;
    private void OnCollisionEnter(Collision collision)
    {

        
        Destroy(gameObject, 3f);
    }
}
