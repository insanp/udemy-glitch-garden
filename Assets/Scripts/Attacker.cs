using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [Range(0f, 1f)] float currentSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * currentSpeed);
    }

    public void SetMovementSpeed(float speed)
    {
        currentSpeed = speed;
    }

    public void HitFX()
    {
        StartCoroutine(Blink());
    }

    IEnumerator Blink()
    {
        var spriteRen = gameObject.GetComponent<SpriteRenderer>();
        spriteRen.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        spriteRen.color = Color.white;
    }
}
