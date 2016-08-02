using UnityEngine;
using System.Collections;

public class BallManager : MonoBehaviour {

    public int ballSpeed = 100;
    private Rigidbody2D rigidbody2D;

	// Use this for initialization
	void Start () {

        rigidbody2D = GetComponent<Rigidbody2D>();

        InitBall();
	}


    void OnCollisionEnter2D(Collision2D col) {
        if (col.collider.tag == "Player") {
            Vector2 velocity = rigidbody2D.velocity;
            velocity.y = velocity.y / 2 + col.rigidbody.velocity.y;
           // Debug.Log(vel.y);
            rigidbody2D.velocity = velocity;

        }

        //改变分数
        if (col.gameObject.name == "leftWall" || col.gameObject.name == "rightWall")
        {
            GameManager.Instance.ChangeScore(col.gameObject.name);
        }
    }


	// Update is called once per frame
	void Update () {
        Vector2 velocity = rigidbody2D.velocity;
        if (Mathf.Abs(velocity.x) < 9 && velocity.x != 0) {
            if (velocity.x > 0)
            {
                velocity.x = 10;
            }
            else {
                velocity.x = -10;
            }
        }
        rigidbody2D.velocity = velocity;
	}


    public void Reset() {
        transform.position = Vector2.zero;
        InitBall();
    }

    void InitBall() {

        rigidbody2D.velocity = Vector2.zero;
        int number = Random.Range(0, 2);
        if (number == 1)
        {
            rigidbody2D.AddForce(new Vector2(ballSpeed, 0));
        }
        else
        {
            rigidbody2D.AddForce(new Vector2(-ballSpeed, 0));
        }
    
    }
}
