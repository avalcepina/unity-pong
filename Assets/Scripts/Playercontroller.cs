using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{

    public float moveSpeed = 15.0f;
    public float movingBoundary = 10;

    // Update is called once per frame
    void Update()
    {


        if (Input.GetAxis("Horizontal") > 0f && transform.position.x < movingBoundary)
            transform.Translate(new Vector3(0, 0, 1) * moveSpeed * Time.deltaTime);

        if (Input.GetAxis("Horizontal") < 0f && transform.position.x > -movingBoundary)
            transform.Translate(-new Vector3(0, 0, 1) * moveSpeed * Time.deltaTime);

    }
}
