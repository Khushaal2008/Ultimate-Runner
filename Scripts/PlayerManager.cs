using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public static bool gameOver;
    public GameObject gameOverPanel;

    public static bool isGameStarted;
    public GameObject startingText;

    public static int numberOfCoins;
    public Text coinsText;
    public Text scoreText;
     public int score;
    public Transform player;
    public int highScore;
    bool counterStart;
    public Text highScoreText;

    public AudioSource claps;
    
    
    void Start()
    {
        gameOver = false;
        Time.timeScale = 1;
        isGameStarted = false;
        numberOfCoins = PlayerPrefs.GetInt("NumberOfCoins",0);
        highScore = PlayerPrefs.GetInt("HighScore", highScore);
    counterStart = false;
        claps.Stop();
       
    }

    // Update is called once per frame
    void Update()
    {
        coinsText.text = "Coins: " + numberOfCoins;
        scoreText.text = "Score: " + score;
        highScoreText.text = "Highscore: " + highScore;
        if(isGameStarted == true)
        {
            counterStart = true;
        }

        if(counterStart)
        {
            //counter ++;
            score++;
        }
             
        if(gameOver)
        {
           //Time.timeScale = 0;
           isGameStarted = false;
           counterStart = false;

         
            score = score;
            if(score > highScore)
            {
                highScore = score;
                claps.Play();
            }
            PlayerPrefs.SetInt("HighScore", highScore);

            gameOverPanel.SetActive(true);
        }

        if(SwipeManager.tap && gameOver == false)
        {
            isGameStarted = true;
           // counterStart = true;
            //scoreCounter.text = "Score: " + counter;
            Destroy(startingText);
           
        }
        
    }

    public void MoveToCharacterSel()
    {
        SceneManager.LoadScene("CharacterSelection");
        Time.timeScale = 1;
    }
}
