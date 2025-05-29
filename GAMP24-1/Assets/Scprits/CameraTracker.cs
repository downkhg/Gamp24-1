using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracker : MonoBehaviour
{
    public GameObject objTarget;
    public float speed;

    public bool isRotate = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //objTarget = GameObject.FindWithTag("Player");

        Move(objTarget);

        if(isRotate)
        {
            transform.rotation = objTarget.transform.rotation;
        }
    }

    bool Move(GameObject target)
    {
        if (target == null) return false;
        Vector3 vTargetPos = target.transform.position;
        Vector3 vPos = this.transform.position;
        vTargetPos.z = vPos.z;

        Vector3 vDist = vTargetPos - vPos;
        Vector3 vDir = vDist.normalized;

        float fDist = vDist.magnitude;
        float fMove = speed * Time.deltaTime;


        if (fDist > fMove)
        {
            transform.position += vDir * speed * Time.deltaTime;
            Debug.DrawLine(vTargetPos, vPos, Color.green);
            return true;
        }
        else
        {
            Debug.DrawLine(vTargetPos, vPos, Color.red);
            return false;
        }
    }
}
