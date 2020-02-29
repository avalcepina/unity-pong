using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{

    public float moveSpeed = 20.0f;

    // Update is called once per frame
    void Update()
    {


        // if (Input.GetAxis("Vertical") > 0f)
        //     transform.Translate(new Vector3(0, 0, 1) * moveSpeed * Time.deltaTime);

        // if (Input.GetAxis("Vertical") < 0f)
        //     transform.Translate(-new Vector3(0, 0, 1) * moveSpeed * Time.deltaTime);

        var move = new Vector3(0, 0, Input.GetAxis("Vertical"));
        transform.position += move * moveSpeed * Time.deltaTime;

    }
}
