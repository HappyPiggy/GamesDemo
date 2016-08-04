using UnityEngine;
using System.Collections;

public class FollowTarget : MonoBehaviour {

    public Transform Player1;
    public Transform Player2;

    private Vector3 offset;
    private Camera camera;
    private float distance;

	// Use this for initialization
	void Start () {
	    offset=transform.position-(Player1.position+Player2.position)/2;
        camera=this.GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Player2 && Player1)
        {
            distance = Vector3.Distance(Player1.position, Player2.position);
            transform.position = (Player1.position + Player2.position) / 2 + offset;
            float size = 0.50f * distance;
            camera.orthographicSize = size;
            Debug.Log(offset);
        }
	
	}
}
