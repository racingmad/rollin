using UnityEngine;
using System.Collections;

public class MovePlatform : MonoBehaviour {

    private float startPosition;

    public float travelDistance;
    public float speed;

    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        GetComponent<Rigidbody>().constraints = ~RigidbodyConstraints.FreezePositionX; //Freezes all but x position
        startPosition = transform.position.x; //Sets start position
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float moveVertical = Input.GetAxis("Vertical");
        rb.velocity = Vector3.zero; //Keeps platform still to prevent kinetic movement
        rb.AddForce(moveVertical * speed, 0, 0); //Moves platform in direction relative to Input

        //If the platform is moving right
        if(speed >= 0)
        {
            //Pushes the positive platform to the right when the platform goes past the start position
            if (transform.position.x < startPosition)
                rb.AddForce(speed + 40, 0, 0);
            //Pushes the negative platform to the left when the platform goes past the end position
            else if (transform.position.x > startPosition + travelDistance)
                rb.AddForce(-speed - 40, 0, 0);
        }

        //If the platform is moving left
        else if(speed < 0)
        {
            //Pushes positive platform left to counteract movement 
            if (transform.position.x > startPosition)
                rb.AddForce(speed - 40, 0, 0);
            //Pushes negative platform right to counteract movement
            else if (transform.position.x < startPosition - travelDistance)
                rb.AddForce(-speed + 40, 0, 0);
        }
 
    }
}
