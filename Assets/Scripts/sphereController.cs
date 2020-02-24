using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : MonoBehaviour
{
    public float thrust = 600.0f;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * -thrust);

    }

}
