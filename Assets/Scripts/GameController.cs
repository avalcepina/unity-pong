using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameController : MonoBehaviour
{

    public GameObject player;
    public GameObject enemy;
    public GameObject sphere;
    public GameObject mainMenuPanel;
    public GameObject gamePanel;
    public GameObject gameOverPanel;
    public GameObject victoryPanel;
    public ScoreWall rightWall;
    public ScoreWall leftWall;
    public Text player1ScoreText;
    public Text player2ScoreText;
    public int maximumScore;

    private GameState gameState;
    private float timeSinceGameOver;

    public GameState GetGameState()
    {
        return gameState;
    }

    public void Start()
    {
        StartDemoGame();
    }

    public void Update()
    {

        if (gameState == GameState.GAMEOVER)
        {
            if (Input.anyKey && timeSinceGameOver >= 2)
            {
                StartDemoGame();
            }
            else
            {
                timeSinceGameOver += Time.deltaTime;
            }
        }
    }

    public void StartDemoGame()
    {

        gameState = GameState.DEMO;


        victoryPanel.SetActive(false);
        gameOverPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
        gamePanel.SetActive(false);

        ResetGame();


    }

    public void Victory()
    {

        timeSinceGameOver = 0;
        gameState = GameState.GAMEOVER;

        GameObject[] gos = GameObject.FindGameObjectsWithTag("Interactive");

        foreach (var go in gos)
        {
            GameObject.Destroy(go);
        }

        victoryPanel.SetActive(true);
        gameOverPanel.SetActive(false);
        mainMenuPanel.SetActive(false);
        gamePanel.SetActive(false);

    }

    public void GameOver()
    {

        timeSinceGameOver = 0;
        gameState = GameState.GAMEOVER;

        GameObject[] gos = GameObject.FindGameObjectsWithTag("Interactive");

        foreach (var go in gos)
        {
            GameObject.Destroy(go);
        }

        victoryPanel.SetActive(false);
        gameOverPanel.SetActive(true);
        mainMenuPanel.SetActive(false);
        gamePanel.SetActive(false);

    }

    public void HandleScoring(string wallName)
    {



        if (gameState == GameState.PLAYING)
        {

            if (wallName == leftWall.name)
            {


                int newScoreValue = Int16.Parse(player1ScoreText.text) + 1;

                player1ScoreText.text = newScoreValue.ToString();

                if (newScoreValue >= maximumScore)
                {
                    Victory();
                }
                else
                {

                    ResetGame();
                }


            }
            else if (wallName == rightWall.name)
            {

                int newScoreValue = Int16.Parse(player2ScoreText.text) + 1;

                player2ScoreText.text = newScoreValue.ToString();

                if (newScoreValue >= maximumScore)
                {
                    GameOver();
                }
                else
                {

                    ResetGame();
                }


            }


        }
        else
        {

            ResetGame();
        }


    }


    public void HandleScore(Text playerScore)
    {



    }

    public void StartNewGame()
    {

        gameState = GameState.PLAYING;

        player1ScoreText.text = "0";
        player2ScoreText.text = "0";

        victoryPanel.SetActive(false);
        gameOverPanel.SetActive(false);
        mainMenuPanel.SetActive(false);
        gamePanel.SetActive(true);

        ResetGame();

    }

    private void ResetGame()
    {

        GameObject[] gos = GameObject.FindGameObjectsWithTag("Interactive");

        foreach (var go in gos)
        {
            GameObject.Destroy(go);
        }

        GameObject sphereObject = Instantiate(sphere, new Vector3(0, 0, 0), Quaternion.identity);

        enemy.GetComponent<EnemyController>().sphere = sphereObject;

        Instantiate(enemy, new Vector3(-15, 0, 0), Quaternion.Euler(0, 180, 0));

        if (gameState == GameState.DEMO)
        {


            Instantiate(enemy, new Vector3(15, 0, 0), Quaternion.Euler(0, 180, 0));

        }
        else
        {

            Instantiate(player, new Vector3(15, 0, 0), Quaternion.Euler(0, 180, 0));
        }


        SphereController sc = sphereObject.GetComponent<SphereController>();

        sc.StartMoving();

    }

    public void Quit()
    {
        Application.Quit();
    }

}
