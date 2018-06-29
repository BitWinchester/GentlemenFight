using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CameraPlayersInView : MonoBehaviour

{
    private new Transform transform;
    private Vector3 DesiredPos;
    public List<Transform> Players;
    public float camSpeed;
    private Camera cam;
    public float cameraYOffset = 5f;
    void Awake()
    {
        transform = GetComponent<Transform>();
        cam = GetComponent<Camera>();
    }

    private void Start()
    {
        var p = GameObject.FindGameObjectsWithTag("Player");
        Players = new List<Transform>();
        for (int i = 0; i < p.Length; i++)
        {
            Players.Add(p[i].GetComponent<Transform>());
        }
    }

    void Update()
    {
        if (Players.Count <= 0)//early out if no players have been found
            return;
        DesiredPos = Vector3.zero;
        float distance = 0f;
        var depthSort = Players.OrderByDescending(p => p.position.z);
        var wSort = Players.OrderByDescending(p => p.position.x);
        var mDepth = depthSort.First().position.z - depthSort.Last().position.z;
        var mWidth = wSort.First().position.x - wSort.Last().position.x;
        var distanceH = -(mDepth + 5f) * 0.5f / Mathf.Tan(cam.fieldOfView * 0.5f * Mathf.Deg2Rad);
        var distanceW = -(mWidth / cam.aspect + 5f) * 0.5f / Mathf.Tan(cam.fieldOfView * 0.5f * Mathf.Deg2Rad);
        distance = distanceW;

        for (int i = 0; i < Players.Count; i++)
        {
            DesiredPos += Players[i].position;
        }
        if (distance > -5f) distance = -5f;
        DesiredPos /= Players.Count;
        DesiredPos.z = distance;
    }

    void LateUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(DesiredPos.x,DesiredPos.y + cameraYOffset, DesiredPos.z), camSpeed);
    }
}

