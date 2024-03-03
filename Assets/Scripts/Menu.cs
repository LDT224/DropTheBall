using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Text bestScore;
    public Text played;
    //public Button play;
    //public Button skins;
    //public Button challenges;
    //public Button progress;

    // Start is called before the first frame update
    void Start()
    {
        bestScore.text = "Best score: " + PlayerPrefs.GetInt("highScore").ToString();
        played.text = "Game played: " + PlayerPrefs.GetInt("played").ToString();
    }
    public void PlayBtn()
    {
        SceneManager.LoadScene(2);
        PlayerPrefs.SetInt("played", PlayerPrefs.GetInt("played")+1);
        GameManager._instance.m_gameState = GameManager.GAMESTATE.INIT;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
