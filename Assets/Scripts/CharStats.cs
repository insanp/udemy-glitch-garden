using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharStats : MonoBehaviour
{
    [SerializeField] int health = 100;
    [SerializeField] GameObject deathVFX;

    public void DealDamage(int damage)
    {
        HitFX();
        health -= damage;

        if (health <= 0)
        {
            TriggerDeathVFX();
            Destroy(gameObject);
        }
    }

    private void TriggerDeathVFX()
    {
        if (!deathVFX) return;
        GameObject deathVFXObject = Instantiate(deathVFX, transform.position, Quaternion.identity);
        Destroy(deathVFXObject, 1f);
    }

    public void HitFX()
    {
        StartCoroutine(Blink());
    }

    IEnumerator Blink()
    {
        var spriteRen = gameObject.GetComponent<SpriteRenderer>();

        if (!spriteRen) yield break;
        spriteRen.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        spriteRen.color = Color.white;
    }
}
