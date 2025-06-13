using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform trMozzle;
    public GameObject prefabBullet;
    public float shotPower;

    public Player playerMaster;

    public Fuction bulletType;

    public LineRenderer lineRenderer;

    public bool isShot = false;


    void SetBulletType(Fuction type)
    {
        lineRenderer.SetPosition(0, trMozzle.position);
        lineRenderer.SetPosition(1, trMozzle.position);
        switch (type)
        {
            case Fuction.NONE:
                break;
            case Fuction.LEASER:
               
                break;
            case Fuction.BULLET:
                break;
        }
        bulletType = type;
    }

    void UpdateBulletType()
    {
        switch (bulletType)
        {
            case Fuction.NONE:
                break;
            case Fuction.LEASER:
                if(isShot)
                {
                    LeaserUpdate();
                }
                break;
            case Fuction.BULLET:
                break;
        }
    }

    public void LeaserUpdate()
    {
        float fDist = 9999;
        Vector2 vStartPos = trMozzle.position;
        Vector2 vEndPos = vStartPos + Vector2.right * fDist;

        RaycastHit2D raycastHit = Physics2D.Linecast(vStartPos, vEndPos);

        if (raycastHit)
        {
            //Debug.Log($"Linecast:{raycastHit.collider.gameObject.name}");
            Collider2D collision = raycastHit.collider;
            Player playerTarget = collision.gameObject.GetComponent<Player>();
            HitEffect hitEffet = collision.gameObject.GetComponent<HitEffect>();
            vEndPos = raycastHit.point;
            Debug.DrawLine(vStartPos, vEndPos, Color.green);
            lineRenderer.SetPosition(0, vStartPos);
            lineRenderer.SetPosition(1, vEndPos);

            if (hitEffet != null)
            {
                if (!hitEffet.isHit)
                {
                    playerMaster.Attack(playerTarget);
                    float fAtkFps = playerMaster.atk * Time.deltaTime;
                    Debug.Log($"AtkFps:{fAtkFps}");
                    playerTarget.hp -= fAtkFps;
                    hitEffet.Hit();
                    Debug.Log("Attack!");
                    if (playerTarget.Death())
                    {
                        Destroy(collision.gameObject);
                        playerMaster.StillExp(playerTarget);
                    }
                }
            }
        }
        else
        {
            lineRenderer.SetPosition(0, vStartPos);
            lineRenderer.SetPosition(1, vEndPos);
            Debug.DrawLine(vStartPos, vEndPos, Color.red);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        SetBulletType(bulletType);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateBulletType();
    }

    public void Shot()
    {
        switch (bulletType)
        {
            case Fuction.NONE:
                break;
            case Fuction.LEASER:
                if(isShot)
                {
                    isShot = false;//레이저발사중지
                }
                else
                {
                    isShot = true;
                }
                break;
            case Fuction.BULLET:
                isShot = true;
                //objBullet.GetComponent<Rigidbody2D>().AddForce(Vector3.right * shotPower);
                GameObject objBullet = Instantiate(prefabBullet, trMozzle.position, Quaternion.identity);
                objBullet.GetComponent<Rigidbody2D>().AddForce(Vector3.right * shotPower);
                Bullet bullet = objBullet.GetComponent<Bullet>();
                bullet.playerMaster = playerMaster;
                Destroy(objBullet, 1);
                isShot = false;
                break;
        }
    }
}
