using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] int health;

    [SerializeField] GameObject projectile, gun;
    AttackerSpawner myLaneSpawner;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        SetLaneSpawner();
        animator = GetComponent<Animator>();
    }

    private void SetLaneSpawner()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();

        foreach (AttackerSpawner spawner in spawners)
        {
            //Debug.Log(spawner.transform.position.y + " vs " + transform.position.y);
            bool isCloseEnough = (Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon);

            if (isCloseEnough)
            {
                myLaneSpawner = spawner;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (IsAttackerInLane())
        {
            // Animation state to shooting
            Debug.Log("shoot");
            animator.SetBool("isAttacking", true);

        } else
        {
            // Animation state to idle
            animator.SetBool("isAttacking", false);
        }
    }

    private bool IsAttackerInLane()
    {
        // if my lane spawner child count less than or equal to zero, return sero
        if (myLaneSpawner == null || myLaneSpawner.transform.childCount <= 0) return false;
        return true;
    }

    public void Fire()
    {
        Instantiate(projectile, gun.transform.position, gun.transform.rotation);
    }
}
