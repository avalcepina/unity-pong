using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceControl : MonoBehaviour
{
    public float thrust = 100.0f;

    private void OnCollisionEnter(Collision collision)
    {

        ContactPoint contact = collision.GetContact(0);
        //float distance = Vector3.Distance(contact.point, transform.position);

        Vector3 direction = contact.point - transform.position;


        // Vector3 velocity = collision.rigidbody.velocity;


        // collision.
        // direction = new Vector3(direction.x, 0, direction.z);

        collision.rigidbody.AddForce(direction * thrust);

    }

}
