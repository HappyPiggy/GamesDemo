using UnityEngine;
using System.Collections;

public class Destory : MonoBehaviour {

    public float time;
	// Use this for initialization
	void Start () {
        GameObject.Destroy(this.gameObject, time);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
