using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Range(0f, 10f)][SerializeField] float currentSpeed = 5f;
    [SerializeField] int damage = 50;

    GameObject projectilesParent;
    const string PROJECTILES_PARENT_NAME = "Projectiles";

    // Start is called before the first frame update
    void Start()
    {
        CreateProjectileParent();
    }

    private void CreateProjectileParent()
    {
        projectilesParent = GameObject.Find(PROJECTILES_PARENT_NAME);
        if (!projectilesParent) projectilesParent = new GameObject(PROJECTILES_PARENT_NAME);
        transform.parent = projectilesParent.transform;
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
            Destroy(gameObject);
        }
    }
}
