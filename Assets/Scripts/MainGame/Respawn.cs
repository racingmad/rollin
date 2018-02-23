using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour {
    public AudioClip checkpointSound;

    private AudioSource source;
    private Rigidbody rb;
    float spawnPointX;
    float spawnPointY;

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    void Start()
    {
        //Takes Rigidbody of the player object and sets up the initial spawn point
        rb = GetComponent<Rigidbody>();
        spawnPointX = 0;
        spawnPointY = 2;
    }

	// Update is called once per frame
	void FixedUpdate () {
        //Taken from http://answers.unity3d.com/questions/971938/respawn-from-falling-off-world.html
        if (transform.position.y < -50) //Respawns after the player is below a certain height
        {
            transform.position = new Vector3(spawnPointX, spawnPointY, 0); //Relocates player to spawn point
            rb.velocity = new Vector3(0, 0, 0); //Keeps player still on respawn
        }
            
	}

    //Partially taken from http://answers.unity3d.com/questions/46955/simple-checkpoint-system.html
    void OnTriggerEnter (Collider playerCollision)
    {
        //Sets new spawn point when checkpoint is collected
        if(playerCollision.gameObject.CompareTag("Respawn"))
        {
            spawnPointX = playerCollision.transform.position.x;
            spawnPointY = playerCollision.transform.position.y;
            playerCollision.gameObject.SetActive(false); //Object will Disappear
            source.PlayOneShot(checkpointSound, 1.0f);
        }

        //Ends Game when finish is collected
        if (playerCollision.gameObject.CompareTag("End"))
            SceneManager.LoadScene("EndGame");

    }
}
