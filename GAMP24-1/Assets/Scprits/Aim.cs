using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vScreen2WorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        vScreen2WorldPos.z = 0;
        transform.position = vScreen2WorldPos;
    }
}
