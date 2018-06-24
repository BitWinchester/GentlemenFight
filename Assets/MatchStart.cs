using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MatchStart : MonoBehaviour
{

    static MatchStart Instance;

    public GameObject[] roundTitle;
    public int currentRound = 0;
    public characterScript player1;
    public characterScript player2;

    

    void Start()
    {
        if (Instance != null)
        { GameObject.Destroy(gameObject); }
        else
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }


        if(currentRound > 3)
        {
            currentRound = 0;
        }

        Instantiate(roundTitle[currentRound], new Vector3(0, 0, 0), Quaternion.identity);
        


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("NextRound"))
        {
            if (currentRound > 3)
            {
                currentRound = 0;
            }else
            {
                currentRound++;
            }
            SceneManager.LoadScene(0);
            print("reload scene");
        }
    }
}
