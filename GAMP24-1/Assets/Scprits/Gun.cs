using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform trMozzle;
    public GameObject prefabBullet;
    public float shotPower;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            //objBullet.GetComponent<Rigidbody2D>().AddForce(Vector3.right * shotPower);
            GameObject objBullet = Instantiate(prefabBullet, trMozzle.position,Quaternion.identity);
            objBullet.GetComponent<Rigidbody2D>().AddForce(Vector3.right * shotPower);
            Destroy(objBullet,1);
        }
    }
}
