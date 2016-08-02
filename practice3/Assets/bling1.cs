using UnityEngine;
using System.Collections;

public class bling1 : MonoBehaviour
{
    public string str;
    public Texture2D buttonTexture;
    private int frameTime;
	// Use this for initialization
	void Start ()
	{
	    str = "请点击按钮";
	}
	
	// Update is called once per frame
	void OnGUI ()
	{
	    GUI.Label(new Rect(10,10,Screen.width,30),str);
	    if (GUI.Button(new Rect(10, 50, buttonTexture.width, buttonTexture.height), buttonTexture))
	    {
	        str = "您点击了这个按钮";
	    }
	    GUI.color = Color.green;
	    GUI.backgroundColor = Color.red;
	    if (GUI.Button(new Rect(10, 200, 70, 30), "文字按钮"))
	    {
	        str = "您点击了文字按钮";
	    }
	        GUI.color = Color.yellow;
	        GUI.backgroundColor = Color.black;
	    
	    if (GUI.RepeatButton(new Rect(10, 250, 100, 30), "按钮按下中"))
	        {
                str = "按钮按下中的时间：" + frameTime;
	            frameTime++;
	        }
	    

	}
}
