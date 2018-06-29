using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowTrophy : MonoBehaviour
{
    public GameObject meshes;

    // Use this for initialization
    void Start()
    {
        meshes.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (MatchStart.p1Score >= 3 || MatchStart.p2Score >= 3)
        {
            meshes.SetActive(true);
        }
    }
}
