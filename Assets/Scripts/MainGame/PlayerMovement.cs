using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float jumpHeight;
    public float rotateIntensity;
    public float maxSpeed;
    public float pushback;
    public AudioClip jumpSound;

    private Rigidbody rb;
    private float playerGravity = 3;
    private bool IsGrounded;
    private AudioSource source;

    void Awake()
    {
        //Takes the AudioSource component for sound
        source = GetComponent<AudioSource>();
    }
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        Physics.gravity = new Vector3(0, -rotateIntensity + playerGravity, 0); //Gravity is always 3 more than movement speed to emulate rolling motion

        //Taken from http://answers.unity3d.com/questions/1093545/freeze-rigidbody.html
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ;
	}

    void FixedUpdate ()
    {
        //Horizontal Controls
        float moveHorizontal = Input.GetAxis("Horizontal");

        //Jump
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded == true)
        {
            rb.AddForce(0, jumpHeight, 0);
            source.PlayOneShot(jumpSound, 0.1f);
        }

        //Slow down on movement
        if (rb.velocity.x > maxSpeed)
        {
            rb.AddForce(-pushback, 0, 0);
        }
        else if(rb.velocity.x < -maxSpeed)
        {
            rb.AddForce(pushback, 0, 0);
        }

        //Applied Movement
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0.0f);

        //Applied Control
        rb.AddForce(movement * rotateIntensity);

        //Quit Game
        if (Input.GetKey(KeyCode.Escape))
            Application.Quit();
    }

    //Taken from http://answers.unity3d.com/questions/149790/checking-if-grounded-on-rigidbody.html
    void OnCollisionStay(Collision collisionInfo)
    {
        IsGrounded = true;
    }

    void OnCollisionExit(Collision collisionInfo)
    {
        IsGrounded = false;
    }
}
