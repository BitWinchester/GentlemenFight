using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

    static MusicManager Instance;
	// Use this for initialization
	void Start () {

        if (Instance != null)
        { GameObject.Destroy(gameObject); }
        else
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }

    }

    // Update is called once per frame
    void Update () {
		
	}
}
