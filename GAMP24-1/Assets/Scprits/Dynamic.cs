using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dynamic : MonoBehaviour
{
    public float speed;
    public float jumpPower;
    public int score;
    public bool isGround;
    public bool isJump;

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

        if(Input.GetKeyDown(KeyCode.Space))
        {
            //if (isGround)
            if (!isJump)
            {
                GetComponent<Rigidbody2D>().AddForce(Vector3.up * jumpPower);
                isJump = true;
            }
        }
           
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"OnTriggerEnter2D:{collision.gameObject.name}");
        //if (collision.gameObject.name == "cherry")
        if (collision.gameObject.tag == "Item")
        {
            score++;
            Destroy(collision.gameObject);
        }
        //if(collision.gameObject.name == "Tilemap")
        //    isGround = true;

        isJump = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log($"OnCollisionEnter2D:{collision.gameObject.name}");
        ////if (collision.gameObject.name == "cherry")
        //if (collision.gameObject.tag == "Item")
        //{
        //    score++;
        //    Destroy(collision.gameObject);
        //}
        ////if(collision.gameObject.name == "Tilemap")
        ////    isGround = true;

        isJump = false;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //isGround = false;
    }

    private void OnGUI()
    {
        GUI.Box(new Rect(0, 0, 100,20), $"Score:{score}");
        GUI.Box(new Rect(0, 20, 100, 20), $"Jump:{isJump}");
    }
}
