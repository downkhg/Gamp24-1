using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dynamic : MonoBehaviour
{
    public float speed;
    public float jumpPower;
    // Start is called before the first frame update
    void Start()
    {
        //Vector3 vPos = transform.position;
        //vPos.x += 1;
        //transform.position = vPos;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.RightArrow))
            transform.position += Vector3.right * speed * Time.deltaTime;

        if(Input.GetKey(KeyCode.LeftArrow))
            transform.position += Vector3.left * speed * Time.deltaTime;

        if(Input.GetKey(KeyCode.Space))
            GetComponent<Rigidbody2D>().AddForce(Vector3.up * jumpPower);
    }
}
