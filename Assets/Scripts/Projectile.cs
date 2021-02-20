using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Range(0f, 10f)][SerializeField] float currentSpeed = 5f;
    [SerializeField] int damage = 50;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * currentSpeed);
    }

    public void SetMovementSpeed(float speed)
    {
        currentSpeed = speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("I hit: " + collision.name);
        // reduce health
        var stats = collision.GetComponent<CharStats>();
        var attacker = collision.GetComponent<Attacker>();
        if (attacker && stats)
        {
            stats.DealDamage(damage);
            attacker.HitFX();
            Destroy(gameObject);
        }
    }
}
