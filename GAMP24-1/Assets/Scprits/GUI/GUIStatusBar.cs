using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIStatusBar : MonoBehaviour
{
    public RectTransform rtStatusBar;
    public RectTransform rtStatusBarBG;

    public void SetStatusBar(float cur,float max)
    {
        Vector2 vSize =  rtStatusBar.sizeDelta; //50
        Vector2 vFixedSize = rtStatusBarBG.sizeDelta;
        vSize.x = vFixedSize.x * (cur/max);//100 * 50/100 // 50 * 50/100
        rtStatusBar.sizeDelta = vSize; //50 //25
    }

    public void UpdateStatus(Player player)
    {
        if(player)
        {
            //SetStatusBar(player.hp, player.GetMaxHp());
            SetStatusBar(player.hp, player.MaxHp);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //SetStatusBar(50, 100);
    }
}
