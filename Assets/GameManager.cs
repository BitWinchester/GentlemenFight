using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public Text startingText;
    public Image controllerImage;
    public Text controllerStartText;
	// Use this for initialization
	void Start () {
        startingText.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.R))
        {
           
            SceneManager.LoadScene(0);
            print("reload scene");
        }
	}
}
