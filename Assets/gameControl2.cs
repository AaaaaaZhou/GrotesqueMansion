using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameControl2 : MonoBehaviour
{

    public GameObject player;
    public int label = 3;
    public float offset_x = 0;
    public float offset_y = 0;

    private float damping = 0;
    private float lookAheadFactor = 0;
    private float lookAheadReturnSpeed = 0;
    private float lookAheadMoveThreshold = 0;

    private Transform target;
    private float m_OffsetZ;
    private Vector3 m_LastTargetPosition;
    private Vector3 m_CurrentVelocity;
    private Vector3 m_LookAheadPos;

    //private float init_x = -8.5f;
    //private float init_y = 0;

    private void Start()
    {
        target = player.transform;
        m_LastTargetPosition = target.position;
        m_OffsetZ = (transform.position - target.position).z;
        transform.parent = null;

        //init_x = target.position.x;
        //init_y = target.position.y;
    }


    private void Update()
    {
        if (player.GetComponent<stupid_control2>().life == label)
        {
            //target.transform.Translate(new Vector3(init_x, init_y));
            gameObject.SetActive(false);
        }


        Vector3 tmp = new Vector3(offset_x, offset_y);
        Vector3 pos = target.position + tmp;
        //target.position += tmp;
        float xMoveDelta = (pos - m_LastTargetPosition + tmp).x;

        bool updateLookAheadTarget = Mathf.Abs(xMoveDelta) > lookAheadMoveThreshold;

        if (updateLookAheadTarget)
        {
            m_LookAheadPos = lookAheadFactor * Vector3.right * Mathf.Sign(xMoveDelta);
        }
        else
        {
            m_LookAheadPos = Vector3.MoveTowards(m_LookAheadPos, Vector3.zero, Time.deltaTime * lookAheadReturnSpeed);
        }

        Vector3 aheadTargetPos = pos + m_LookAheadPos + Vector3.forward * m_OffsetZ;
        Vector3 newPos = Vector3.SmoothDamp(transform.position, aheadTargetPos, ref m_CurrentVelocity, damping);

        transform.position = newPos;

        m_LastTargetPosition = pos;
    }
}
