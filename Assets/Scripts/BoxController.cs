using Newtonsoft.Json.Bson;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;
using static BallController;

public class BoxController : MonoBehaviour
{
    public enum BoxState
    {
        INIT,
        CIRCLE,
        SQUARE,
        HEXAGON,
        DESTROY,
    }
    public BoxState m_boxState;
    public TextMeshPro boxScoreTxt;
    public int boxScore;
    private int dir;
    private UIManager uiManager;
    // Start is called before the first frame update
    void Start()
    {
        uiManager = GameObject.FindObjectOfType<UIManager>();
        m_boxState = BoxState.INIT;
        CheckShape();
        UpdateColor();
        //MoveBox();
        dir = UnityEngine.Random.Range(0, 2) * 2 - 1;
    }

    // Update is called once per frame
    public void UpdateColor()
    {
        boxScoreTxt.text = boxScore.ToString();

        if (boxScoreTxt.text == "1")
            gameObject.GetComponent<SpriteRenderer>().color = new Color32(241, 157, 71, 255);
        else if (boxScoreTxt.text == "2")
            gameObject.GetComponent<SpriteRenderer>().color = new Color32(251, 229, 88, 255);
        else if (boxScoreTxt.text == "3")
            gameObject.GetComponent<SpriteRenderer>().color = new Color32(86, 188, 125, 255);
        else if (boxScoreTxt.text == "4")
            gameObject.GetComponent<SpriteRenderer>().color = new Color32(58, 132, 225, 255);
        else if (boxScoreTxt.text == "5")
            gameObject.GetComponent<SpriteRenderer>().color = new Color32(25, 230, 255, 255);
        else if (boxScoreTxt.text == "6")
            gameObject.GetComponent<SpriteRenderer>().color = new Color32(109, 57, 202, 255);
        else if (boxScoreTxt.text == "7")
            gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 77, 77, 255);
    }
    public void CheckShape()
    {
        boxScore = int.Parse(boxScoreTxt.text);
        if (gameObject.CompareTag("square"))
            m_boxState = BoxState.SQUARE;
        else if (gameObject.CompareTag("circle"))
            m_boxState = BoxState.CIRCLE;
        else if (gameObject.CompareTag("hexagon"))
            m_boxState = BoxState.HEXAGON;
    }
    public void MoveBox()
    {
        Vector3 newPos = transform.position;
        newPos.x = transform.position.x;
        newPos.y = transform.position.y + GameManager._instance.row*GameManager._instance.moveRow;
        newPos.z = 0;
        transform.position = Vector3.Lerp(transform.position, newPos, GameManager._instance.moveTime);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        boxScore--;
        UpdateColor();
        if(boxScore == 0)
        {
            m_boxState = BoxState.DESTROY;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager._instance.m_gameState = GameManager.GAMESTATE.END;
    }
    void Update()
    {
        if (m_boxState == BoxState.SQUARE)
        {
            //transform.RotateAroundLocal(Vector3.back * dir, Time.deltaTime);
            transform.Rotate(new Vector3(0,0, GameManager._instance.rotateSpeed)* dir*Time.deltaTime);
        }
        else if (m_boxState == BoxState.HEXAGON)
        {
            GameObject child = transform.GetChild(0).gameObject;
            child.transform.Rotate(new Vector3(0, 0, GameManager._instance.rotateSpeed) * dir * Time.deltaTime);
        }

        switch (m_boxState)
        {
            case BoxState.INIT:
                break;
            case BoxState.CIRCLE:
                break;
            case BoxState.SQUARE:
                transform.Rotate(new Vector3(0, 0, GameManager._instance.rotateSpeed) * dir * Time.deltaTime);
                break;
            case BoxState.HEXAGON:
                GameObject child = transform.GetChild(0).gameObject;
                child.transform.Rotate(new Vector3(0, 0, GameManager._instance.rotateSpeed) * dir * Time.deltaTime);
                break;
            case BoxState.DESTROY:
                GameManager._instance.score++;
                uiManager.UpdateScore();
                Destroy(gameObject);
                break;
        }
    }
}
