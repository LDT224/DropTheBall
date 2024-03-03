using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnBoxController : MonoBehaviour
{
    public enum SPAWNSTATE
    {
        INIT,
        SPAWN,

    }
    public SPAWNSTATE m_spawnState;
    private GameObject[] spawnPoints;
    public GameObject[] boxs;
    public int boxScore;
    public List<int> spawns = new List<int> ();
    public GameObject boxSpawns;
    public Collider2D block;
    //private BoxController boxController;
    // Start is called before the first frame update
    void Start()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag("spawnPoint");
        SpawnBoxs();
        m_spawnState = SPAWNSTATE.INIT;
        //boxController = GameObject.FindObjectOfType<BoxController>();
    }
    public void SpawnBoxs()
    {
        GameManager._instance.UpdateBox();
        for (int i = 0; i < GameManager._instance.numSpawn; i++)
        {
            int ran = Random.Range(0,spawnPoints.Length);
            if(spawns.Contains(ran))
            {
                i--;
            }
            else
            {
                spawns.Add(ran);
                boxScore = Random.Range(0, 100);
                int shape = Random.Range(0, 2);
                if (boxScore <= GameManager._instance.onePer)
                {
                    GameObject box = Instantiate(boxs[shape], spawnPoints[ran].transform.position, Quaternion.identity);
                    box.transform.GetChild(0).GetComponent<TextMeshPro>().text = "1";
                    box.transform.parent = boxSpawns.transform;
                }
                else if (boxScore >= GameManager._instance.onePer && boxScore < GameManager._instance.twoPer)
                {
                    GameObject box = Instantiate(boxs[shape], spawnPoints[ran].transform.position, Quaternion.identity);
                    box.transform.GetChild(0).GetComponent<TextMeshPro>().text = "2";
                    box.transform.parent = boxSpawns.transform;
                }
                else if (boxScore >= GameManager._instance.twoPer && boxScore < GameManager._instance.threePer)
                {
                    GameObject box = Instantiate(boxs[shape], spawnPoints[ran].transform.position, Quaternion.identity);
                    box.transform.GetChild(0).GetComponent<TextMeshPro>().text = "3";
                    box.transform.parent = boxSpawns.transform;
                }
                else if (boxScore >= GameManager._instance.threePer && boxScore < GameManager._instance.fourPer)
                {
                    GameObject box = Instantiate(boxs[shape], spawnPoints[ran].transform.position, Quaternion.identity);
                    box.transform.GetChild(0).GetComponent<TextMeshPro>().text = "4";
                    box.transform.parent = boxSpawns.transform;
                }
                else if (boxScore >= GameManager._instance.fourPer && boxScore < GameManager._instance.fivePer)
                {
                    GameObject box = Instantiate(boxs[shape], spawnPoints[ran].transform.position, Quaternion.identity);
                    box.transform.GetChild(0).GetComponent<TextMeshPro>().text = "5";
                    box.transform.parent = boxSpawns.transform;
                }
                else if (boxScore >= GameManager._instance.fivePer && boxScore < GameManager._instance.sixPer)
                {
                    GameObject box = Instantiate(boxs[shape], spawnPoints[ran].transform.position, Quaternion.identity);
                    box.transform.GetChild(0).GetComponent<TextMeshPro>().text = "6";
                    box.transform.parent = boxSpawns.transform;
                }
                else if (boxScore >= GameManager._instance.sixPer)
                {
                    GameObject box = Instantiate(boxs[2], spawnPoints[ran].transform.position, Quaternion.identity);
                    box.transform.GetChild(0).GetChild(0).GetComponent<TextMeshPro>().text = "7";
                    box.transform.parent = boxSpawns.transform;
                }
            }
        }
        spawns.Clear();
        m_spawnState = SPAWNSTATE.SPAWN;
    }
    public void MoveAllBoxs()
    {
        for (int i = 0; i < boxSpawns.transform.childCount; i++)
        {
            boxSpawns.transform.GetChild(i).GetComponent<BoxController>().MoveBox();
        }
    }   
    public void CheckTopBoxs()
    {
        GameManager._instance.moveRow = 2;
        for (int i = 0; i < boxSpawns.transform.childCount; i++)
        {
            if(boxSpawns.transform.GetChild(i).transform.position.y > GameManager._instance.topBlock)
            {
                GameManager._instance.moveRow = 1;
            }
        }
    }
    public void CheckBottomBoxs()
    {
        for (int i = 0; i < boxSpawns.transform.childCount; i++)
        {
            if (boxSpawns.transform.GetChild(i).transform.position.y < GameManager._instance.bottomBlock)
            {
                GameObject destroyBox = boxSpawns.transform.GetChild(i).gameObject;
                Destroy(destroyBox);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(GameManager._instance.m_gameState == GameManager.GAMESTATE.PLAY)
        {
            switch (m_spawnState)
            {
                case SPAWNSTATE.INIT:
                    MoveAllBoxs();
                    m_spawnState = SPAWNSTATE.SPAWN;
                    break;
                case SPAWNSTATE.SPAWN:
                    break;
            }
        }
    }
}
