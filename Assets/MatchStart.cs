using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MatchStart : MonoBehaviour
{

    static MatchStart Instance;

    public GameObject[] roundTitle;
    public GameObject finalWinnerFX;
    static public int currentRound = 0;
    static public bool isNextRound = false;
    

    static public int p1Score;
    static public int p2Score;

    public float countDown = 3f;
    public float currentTime;



    void Start()
    {
        if (Instance != null)
        { GameObject.Destroy(gameObject); }
        else
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }



        if (currentRound > 2)
        {
            currentRound = 0;
        }

        Instantiate(roundTitle[currentRound], new Vector3(0, 0, 0), Quaternion.identity);



    }


    static public void NextRound()
    {
        if (p1Score < 3 && p2Score < 3)
        {
            if (isNextRound == false)
            {
                isNextRound = true;
                Instance.StartCoroutine(WaitToStartNextRound());
            }
            

        }
        else
        {
            if (p1Score >= 3)
            {
                print("p1 wins!");
                Instance.StartCoroutine(EndGame());
                Instantiate(Instance.finalWinnerFX, new Vector3(0, 0, 0), Quaternion.identity);
            }
            else
            {
                print("p2 wins!");
                
                Instance.StartCoroutine(EndGame());
                Instantiate(Instance.finalWinnerFX, new Vector3(0, 0, 0), Quaternion.identity);
            }
        }


    }

    static public IEnumerator WaitToStartNextRound()
    {

        yield return new WaitForSeconds(3);

        MatchStart.currentRound++;
        SceneManager.LoadScene(1);
        isNextRound = false;
        Instance.StopCoroutine(WaitToStartNextRound());
        
    }

    static public IEnumerator EndGame()
    {

        yield return new WaitForSeconds(7);

        
        MatchStart.currentRound = 0;
        SceneManager.LoadScene(0);
        p1Score = 0;
        p2Score = 0;
        Instance.StopCoroutine(EndGame());
    }




}





