using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public CameraTracker cameraTracker;
    public Responner responnerPlayer;
    public Responner responnerEagle;
    public Responner responnerOpussum;

    public ItemDataManager itemDataManager;
    public List<Item> itemList;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(this.gameObject.name + ".Start");
        foreach (var item in itemList)
        {
            ItemData getitem = itemDataManager.GetItem(item.name);
            if (getitem != null)
                item.itemData = getitem;
            else
                Debug.LogWarning($"item:{item.name} is not Find!");
        }
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
