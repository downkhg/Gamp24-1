using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float atk;
    public float hp;
    public int exp;
    public int maxExp = 100;
    public int lv = 1;
    float maxHP;

    public float GetMaxHp() { return maxHP; }//getter
    public float MaxHp { get { return maxHP; } } //ÀÎµ¦¼­

    private void Start()
    {
        maxHP = hp;  
    }

    public void LvUp()
    {
        if(exp >= maxExp)
        {
            lv++;
            atk += 5;
            hp += 10;
            maxHP += 10;
            exp -= maxExp;
        }
    }

    public void StillExp(Player player)
    {
        this.exp += player.exp;
    }

    public void Attack(Player target)
    {
        target.hp = target.hp - this.atk; // 100 - 10 = 90
    }
    
    public bool Death()
    {
        if (hp > 0)
            return false;
        else
            return true;
    }

    private void Update()
    {
        LvUp();
    }

    public int idx = 0;
    private void OnGUI()
    {
        GUI.Box(new Rect(100*idx, 0, 100, 20), $"{gameObject.name}[{lv}]");
        GUI.Box(new Rect(100 * idx, 20, 100, 20), $"Exp:{exp}/{maxExp}");
        GUI.Box(new Rect(100 * idx, 40, 100, 20), $"Atk:{atk}");
        GUI.Box(new Rect(100 * idx, 60, 100, 20), $"HP:{hp}");
    }
}
