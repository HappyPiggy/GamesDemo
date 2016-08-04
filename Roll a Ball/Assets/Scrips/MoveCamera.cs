using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour
{

    public GameObject Player;

    private Vector3 offset;

    private void Start()
    {
        offset = transform.position - Player.transform.position;
    }

 
	void LateUpdate ()
	{
	    transform.position = Player.transform.position + offset;

	}
}
