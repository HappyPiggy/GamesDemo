using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public AudioClip chopAudio1;
    public AudioClip chopAudio2;
    public AudioClip footAudio1;
    public AudioClip footAudio2;
    public AudioClip sodaAudio1;
    public AudioClip sodaAudio2;
    public AudioClip fruitAudio1;
    public AudioClip fruitAudio2;

    [HideInInspector]public  Vector2 targetPos = new Vector2(1,1);
    private Rigidbody2D rigidbody;
    private BoxCollider2D collider;
    private Animator animator;

    public float smoothing = 1;
    public float restTime = 1;
    public float restTimer = 0;

	// Use this for initialization
    private void Start()
    {

        rigidbody = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
	void Update ()
	{

	    rigidbody.MovePosition(Vector2.Lerp( transform.position,targetPos,smoothing*Time.deltaTime));
        

	    restTimer += Time.deltaTime;
	    if (restTimer<restTime)
	    {
	        return;
	    }

	    float h = Input.GetAxisRaw("Horizontal");
	    float v = Input.GetAxisRaw("Vertical");
     //   Debug.Log("h的值为" + h);
     //   Debug.Log("v的值为" + v);



        //纵向优先
	    if (h!=0)
	    {
	        v = 0;
	    }




	    if (h!=0||v!=0)
	    {

	      //  Debug.Log(GameManager.Instance.isEnd);
           
            //检测生命值,结束位置
	        if (GameManager.Instance.hp <= 0||GameManager.Instance.isEnd==true) return;


            AudioManager.Instance.RandomPlay(footAudio1, footAudio2);
            //检测主角碰到的物品
	        collider.enabled = false;
	        RaycastHit2D hit= Physics2D.Linecast(targetPos, targetPos + new Vector2(h, v));
	        collider.enabled = true;


	        if (hit.transform==null)
	        {
	            targetPos += new Vector2(h, v);
                GameManager.Instance.ReduceHp(1);
	        }
	        else
	        {
                switch (hit.collider.tag)
	            {
	                case "OutWall":
	                    break;
                    case"Wall":
	                    animator.SetTrigger("Attack");
                      //  Debug.Log("test");
                        AudioManager.Instance.RandomPlay(chopAudio1,chopAudio2);
	                    hit.collider.SendMessage("TakeDamage");
                        GameManager.Instance.ReduceHp(5);
	                    break;
                    case "Soda":
	                    GameManager.Instance.AddHp(20);
                        AudioManager.Instance.RandomPlay(sodaAudio1, sodaAudio2);
                        targetPos += new Vector2(h, v);
	                    Destroy(hit.transform.gameObject);
	                    break;
                    case "Food":
                        GameManager.Instance.AddHp(10);
                        AudioManager.Instance.RandomPlay(fruitAudio1,fruitAudio2);
                        targetPos += new Vector2(h, v);
                        Destroy(hit.transform.gameObject);
	                    break;
                    case "Enemy":
	                    animator.SetTrigger("Damage");
	                    break;
	            }
                  
	        }


	        GameManager.Instance.OnPlayerMove();
	        restTimer = 0;
	    }

	}

    public void TakeDamage(int losehp)
    {
        GameManager.Instance.ReduceHp(losehp);
    }

}
