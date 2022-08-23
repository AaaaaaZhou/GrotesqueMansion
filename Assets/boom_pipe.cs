using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boom_pipe : MonoBehaviour {

    public GameObject brick1;
    public GameObject brick2;
    public GameObject brick3;

    private float wait = 1.6f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        brick1.transform.Translate(Vector3.up*Time.deltaTime);
        brick2.transform.Translate(Vector3.up*Time.deltaTime);
        brick3.transform.Translate(Vector3.up*Time.deltaTime);
        while (wait > 0)
            wait -= Time.deltaTime;
        wait = 1.6f;
        brick1.transform.Translate(Vector3.down*Time.deltaTime);
        brick2.transform.Translate(Vector3.down*Time.deltaTime);
        brick3.transform.Translate(Vector3.down*Time.deltaTime);
    }
}
