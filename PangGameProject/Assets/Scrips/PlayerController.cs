using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {


    public KeyCode upKey;
    public KeyCode upDown;
    public float speed = 10;

    private Rigidbody2D rigidbody;
    private AudioSource audioSource;

	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();

	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(upKey)) {

            rigidbody.velocity = new Vector2(0,speed);
        }
        else if (Input.GetKey(upDown))
        {

            rigidbody.velocity = new Vector2(0, -speed);
        }
        else {
            rigidbody.velocity = new Vector2(0, 0);
        }

	}

    void OnCollisionEnter2D(Collision2D col) {

        if (col.gameObject.name == "Ball") {
            audioSource.pitch = Random.Range(0.6f, 1.2f);
            audioSource.Play();
    
        }
     
    }
}
