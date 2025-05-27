using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffect : MonoBehaviour
{
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
