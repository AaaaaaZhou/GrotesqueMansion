using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap_enter : MonoBehaviour {

    public GameObject trap1;
    public GameObject trap2;
    // Use this for initialization
    private float count_time = 0.4f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        count_time -= Time.deltaTime;
        //if(count_time<0)
        {
            trap1.GetComponent<Rigidbody2D>().gravityScale = 1;
            trap2.GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }
}
