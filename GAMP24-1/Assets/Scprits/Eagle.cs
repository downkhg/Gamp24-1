using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Eagle : MonoBehaviour
{
    public float speed;
    public bool isMove;

    public GameObject objTarget;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move(objTarget);
    }

    bool Move(GameObject target)
    {
        if (target == null) return false;
        Vector3 vTargetPos = target.transform.position;
        Vector3 vPos = this.transform.position;

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
            objTarget = collision.gameObject;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log($"{gameObject.name}.OnCollisionEnter2D({collision.gameObject}/{collision.gameObject.tag})");
        if (collision.gameObject.tag == "Player")
            Destroy(collision.gameObject);
    }
}
