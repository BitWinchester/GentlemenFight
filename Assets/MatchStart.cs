using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MatchStart : MonoBehaviour
{

    static MatchStart Instance;

    public GameObject[] roundTitle;
    static public int currentRound = 0;
    
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
        if(p1Score < 3 && p2Score < 3)
        {

           Instance.StartCoroutine(WaitToStartNextRound());
            
        }else
        {
            if(p1Score >= 3)
            {
                print("p1 wins!");
                Instance.StartCoroutine(EndGame());
            }
            else
            {
                print("p2 wins!");
                Instance.StartCoroutine(EndGame());
            }
        }
        
      
    }

    static public IEnumerator WaitToStartNextRound()
    {
       
        yield return new WaitForSeconds(3);
        
        MatchStart.currentRound++;
        SceneManager.LoadScene(1);
        Instance.StopCoroutine(WaitToStartNextRound());
    }

    static public IEnumerator EndGame()
    {

        yield return new WaitForSeconds(6);

        MatchStart.currentRound=0;
        SceneManager.LoadScene(0);
        p1Score = 0;
        p2Score = 0;
        Instance.StopCoroutine(EndGame());
    }




}





