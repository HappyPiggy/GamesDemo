using UnityEngine;
using System.Collections;
using System.Diagnostics;

public class bling : MonoBehaviour
{
    public string str;
    public Texture imageTexture;
    private int width;
    private int height;
    private int swidth;
    private int sheight;

	// Use this for initialization
	void Start ()
	{
	    swidth = Screen.width;
	    sheight = Screen.height;
	    width = imageTexture.width;
	    height = imageTexture.height;
	}
	
	// Update is called once per frame
	void OnGUI ()
	{

	    GUI.Label(new Rect(100, 10, 100, 30), str);
	    GUI.Label(new Rect(100,40,120,30),"当前屏幕高度："+swidth);
	    GUI.Label(new Rect(100,80,100,30),"当前屏幕高:"+sheight);
	    GUI.Label(new Rect(100,120,width,height),imageTexture);
	}
}
