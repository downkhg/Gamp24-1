using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public CameraTracker cameraTracker;
    public Responner responnerPlayer;
    public Responner responnerEagle;
    public Responner responnerOpussum;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(cameraTracker.objTarget == null)
        {
            cameraTracker.objTarget = responnerPlayer.objPlayer;
            cameraTracker.transform.rotation = Quaternion.identity;
        }

        if(responnerEagle.objPlayer)
        {
             Eagle eagle = responnerEagle.objPlayer.GetComponent<Eagle>();

            if (eagle != null)
            {
                eagle.trResponPoint = responnerEagle.transform;
                eagle.trPatrolPoint = responnerOpussum.transform;
            }
        }
    }
}
