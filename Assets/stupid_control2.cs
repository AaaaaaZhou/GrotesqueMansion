using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class stupid_control2 : MonoBehaviour
{

    public float move_speed = 10f;//运动参数
    [Range(0, 1)]
    public float sliding = 0.8f;
    public float jump_force = 1600f;

    //public Text test_text;//输出文本--test---Note: using UnityEngine.UI;
    public int life;//生命值

    private float initial_gravity_scale;//保留信息

    private bool ground;//二段跳检测
    private bool duo_jump;

    private float timeInAir;//置空和扶墙的检测
    private bool on_wall;
    private bool canHold;
    //private float dropForce = 2.4f;//增添的迫使下滑的力-------测试
    //下滑时卡住的原因推测为卡模

    private bool canDig;//凿墙的检测

    private bool recovering = false;//受伤之后的状态---测试
    private float recover_time = 1.6f;//受伤后的无敌时间


    private void Start()
    {
        initial_gravity_scale = gameObject.GetComponent<Rigidbody2D>().gravityScale;
        timeInAir = 0;
        canHold = false;
        duo_jump = false;
        canDig = false;
        life = 3;//--------------
    }


    bool isGround()
    {
        Bounds bound = GetComponent<Collider2D>().bounds;
        float offset = bound.size.y * 0.1f;
        Vector2 v = new Vector2(bound.center.x, bound.min.y - offset);
        RaycastHit2D hit = Physics2D.Linecast(v, bound.center);
        return (hit.collider.gameObject != gameObject);
    }

    GameObject onWall()
    {
        //if (isGround())
        //    return false;
        Bounds bound = GetComponent<Collider2D>().bounds;
        float offset = bound.size.x * 0.1f;
        float face;
        if (transform.localScale.x > 0)
            face = bound.max.x + offset;
        else
            face = bound.min.x - offset;
        Vector2 v = new Vector2(face, bound.center.y);
        RaycastHit2D hit = Physics2D.Linecast(v, bound.center);

        return hit.collider.gameObject;
    }

    private void recover()
    {
        if (recover_time == 1.6f)
        {
            float tmp = transform.localScale.x * -1;
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(tmp * 600, 1200));
            gameObject.GetComponent<Animator>().SetBool("recover", true);
            //print("recoverring!");
        }
        recover_time -= Time.deltaTime;
        if (recover_time <= 0)
        {
            recovering = false;
            recover_time = 1.6f;
            gameObject.GetComponent<Animator>().SetBool("recover", false);
            //print("recovered!");
        }
    }

    private void FixedUpdate()
    {
        if (recovering)
        {
            recover();
            //gameObject.GetComponent<Animator>().SetTrigger("recover");
            return;
        }
        float h = Input.GetAxis("Horizontal");
        Vector2 v = GetComponent<Rigidbody2D>().velocity;
        //print(v.y);
        //test_text.text = "Life: " + life;

        ground = isGround();//检测是否触地
        if (ground)//触地时设定允许二段跳
            duo_jump = true;

        GameObject wall = onWall();//检测是否上墙，变量wall为面对的gameObject
        if (on_wall && (wall == gameObject) && !ground)//翻墙判定：前一时刻在墙上 && 当前时刻不在墙上 && 不在地上
        {
            //on_wall = (wall != gameObject);
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jump_force * 0.5f);//翻墙：获得一个向上的力
        }

        on_wall = (wall != gameObject);

        if (h != 0)//移动控制
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(h * move_speed, v.y);
            transform.localScale = new Vector2(Mathf.Sign(h), transform.localScale.y);
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(v.x * sliding, v.y);
        }

        if (on_wall && !ground && timeInAir < 3)//扶墙：面对着墙 && 不在地面上 && 置空时间足够短
            canHold = true;
        else
            canHold = false;
        if (canHold)
        {
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
            timeInAir += Time.deltaTime;
            //gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.down * dropForce * timeInAir);//添加下滑力
        }
        else
        {
            gameObject.GetComponent<Rigidbody2D>().gravityScale = initial_gravity_scale;
            //gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.down * dropForce);
            timeInAir = 0;//置零还是为负值
        }
        GetComponent<Animator>().SetBool("onWall", canHold);

        if (on_wall && ground && h != 0 && wall.tag == "can_be_destroyed")//凿墙：面对着墙 && 在地面上 && 有面向墙的速度 && 墙为可摧毁物体
        {
            canDig = true;
            destructible tmp = wall.GetComponent<destructible>();
            tmp.damageWall();
        }
        else
            canDig = false;
        GetComponent<Animator>().SetBool("Digging", canDig);

        if (Input.GetKeyDown(KeyCode.Space))//跳跃和二段跳
        {
            if (on_wall)
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.up * 4;//--------------------------
            }
            else
            {
                if (ground)
                {
                    GetComponent<Rigidbody2D>().AddForce(Vector2.up * jump_force);
                }
                else if (duo_jump)
                {
                    GetComponent<Rigidbody2D>().AddForce(Vector2.up * jump_force * 0.5f);
                    duo_jump = false;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!recovering)
        {
            if (collision.gameObject.tag == "exit")
            {
                PlayerInfo.sanity -= 3;
                if (PlayerInfo.sanity < 0)
                    PlayerInfo.sanity = 0;
                PlayerInfo.if_level2 = false;
                PlayerInfo.wil += 3;
                Application.LoadLevel(4);
            }
            else if (collision.gameObject.tag == "traps")
            {
                life = life - 1;
                print("current HP: " + life);
                if (life == 0)
                {
                    //print("You Died!");////////////////////////////////
                    gameObject.SetActive(false);
                    PlayerInfo.sanity -= 3;
                    if (PlayerInfo.sanity < 0)
                        PlayerInfo.sanity = 0;
                    Application.LoadLevel(4);
                }
                //float tmp = transform.localScale.x * -1;
                //gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(tmp * 60, 10);
                //gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(tmp * 1200, 800));

                recovering = true;
            }
            else if (collision.gameObject.tag == "BIG_UP")
                gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.up * 30;
        }

    }

}
