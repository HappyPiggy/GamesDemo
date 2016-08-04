using UnityEngine;
using System.Collections;

public class shell : MonoBehaviour {

    public GameObject shellExplosionPrefab;
    public AudioClip fireAudio;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnTriggerEnter(Collider collider) {
        AudioSource.PlayClipAtPoint(fireAudio, transform.position);
        GameObject.Instantiate(shellExplosionPrefab, transform.position, transform.rotation);
        GameObject.Destroy(this.gameObject);

        if (collider.tag == "Tank")
        {
            collider.SendMessage("TakeDamage");
        }
    }
}
