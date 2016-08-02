using UnityEngine;
using System.Collections;

public class TankMovement : MonoBehaviour {

	public float speed=5;
    public float angularSpeed = 10;
    public float number = 1;
	private Rigidbody rigidbody;
    public AudioClip idleAudio;
    public AudioClip drivingAudio;

    private AudioSource audio;
	// Use this for initialization
	void Start () {
		audio=this.GetComponent<AudioSource>();
        rigidbody = this.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float v = Input.GetAxis ("VerticalPlayer"+number);
		rigidbody.velocity = transform.forward * v * speed;

		float h = Input.GetAxis("HorizontalPlayer"+number );
        rigidbody.angularVelocity = transform.up * h * angularSpeed;

        if (Mathf.Abs(h) > 0.1 || Mathf.Abs(v) > 0.1)
        {
            audio.clip = drivingAudio;
            if (!audio.isPlaying)
                audio.Play();
        }
        else {
            audio.clip = idleAudio;
            if (!audio.isPlaying)
                audio.Play();
        }
	}
}

