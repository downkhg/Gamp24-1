using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Opossum : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
        } 
    }

    public bool isHit = false;

    public void Hit()
    {
        StartCoroutine(HitTimmer(GetComponent<SpriteRenderer>()));
    }

    IEnumerator HitTimmer(SpriteRenderer spriteRenderer, float time = 0.1f)
    {
        isHit = true;
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(time);
        spriteRenderer.color = Color.white;
        isHit = false;
    }
}
