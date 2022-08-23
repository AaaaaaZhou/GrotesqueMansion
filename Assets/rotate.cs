using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour {
    public bool clockwise = true;
    public float speed = 1;

    private Vector3 dir;
	// Use this for initialization
	void Start () {
        if (clockwise)
            dir = Vector3.back;
        else
            dir = Vector3.forward;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(dir * speed);
	}
}
