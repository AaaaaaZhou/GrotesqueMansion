using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubble_control : MonoBehaviour {

    private bool stay;
    private bool up;
    public float count = 1f;
    public float delta_y = 0.8f;
	// Use this for initialization
	void Start () {
        stay = true;
        up = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(stay)
        {
            count -= Time.deltaTime;
        }
        else
        {
            if(up)
            {
                transform.Translate(Vector3.up * Time.deltaTime);
                delta_y -= Time.deltaTime;
            }
            else
            {
                transform.Translate(Vector3.down * Time.deltaTime);
                delta_y -= Time.deltaTime;
            }
        }

        if(count<=0)
        {
            count = 1f;
            stay = false;
        }
        if(delta_y<=0)
        {
            up = !up;
            stay = true;
            delta_y = 0.8f;
        }

        //print(stay);
	}
}
