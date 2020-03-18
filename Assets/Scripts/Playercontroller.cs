using UnityEngine;

public class Playercontroller : MonoBehaviour
{

    public float moveSpeed = 20.0f;

    // Update is called once per frame
    void Update()
    {

        var move = new Vector3(0, 0, Input.GetAxis("Vertical"));
        transform.position += move * moveSpeed * Time.deltaTime;

    }
}
