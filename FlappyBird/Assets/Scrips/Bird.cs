using UnityEngine;
using System.Collections;

public class Bird : MonoBehaviour
{

    private float timer = 0;
    public int frameCount = 0; //帧数计时器
    public int frameNumber = 10;//每秒10帧
    public float speed = 5.0f;


    private void Start()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(speed,0,0);
    }

    // Update is called once per frame
	void Update ()
	{
	    timer += Time.deltaTime;
	    if (timer >= 1.0f/frameNumber)
	    {
	        frameCount++;
	        int frameIndex = frameCount%3;
            GetComponent<Renderer>().material.SetTextureOffset("_MainTex",new Vector2(0.3333f*frameIndex,0));
	        timer -= 1.0f/frameNumber;
	    }
	}
}
