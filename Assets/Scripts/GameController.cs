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

        // We only need to handle the game over state, in which we wait for a click to restart the game
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

    // Setting up demo game
    public void StartDemoGame()
    {

        // Setting game state
        gameState = GameState.DEMO;

        // Setting up ui
        victoryPanel.SetActive(false);
        gameOverPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
        gamePanel.SetActive(false);

        // Resetting game
        ResetGame();


    }

    // Diplaying victory screen
    public void Victory()
    {
        // Resetting timer to handle click event
        timeSinceGameOver = 0;

        // Setting game state
        gameState = GameState.GAMEOVER;

        // Destroying all interactive objects
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Interactive");

        foreach (var go in gos)
        {
            GameObject.Destroy(go);
        }

        // Setting up ui
        victoryPanel.SetActive(true);
        gameOverPanel.SetActive(false);
        mainMenuPanel.SetActive(false);
        gamePanel.SetActive(false);

    }

    public void GameOver()
    {

        // Resetting timer to handle click event
        timeSinceGameOver = 0;

        // Setting game state
        gameState = GameState.GAMEOVER;

        // Destroying all interactive objects
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Interactive");

        foreach (var go in gos)
        {
            GameObject.Destroy(go);
        }

        // Setting up ui
        victoryPanel.SetActive(false);
        gameOverPanel.SetActive(true);
        mainMenuPanel.SetActive(false);
        gamePanel.SetActive(false);

    }

    // Handle score increase
    public void HandleScoring(string wallName)
    {

        if (gameState == GameState.PLAYING)
        {

            if (wallName == leftWall.name)
            {

                // Increasing player 1 score
                int newScoreValue = Int16.Parse(player1ScoreText.text) + 1;

                player1ScoreText.text = newScoreValue.ToString();

                //Checking victory condition
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

                // Increasing player 2 score
                int newScoreValue = Int16.Parse(player2ScoreText.text) + 1;

                player2ScoreText.text = newScoreValue.ToString();

                // Checking loss condition
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

            // Resetting game if we are in demo state
            ResetGame();
        }


    }


    // Starting new game
    public void StartNewGame()
    {

        // Setting game state
        gameState = GameState.PLAYING;

        // Resetting score
        player1ScoreText.text = "0";
        player2ScoreText.text = "0";

        // Setting up ui
        victoryPanel.SetActive(false);
        gameOverPanel.SetActive(false);
        mainMenuPanel.SetActive(false);
        gamePanel.SetActive(true);

        // Resetting game
        ResetGame();

    }

    // Resets game to starting state
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

    // Quit game
    public void Quit()
    {
        Application.Quit();
    }

}
