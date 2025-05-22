using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour
{
    public float speed;
    public float jumpPower;

    public bool isJump;
    public bool isMove;

    public float time;
    public float curTime = -1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (curTime == -1 && !isJump)
        {
            curTime = 0;
        }

        if (curTime >= 0)
            curTime += Time.deltaTime;

        if (curTime >= time)
        {
            if (!isJump)
            {
                Jump();
                isMove = true;
            }
            curTime = -1;
        }

        //if(isJump)
        {
            Move();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isJump = false;
        isMove = false;
    }

    void Move()
    {
        if(isMove)
            transform.position += Vector3.left * speed * Time.deltaTime;
    }

    void Jump()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector3.up * jumpPower);
        isJump = true;
    }
}
