using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BegingMenu : MonoBehaviour
{

    public Text startingText;
    public Image controllerImage;
    public Text controllerStartText;
    private bool isControllerShowing = false;
    // Use this for initialization
    void Start()
    {
        startingText.enabled = true;
        controllerImage.enabled = false;
        controllerStartText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("NextRound_P2") || Input.GetButtonDown("NextRound_P1"))
        {
            if (!isControllerShowing)
            {
                startingText.enabled = false;
                controllerImage.enabled = true;
                controllerStartText.enabled = true;
                isControllerShowing = true;
            }
            else if (isControllerShowing)
            {
                SceneManager.LoadScene(1);
            }




        }

    }
}
