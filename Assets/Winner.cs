using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Winner : MonoBehaviour {

    public GameObject winnerFx; 
	// Use this for initialization
	void Start () {
		
	}
	


    public void ShowWinningFx()
    {
        Instantiate(winnerFx, gameObject.transform);
    }

}
