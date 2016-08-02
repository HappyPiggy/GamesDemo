using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour {


    private AudioSource audioSource;
	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.name == "Ball") {
            audioSource.pitch = Random.Range(0.6f, 1.2f);
            audioSource.Play();
        
        }

       
    }
}
