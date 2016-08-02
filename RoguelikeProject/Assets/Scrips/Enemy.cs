using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{

    private Vector2 targetPosition;
    private Transform player;
    private Rigidbody2D rigidbody;
    private BoxCollider2D collider;
    private Animator animator;

    public int loseHp = 10;
    public float smoothing = 3;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rigidbody = GetComponent<Rigidbody2D>();
        targetPosition = transform.position;
        GameManager.Instance.EnemyList.Add(this);
        collider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        rigidbody.MovePosition( Vector2.Lerp(transform.position, targetPosition, smoothing*Time.deltaTime));
    }


    public void Move()
    {
        Vector2 offset = player.transform.position -transform.position;

        if (offset.magnitude < 1.1)
        {
            //进行攻击
         
                animator.SetTrigger("Attack");
                player.SendMessage("TakeDamage", loseHp);
               // Destroy(gameObject);
          
      
        }
        else
        {
            float x = 0, y = 0;
            //敌人移动
            if (Mathf.Abs(offset.y) >= Mathf.Abs(offset.x))
            {
                //向y方向移动
                if (offset.y > 0)
                {
                    y = 1;
                }
                else
                {
                    y = -1;
                }

            }
            else
            {
                //向x方向移动
                if (offset.x > 0)
                {
                    x = 1;
                }
                else
                {
                    x = -1;
                }
            }
         //   Debug.Log("!");

            collider.enabled = false;
            RaycastHit2D hit = Physics2D.Linecast(targetPosition, targetPosition + new Vector2(x, y));
            collider.enabled = true;

            if (hit.transform == null||hit.collider.tag=="Food"||hit.collider.tag=="Soda")
            {
                targetPosition += new Vector2(x, y);
            }
            
        }
    }

}
