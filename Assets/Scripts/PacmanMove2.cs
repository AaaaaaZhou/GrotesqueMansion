using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacmanMove2 : MonoBehaviour {

    public float speed = 0.2f;
    public Camera main_camera;
    Vector2 dest = Vector2.zero;
    private bool face_right = true;
    // Use this for initialization
    void Start () {
        this.GetComponent<Transform>().position = new Vector2(PlayerInfo.map2x, PlayerInfo.map2y);
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
        if (PlayerInfo.if_card2 && transform.position.x > 123 && transform.position.x < 151 && transform.position.y > -146 && transform.position.y < -118)
        {
            Application.LoadLevel(9);
            PlayerInfo.if_card2 = false;
            PlayerInfo.map2x = transform.position.x;
            PlayerInfo.map2y = transform.position.y;
        }

        if (PlayerInfo.if_level2 && transform.position.x > 340 && transform.position.x <363 && transform.position.y >101 && transform.position.y < 125)
        {
            Application.LoadLevel(7);
            PlayerInfo.if_metlevel2 = true;
            PlayerInfo.map2x = transform.position.x;
            PlayerInfo.map2y = transform.position.y-10;
        }

        if (PlayerInfo.if_metlevel2 && !PlayerInfo.if_card2 && transform.position.x > 308 && transform.position.x < 329 && transform.position.y > 242 && transform.position.y < 266)
        {
            PlayerInfo.floor = 5;
            Application.LoadLevel(5);
            
        }

        if (transform.position.x >-364 && transform.position.x < -340 && transform.position.y > -69 && transform.position.y < -49)
        {
            PlayerInfo.if_bulb2 = true;

        }
        if (PlayerInfo.if_bulb2)
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
