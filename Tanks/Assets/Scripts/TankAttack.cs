using UnityEngine;
using System.Collections;

public class TankAttack : MonoBehaviour {

	public GameObject shellPrefabs;
	public KeyCode fireKey=KeyCode.Space;
    public float shellSpeed = 15;
    public AudioClip shotAudio;

	private Transform firePosition;
	// Use this for initialization
	void Start () {
		firePosition = transform.Find ("FirePosition");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (fireKey)) {
            AudioSource.PlayClipAtPoint(shotAudio, transform.position);
			GameObject go= GameObject.Instantiate(shellPrefabs,firePosition.position,firePosition.rotation) as GameObject;
            go.GetComponent<Rigidbody>().velocity = transform.forward * shellSpeed;
		}
	}
}
