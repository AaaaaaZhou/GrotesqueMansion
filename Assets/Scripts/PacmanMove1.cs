using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacmanMove1 : MonoBehaviour {

    public float speed = 1f;
    public Camera main_camera;
    Vector2 dest = Vector2.zero;
    private bool face_right = true;
    

    // Use this for initialization
    void Start () {
        //transform.position.x = PlayerInfo.map1x;

        //transform.Translate(new Vector2(PlayerInfo.map1x, PlayerInfo.map1y));

        this.GetComponent<Transform>().position = new Vector2(PlayerInfo.map1x, PlayerInfo.map1y);
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
        if (PlayerInfo.if_card1 && transform.position.x > 80 && transform.position.x < 95 && transform.position.y > -109 && transform.position.y < -95.7)
        {
            Application.LoadLevel(9);
            PlayerInfo.if_card1 = false;
            PlayerInfo.map1x = transform.position.x;
            PlayerInfo.map1y = transform.position.y;
        }

        if (PlayerInfo.if_level1 && transform.position.x >142 && transform.position.x < 163 && transform.position.y > 339 && transform.position.y < 359.5)
        {
            Application.LoadLevel(6);
            PlayerInfo.if_metlevel1 = true;
            PlayerInfo.map1x = transform.position.x;
            PlayerInfo.map1y = transform.position.y-15;
        }

        if (PlayerInfo.if_metlevel1 && !PlayerInfo.if_card1 && transform.position.x > 320 && transform.position.x < 341.5 && transform.position.y > 140 && transform.position.y < 171.1)
        {
            PlayerInfo.floor = 4;
            Application.LoadLevel(4);
            
            
        }

        if (transform.position.x > -89 && transform.position.x <-67.7 && transform.position.y > 7.5 && transform.position.y <31.5)
        {
            PlayerInfo.if_bulb1 = true;
           
            
        }

        if(PlayerInfo.if_bulb1)
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
