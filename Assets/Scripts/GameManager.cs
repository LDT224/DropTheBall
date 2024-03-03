using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public enum GAMESTATE
    {
        INIT,
        PLAY,
        PAUSEGAME,
        END,
    }
    public GAMESTATE m_gameState;
    public static GameManager _instance { get; private set; }

    //Ball
    public int dropSpeed;
    public int dropTime;

    //UI
    public int highScore;
    public int score;

    //Box
    public int rotateSpeed;
    public int moveRow;
    public float row;
    public float moveTime;

    //Arrow
    public float minY;
    public float maxY;

    //Spawn Box
    public int minNumSpawn;
    public int maxNumSpawn;
    public int numSpawn;
    public int onePer;
    public int twoPer;
    public int threePer;
    public int fourPer;
    public int fivePer;
    public int sixPer;
    public int sevenPer;

    //Block
    public float topBlock;
    public float bottomBlock;
    public void Awake()
    {
        if( _instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        SetDefault();
        m_gameState = GAMESTATE.INIT;
    }
    private void SetDefault()
    {
        numSpawn = 3;
        dropTime = 0;
        moveRow = 2;
        row = 0.6f;
        moveTime = 1;
        score = 0;
        rotateSpeed = 50;
        minY = 0;
        maxY = 4.2f;
        topBlock = 1.7f;
        bottomBlock = -3f;

        onePer = 100;
        twoPer = 100;
        threePer = 100;
        fourPer = 100;
        fivePer = 100;
        sixPer = 100;
        sevenPer = 100;
    }
    public void UpdateBox()
    {
        if(dropTime == 0)
        {
            minNumSpawn = 3;
            maxNumSpawn = 3;
            onePer = 100;
        }
        else if((dropTime >= 1) && dropTime <3)
        {
            minNumSpawn = 2;
            maxNumSpawn = 5;

            onePer = 60;
            twoPer = 100;
        }
        else if((dropTime >= 3) && dropTime < 5)
        {
            minNumSpawn = 2;
            maxNumSpawn = 5;

            onePer = 50;
            twoPer = 85;
            threePer = 100;
        }
        else if((dropTime >= 5) && dropTime < 7)
        {
            minNumSpawn = 2;
            maxNumSpawn = 5;

            onePer = 45;
            twoPer = 70;
            threePer = 90;
            fourPer = 100;
        }
        else if((dropTime >= 7) && dropTime < 9)
        {
            minNumSpawn=3;
            maxNumSpawn = 5;

            onePer = 40;
            twoPer = 65;
            threePer = 81;
            fourPer = 93;
            fivePer = 100;
        }
        else if((dropTime >= 9) && dropTime < 12)
        {
            minNumSpawn = 3;
            maxNumSpawn = 6;

            onePer = 40;
            twoPer = 65;
            threePer = 78;
            fourPer = 88;
            fivePer = 95;
            sixPer = 100;
        }
        else if(dropTime >= 12)
        {
            minNumSpawn = 3;
            maxNumSpawn = 7;

            onePer = 40;
            twoPer = 60;
            threePer = 73;
            fourPer = 83;
            fivePer = 91;
            sixPer = 97;
            sevenPer = 100;
        }
        numSpawn = Random.Range(minNumSpawn, maxNumSpawn+1);
    }
    // Update is called once per frame
    void Update()
    {
        switch (m_gameState)
        {
            case GAMESTATE.INIT:
                SetDefault();
                m_gameState = GAMESTATE.PLAY;
                break;
            case GAMESTATE.PLAY:
                break;
            case GAMESTATE.PAUSEGAME:
                break;
            case GAMESTATE.END:
                break;
        }
    }
}
