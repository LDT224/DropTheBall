using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static BallController;

public class SpawnBallController : MonoBehaviour
{
    public enum SpawnBallState
    {
        FIRST,
        SPAWN,
    }
    public SpawnBallState m_spawnBallState;

    public GameObject ballIns;
   
    // Start is called before the first frame update
    void Start()
    {
        SpawnBall();
        m_spawnBallState = SpawnBallState.FIRST;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.childCount == 0)
            SpawnBall();
    }
    public void SpawnBall()
    {
        GameObject ball =  Instantiate(ballIns,transform.position,Quaternion.identity);
        ball.transform.parent = transform;
        m_spawnBallState = SpawnBallState.SPAWN;
    }
}
