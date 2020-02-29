using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public GameObject player;
    public GameObject enemy;
    public GameObject sphere;
    public GameObject mainMenuPanel;
    public GameObject gamePanel;
    public GameObject gameOverPanel;
    private GameState gameState;

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

        GameObject[] gos = GameObject.FindGameObjectsWithTag("Interactive");

        foreach (var go in gos)
        {
            GameObject.Destroy(go);
        }

        gameOverPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
        gamePanel.SetActive(false);

        GameObject sphereObject = Instantiate(sphere, new Vector3(16, 0, 0), Quaternion.identity);

        enemy.GetComponent<EnemyController>().sphere = sphereObject;

        Instantiate(enemy, new Vector3(31, 0, 0), Quaternion.Euler(0, 180, 0));
        Instantiate(enemy, new Vector3(1, 0, 0), Quaternion.Euler(0, 180, 0));


        SphereController sc = sphereObject.GetComponent<SphereController>();

        sc.StartMoving();


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

    public void HandleScoring()
    {
        if (gameState == GameState.PLAYING)
        {
            EndGame();
        }
        else if (gameState == GameState.DEMO)
        {
            StartDemoGame();
        }
    }

    public void StartNewGame()
    {

        gameState = GameState.PLAYING;

        GameObject[] gos = GameObject.FindGameObjectsWithTag("Interactive");

        foreach (var go in gos)
        {
            GameObject.Destroy(go);
        }

        gameOverPanel.SetActive(false);
        mainMenuPanel.SetActive(false);
        gamePanel.SetActive(true);

        GameObject sphereObject = Instantiate(sphere, new Vector3(16, 0, 0), Quaternion.identity);

        enemy.GetComponent<EnemyController>().sphere = sphereObject;

        Instantiate(player, new Vector3(31, 0, 0), Quaternion.Euler(0, 180, 0));
        Instantiate(enemy, new Vector3(1, 0, 0), Quaternion.Euler(0, 180, 0));


        SphereController sc = sphereObject.GetComponent<SphereController>();

        sc.StartMoving();

    }

    public void Quit()
    {
        Application.Quit();
    }

}
