using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacmanMove3 : MonoBehaviour {

    public float speed = 0.2f;
    Vector2 dest = Vector2.zero;
    public Camera main_camera;
    private bool face_right = true;
    // Use this for initialization
    void Start () {
        this.GetComponent<Transform>().position = new Vector2(PlayerInfo.map3x, PlayerInfo.map3y);
        dest = transform.position;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        // Move closer to Destination
        /*
        GetComponent<Animator>().SetFloat("DirX", 0);

        GetComponent<Animator>().SetFloat("DirY", 0);
        */
        Vector2 p = Vector2.MoveTowards(transform.position, dest, speed);
        GetComponent<Rigidbody2D>().MovePosition(p);

        // Check for Input if not moving
        if ((Vector2)transform.position != dest)
        {
            if (Input.GetKey(KeyCode.UpArrow) && valid(Vector2.up))
                dest = (Vector2)transform.position + Vector2.up;
            else if (Input.GetKey(KeyCode.RightArrow) && valid(Vector2.right))
            {
                dest = (Vector2)transform.position + Vector2.right;
                if(!face_right)
                {
                    face_right = !face_right;
                    transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
                }
            }
            else if (Input.GetKey(KeyCode.DownArrow) && valid(-Vector2.up))
                dest = (Vector2)transform.position - Vector2.up;
            else if (Input.GetKey(KeyCode.LeftArrow) && valid(-Vector2.right))
            {
                dest = (Vector2)transform.position - Vector2.right;
                if(face_right)
                {
                    face_right = !face_right;
                    transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
                }
            }
        }
        if (PlayerInfo.if_card3 && transform.position.x > 20 && transform.position.x < 51 && transform.position.y > -98 && transform.position.y < -73)
        {
            Application.LoadLevel(9);
            PlayerInfo.if_card3 = false;
            PlayerInfo.map3x = transform.position.x;
            PlayerInfo.map3y = transform.position.y;
        }

        if (PlayerInfo.if_level3 && transform.position.x > 105 && transform.position.x < 129 && transform.position.y > 301 && transform.position.y < 326)
        {
            Application.LoadLevel(8);
            PlayerInfo.if_metlevel3 = true;
            PlayerInfo.map3x = transform.position.x;
            PlayerInfo.map3y = transform.position.y-10;
        }

        if (PlayerInfo.if_metlevel3 && !PlayerInfo.if_card3 && transform.position.x > -71 && transform.position.x < -56 && transform.position.y > 282 && transform.position.y <304)
        {
            PlayerInfo.RefreshMap();
            Application.LoadLevel(10);          

        }

        if (transform.position.x > -54 && transform.position.x < -39 && transform.position.y >3 && transform.position.y < 24)
        {
            PlayerInfo.if_bulb3 = true;

        }
        if (PlayerInfo.if_bulb3)
        { main_camera.fieldOfView = 170; }

        // Animation Parameters
        /*
        Vector2 dir = dest - (Vector2)transform.position;
        GetComponent<Animator>().SetFloat("DirX", dir.x);
        GetComponent<Animator>().SetFloat("DirY", dir.y);
        */
    }

    bool valid(Vector2 dir)
    {
        // Cast Line from 'next to Pac-Man' to 'Pac-Man'
        Vector2 pos = transform.position;
        RaycastHit2D hit = Physics2D.Linecast(pos + dir, pos);
        return (hit.collider == GetComponent<Collider2D>());
    }


}
