using UnityEngine;

public class ScoreWall : MonoBehaviour
{

    public GameController gc;

    private void OnCollisionEnter(Collision collision)
    {

        gc.HandleScoring(gameObject.name);

    }

}
