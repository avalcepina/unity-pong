using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : MonoBehaviour
{
    public float thrust = 600.0f;

    public void StartMoving()
    {
        GetComponent<Rigidbody>().AddForce(transform.right * -thrust);

    }

}
