using UnityEngine;

public class BounceControl : MonoBehaviour
{
    public float thrust = 0.00001f;

    private void OnCollisionEnter(Collision collision)
    {

        ContactPoint contact = collision.GetContact(0);

        Vector3 velocity = collision.rigidbody.velocity;

        if (contact.point.x > transform.position.x)
        {

            Vector3 direction = new Vector3(0, 0, 1);

            collision.rigidbody.AddForce(direction * thrust, ForceMode.Force);

            collision.rigidbody.AddForce(velocity / 10, ForceMode.VelocityChange);

        }
        else if (contact.point.x < transform.position.x)
        {

            Vector3 direction = new Vector3(0, 0, -1);

            collision.rigidbody.AddForce(direction * thrust, ForceMode.Force);

            collision.rigidbody.AddForce(velocity / 10, ForceMode.VelocityChange);
        }

    }

}
