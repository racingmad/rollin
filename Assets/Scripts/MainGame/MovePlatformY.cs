using UnityEngine;
using System.Collections;

public class MovePlatformY : MonoBehaviour
{

    private float startPosition;

    public float travelDistance;
    public float speed;

    private Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        GetComponent<Rigidbody>().constraints = ~RigidbodyConstraints.FreezePositionY; //Freezes all but y position
        startPosition = transform.position.y; //Sets start position
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveVertical = Input.GetAxis("Vertical");
        rb.velocity = Vector3.zero; //Keeps platform still to prevent kinetic movement
        rb.AddForce(0, moveVertical * speed, 0); //Moves platform in direction relative to Input

        //If the platform is moving up
        if (speed >= 0)
        {
            //Pushes the positive platform to the up when the platform goes past the start position
            if (transform.position.y < startPosition)
                rb.AddForce(0, speed + 40, 0);
            //Pushes the negative platform to the down when the platform goes past the end position
            else if (transform.position.y > startPosition + travelDistance)
                rb.AddForce(0, -speed - 40, 0);
        }

        //If the platform is moving down
        else if (speed < 0)
        {
            //Pushes positive platform down to counteract movement 
            if (transform.position.y > startPosition)
                rb.AddForce(0, speed - 40, 0);
            //Pushes negative platform up to counteract movement
            else if (transform.position.y < startPosition - travelDistance)
                rb.AddForce(0, -speed + 40, 0);
        }

    }
}