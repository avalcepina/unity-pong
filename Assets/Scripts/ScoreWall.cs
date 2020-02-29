using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreWall : MonoBehaviour
{

    [SerializeField]
    public GameController gc;

    private void OnCollisionEnter(Collision collision)
    {

        gc.HandleScoring();

    }

}
