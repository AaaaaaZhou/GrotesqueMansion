using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stupid_left_right : MonoBehaviour {

    public float delta_x = 2;
    public float speed = 2;

    private bool right = true;
    private float tmp;
	// Use this for initialization
	void Start () {
        if (delta_x > 0)
            right = true;
        else
            right = false;
        tmp = Mathf.Abs(delta_x);
	}
	
	// Update is called once per frame
	void Update () {
		if(right)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
            tmp -= Time.deltaTime;
        }
        else
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
            tmp -= Time.deltaTime;
        }

        if(tmp<=0)
        {
            right = !right;
            tmp = Mathf.Abs(delta_x);
        }
	}
}
