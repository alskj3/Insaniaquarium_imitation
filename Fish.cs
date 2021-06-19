using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //씬전환
using UnityEngine.UI; //UI

public class Fish : MonoBehaviour
{
    public float speed = 2; //이동속도
    public int exp = 0; //경험치
    public float hunger = 5; //배고픔수치 (0 = 죽음, 10 = 배부름)
    public int level = 1;
    public GameObject coin;    // 만드는 프리팹 : Inspector에 지정
    public float intervalSec = 12; // 작성 간격（초）：Inspector로에 지정한다
    public int money = 0;
    public Text text;

    Animator animator;
    Rigidbody2D rbody;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        rbody.gravityScale = 0; //중력 0
        rbody.constraints = RigidbodyConstraints2D.FreezeRotation; //회전x
        animator = GetComponent<Animator>();
        InvokeRepeating("CreateCoin", intervalSec, intervalSec); //지정한 초마다 " " 실행
        text.text = "" + money;
    }

    // Update is called once per frame
    void FixedUpdate() //일정 시간마다 시행
    {
        rbody.velocity = new Vector2(-speed, 0); //수평으로 이동
        FindFood();
        hunger -= (float)0.004;
        if(hunger <= 0) //사망
        {
            rbody.velocity = new Vector2(0, -1);
            animator.SetBool("Die", true);
            Destroy(this.gameObject, (float)2.5);
        }
        else if (hunger <= 3.5 && hunger > 0) //배고픈 상태
        {
            animator.SetBool("hungry", true);
        }
        else if(hunger > 3.5 && hunger < 10) //멀쩡한 상태
        {
            animator.SetBool("hungry", false);
        }
        else
        {
            //배부름
        }
        if (money >= 20)
        {
            SceneManager.LoadScene("Clear"); //씬 전환
        }

    }

    private void OnCollisionEnter2D(Collision2D collision) //충돌했을 때
    {
        if (collision.gameObject.tag == "wall") //벽과 충돌시
        {
            speed = -speed; //방향 반전
            this.GetComponent<SpriteRenderer>().flipX = (speed < 0); //이미지 반전
        }

        if (collision.gameObject.tag == "food") //먹이 먹으면
        {
            speed = 2;
           // if(hunger < 10) //배고플때만 
           // {
                Destroy(collision.gameObject, 0);
                exp++;
                hunger += 3;
           // }
            
            if(exp == 5) //레벨업
            {
                animator.SetBool("LevelUp", true);
                level++;
            }
        }
    }

    void FindFood() //먹이쪽으로 이동하는 함수
    {
        //if (hunger < 10) //배부름이 10이하면
        //{
            GameObject target = GameObject.FindWithTag("food"); //food 태그를 찾아
            if (target)
            {
                speed = 4;
                //일정한 속도로 따라감
                Vector3 dir = (target.transform.position - this.transform.position).normalized;
                float vx = dir.x * speed;
                float vy = dir.y * speed;
                rbody.velocity = new Vector2(vx, vy);
                if(vx > 0)
                {
                    this.GetComponent<SpriteRenderer>().flipX = (vx > 0); //이미지 반전
                }
                
            }
            
        //}
    }

    void CreateCoin()
    {
        if(level > 1)
        {
            //물고기 위치에 코인 생성
            GameObject newGameObject = Instantiate(coin) as GameObject;
            Vector3 pos = this.transform.position;
            pos.z = -5; // 앞에 표시 
            newGameObject.transform.position = pos;
            money += 5;
            text.text = "" + money;
        }
    }
}
