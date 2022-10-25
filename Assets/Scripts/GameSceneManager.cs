using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameSceneManager : MonoBehaviour
{
    public Camera MainCamera;
    public Text ScoreText;
    public Text GameOverText;
    public PlayerController player;
    int score;
    float gameTimer;
    bool gameOver;


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1; //start time
        player.OnHitSpike += OnGameOver;
        player.OnHitCoin += OnHitCoin;
        ScoreText.enabled = true;
        GameOverText.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        MainCamera.transform.position = new Vector3(
        Mathf.Lerp(MainCamera.transform.position.x, player.transform.position.x, Time.deltaTime * 10),
        Mathf.Lerp(MainCamera.transform.position.y, player.transform.position.y, Time.deltaTime * 10),
        MainCamera.transform.position.z);
        if(gameOver) 
        {
            if(Input.GetKeyDown("r")) 
            {
	            SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	        }
	        return; // Skip the following lines if GameOver
        }
	
	    ScoreText.text = "Score: " + score;
	    if(player.transform.position.y < -10)
            OnGameOver();
    }
	
        private void OnHitCoin()
    {
        this.score += 100;
    }
    private void OnGameOver()
    {
        gameOver = true;
        ScoreText.enabled = false;
        GameOverText.enabled = true;
        GameOverText.text = "Game Over!\nPress R to Resart";

        Time.timeScale = 0; //stop time
    }
    
}
