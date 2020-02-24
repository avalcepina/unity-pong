using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public GameObject sphere;
    public float moveSpeed = 20.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        float distance = Mathf.Abs(sphere.transform.position.x - transform.position.x);

        if (distance <= 15)
        {

            if (sphere.transform.position.z > transform.position.z + 2)
            {
                transform.Translate(new Vector3(0, 0, 1) * -moveSpeed * Time.deltaTime);
            }

            if (sphere.transform.position.z < transform.position.z - 2)
            {
                transform.Translate(new Vector3(0, 0, 1) * moveSpeed * Time.deltaTime);
            }

        }

    }
}
