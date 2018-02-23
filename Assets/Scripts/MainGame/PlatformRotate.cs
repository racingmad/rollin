using UnityEngine;
using System.Collections;

public class PlatformRotate : MonoBehaviour {

    public float rotateIntensity;
    
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        //Platform will rotate in a specific direction based on directional input
        float rotateControl = Input.GetAxis("Vertical");
        transform.Rotate(0, 0, rotateControl * -rotateIntensity);
	}
}
