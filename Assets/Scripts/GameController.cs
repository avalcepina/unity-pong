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
    private GameState gameState;
    public int scoreIncrease;
    public int startingLives;
    public ScoreWall rightWall;
    public ScoreWall leftWall;
    public Text livesText;
    public Text scoreText;

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
            if (Input.anyKey)
            {
                StartDemoGame();
            }
        }
    }

    public void StartDemoGame()
    {

        gameState = GameState.DEMO;



        gameOverPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
        gamePanel.SetActive(false);

        ResetGame();


    }

    public void EndGame()
    {

        gameState = GameState.GAMEOVER;

        GameObject[] gos = GameObject.FindGameObjectsWithTag("Interactive");

        foreach (var go in gos)
        {
            GameObject.Destroy(go);
        }

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

                scoreText.text = (Int64.Parse(scoreText.text) + scoreIncrease).ToString();

                ResetGame();

            }
            else if (wallName == rightWall.name)
            {

                int newLivesValue = Int16.Parse(livesText.text) - 1;

                livesText.text = newLivesValue.ToString();

                if (newLivesValue <= 0)
                {
                    EndGame();
                }
                else
                {

                    ResetGame();
                }

            }


        }


    }

    public void StartNewGame()
    {

        gameState = GameState.PLAYING;

        scoreText.text = "0";
        livesText.text = startingLives.ToString();


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

        GameObject sphereObject = Instantiate(sphere, new Vector3(16, 0, 0), Quaternion.identity);

        enemy.GetComponent<EnemyController>().sphere = sphereObject;

        Instantiate(enemy, new Vector3(1, 0, 0), Quaternion.Euler(0, 180, 0));

        if (gameState == GameState.DEMO)
        {


            Instantiate(enemy, new Vector3(31, 0, 0), Quaternion.Euler(0, 180, 0));

        }
        else
        {

            Instantiate(player, new Vector3(31, 0, 0), Quaternion.Euler(0, 180, 0));
        }


        SphereController sc = sphereObject.GetComponent<SphereController>();

        sc.StartMoving();

    }

    public void Quit()
    {
        Application.Quit();
    }

}
