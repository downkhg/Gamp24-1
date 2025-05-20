using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Responner : MonoBehaviour
{
    public GameObject objPlayer;
    public GameObject prefabPlayer;

    public float time;
    public float curTime = -1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (curTime == -1 && objPlayer == null )
        {
            curTime = 0;
        }

        if (curTime >= 0)
            curTime += Time.deltaTime;

        if (curTime >= time)
        {
            objPlayer = Instantiate(prefabPlayer, this.transform.position, Quaternion.identity);
            Debug.Log($"ResponObject: {objPlayer.name}");

            curTime = -1;
        }
    }
}
