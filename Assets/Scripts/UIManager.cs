using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text scoreTxt;
    public Text highScoreTxt;
    public GameObject losePopUp;
    public Text endScoreTxt;
    public Text endHighScoreTxt;
    // Start is called before the first frame update
    void Start()
    {
        scoreTxt.text = "0";
        highScoreTxt.text = PlayerPrefs.GetInt("highScore").ToString();
    }
    public void UpdateScore()
    {
        scoreTxt.text = GameManager._instance.score.ToString();
    }
    public void Lose()
    {
        losePopUp.SetActive(true);
    }
    public void Replay()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(1);
        //GameManager._instance.m_gameState = GameManager.GAMESTATE.INIT;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager._instance.score > PlayerPrefs.GetInt("highScore"))
        {
            highScoreTxt.text = GameManager._instance.score.ToString();
            PlayerPrefs.SetInt("highScore", GameManager._instance.score);
        }
        
        if(GameManager._instance.m_gameState == GameManager.GAMESTATE.END)
        {
            losePopUp.SetActive(true);
            endScoreTxt.text = GameManager._instance.score.ToString();
            endHighScoreTxt.text = "Best score: " + PlayerPrefs.GetInt("highScore").ToString();
            Time.timeScale = 0;
        }

    }
}
