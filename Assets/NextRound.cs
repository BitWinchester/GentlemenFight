using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NextRound : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("NextRound_P2") || Input.GetButtonDown("NextRound_P1"))
        {
            MatchStart.currentRound++;
            SceneManager.LoadScene(1);
        }
    }
}
