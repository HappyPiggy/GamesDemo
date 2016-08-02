using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour
{
    private string editUsername;
    private string editPassword;
    private string editshow;
	// Use this for initialization
	void Start ()
	{
	    editshow = "请您输入用户名和密码";
	    editUsername = "请您输入用户名";
	    editPassword = "请输入密码";

	}
	
	// Update is called once per frame
	void OnGUI ()
	{
	    GUI.Label(new Rect(10,10,Screen.width,30),editshow);
	    if (GUI.Button(new Rect(10, 120, 100, 50), "登录"))
	    {
	        editshow = "您输入的用户名："+editUsername+"您输入的密码为："+editPassword;
	    }
	    GUI.Label(new Rect(10,40,50,30),"用户名");
	    GUI.Label(new Rect(10,80,50,30),"密码:");
	    editUsername = GUI.TextField(new Rect(60,40,200,30),editUsername,15);
	    editPassword = GUI.PasswordField(new Rect(60,80,200,30),editPassword,"*"[0],15);

	}
}
