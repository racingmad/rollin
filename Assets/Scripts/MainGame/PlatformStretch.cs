using UnityEngine;
using System.Collections;

public class PlatformStretch : MonoBehaviour {

    public float stretchSpeed;
    public float minSize;
    public float maxSize;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float moveVertical = Input.GetAxis("Vertical"); 
        //Stretches platform relative to input
        if (transform.localScale.x >= minSize && transform.localScale.x <= maxSize)
            transform.localScale += new Vector3(moveVertical * stretchSpeed, 0, 0);
        //Gradually expands to minimum size if pushed below that size
        else if (transform.localScale.x < minSize)
            transform.localScale += new Vector3(0.02f, 0, 0);
        //Gradually shrinks to maximum size if platform exceeds that size
        else if (transform.localScale.x > maxSize)
            transform.localScale += new Vector3(-0.02f, 0, 0);
	}
}
