using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevatorControl : MonoBehaviour {
    public GameObject start_point;
    public GameObject end_point;
    public float speed = 5;
    private bool on = false;
    private float X;
    private float Y;
	// Use this for initialization
	void Start () {
        X = end_point.transform.position.x - start_point.transform.position.x;
        Y = end_point.transform.position.y - start_point.transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		if(on && (X!=0 || Y!=0))
        {
            Vector3 tmp = new Vector3(X * Time.deltaTime, Y * Time.deltaTime, 0);
            X -= X * Time.deltaTime;
            Y -= Y * Time.deltaTime;
            transform.Translate(tmp);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "character")
            on = true;
    }
}
