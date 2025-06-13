using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    ItemData itemData;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.name = itemData.name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Dynamic dynamic = collision.GetComponent<Dynamic>();
        if (dynamic)
        {
            switch( itemData.fuction)
            {
                case Fuction.SCORE:
                    dynamic.score += itemData.Score;
                    break;
                case Fuction.POISON:

                    break;
                case Fuction.BLESS:
                    
                    break;
                case Fuction.BULLET:
                    dynamic.gun.bulletType = Fuction.BULLET;
                    break;
                case Fuction.LEASER:
                    dynamic.gun.bulletType = Fuction.LEASER;
                    break;
            }
        }
    }
}
