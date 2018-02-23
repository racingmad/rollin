using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
    //Taken from https://unity3d.com/learn/tutorials/projects/roll-ball-tutorial/moving-camera?playlist=17141
    public GameObject player;

    private Vector3 offset;

	// Use this for initialization
	void Start () {
	    offset = transform.position - player.transform.position;
    }
	
	// Update is called once per frame
	void LateUpdate () {
        transform.position = player.transform.position + offset;
    }
}
