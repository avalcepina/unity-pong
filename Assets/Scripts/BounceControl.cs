using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceControl : MonoBehaviour
{
    public float thrust = 0.00001f;

    private void OnCollisionEnter(Collision collision)
    {

        ContactPoint contact = collision.GetContact(0);
        //float distance = Vector3.Distance(contact.point, transform.position);




        Vector3 velocity = collision.rigidbody.velocity;


        if (velocity.x > 0)
        {

            Vector3 direction = new Vector3(0, 0, 1);

            collision.rigidbody.AddForce(direction * thrust, ForceMode.Force);

            collision.rigidbody.AddForce(velocity / 10, ForceMode.VelocityChange);

        }
        else
        {

            Vector3 direction = new Vector3(0, 0, -1);

            collision.rigidbody.AddForce(direction * thrust, ForceMode.Force);

            collision.rigidbody.AddForce(velocity / 10, ForceMode.VelocityChange);
        }

    }

}
