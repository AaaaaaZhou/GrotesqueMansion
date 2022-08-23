using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stupid_up_down : MonoBehaviour {


    //private bool stay;
    private bool up;
    private float tmp;
    //public float count = 0f;
    public float delta_y = 0.8f;
    public float speed = 2;
    // Use this for initialization
    void Start()
    {
        //stay = true;
        //tmp = delta_y;
        //up = true;
        if (delta_y > 0)
            up = true;
        else
            up = false;

        tmp = Mathf.Abs(delta_y);
    }

    // Update is called once per frame
    void Update()
    {
        //if (stay)
        //{
            //count -= Time.deltaTime;
        //}
        //else
        {
            if (up)
            {
                transform.Translate(Vector3.up * Time.deltaTime * speed);
                tmp -= Time.deltaTime;
            }
            else
            {
                transform.Translate(Vector3.down * Time.deltaTime * speed);
                tmp -= Time.deltaTime;
            }
        }

        /*
        if (count <= 0)
        {
            count = 1f;
            stay = false;
        }
        */
        if (tmp <= 0)
        {
            up = !up;
            //stay = true;
            //tmp = delta_y;
            tmp = Mathf.Abs(delta_y);
        }

        //print(stay);
    }
}
