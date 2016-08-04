using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    private BoxCollider2D upWall;
    private BoxCollider2D downWall;
    private BoxCollider2D leftWall;
    private BoxCollider2D rightWall;

    private int score1;
    private int score2;

    public Text score1Text;
    public Text score2Text;
    public Transform player1;
    public Transform player2;

    private static GameManager _instance;
    public static GameManager Instance {
        get {
            return _instance;
        }
    }


    void Awake() {
        _instance = this;
    }



	// Use this for initialization
	void Start () {
        ResetWall();
        ResetPlayer();
	}


    void ResetWall() {
        upWall = transform.Find("upWall").GetComponent<BoxCollider2D>();
        downWall = transform.Find("downWall").GetComponent<BoxCollider2D>();
        leftWall = transform.Find("leftWall").GetComponent<BoxCollider2D>();
        rightWall = transform.Find("rightWall").GetComponent<BoxCollider2D>();

        //其实固定一个屏幕坐标就够了。。
        Vector3 upWallPosition= Camera.main.ScreenToWorldPoint(new Vector2(Screen.width/2,Screen.height));
        upWall.transform.position = upWallPosition +new Vector3(0, 0.5f, 0);
        float width = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).x *2;
        upWall.size=new Vector2(width,1);


        Vector3 downWallPosition = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width / 2, 0));
        downWall.transform.position = downWallPosition - new Vector3(0, 0.5f, 0);
        downWall.size = new Vector2(width, 1);



        Vector3 leftWallPosition = Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height/2));
        leftWall.transform.position = leftWallPosition - new Vector3(0.5f, 0, 0);
        float height = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).y * 2;
        leftWall.size = new Vector2(1, height);

        Vector3 rightWallPosition = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height / 2));
        rightWall.transform.position = rightWallPosition +new Vector3(0.5f, 0, 0);
        rightWall.size = new Vector2(1, height);

    
    }


    void ResetPlayer() {
       Vector2 tempPosition= Camera.main.ScreenToWorldPoint(new Vector2(100, Screen.height / 2));
       player1.position = tempPosition;

       Vector2 tempPosition2 = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width- 100, Screen.height / 2));
       player2.position = tempPosition2;


    }


   public void ChangeScore(string name) {

       if (name == "leftWall") {
           score2++;
       }
       else if (name == "rightWall") {
           score1++;
       }

       score1Text.text = score1.ToString();
       score2Text.text = score2.ToString();
    
    }



    public void  Reset(){

        //分数0
        score1 = 0;
        score2 = 0;
        score1Text.text = score1.ToString();
        score2Text.text = score2.ToString();

        //球归位
        GameObject.Find("Ball").SendMessage("Reset");
    }
}
