using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [Range(0f, 1f)] float currentSpeed = 1f;

    GameObject currentTarget;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * currentSpeed);
        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        if (!currentTarget)
        {
            ResumeMove();
        }
    }

    public void SetMovementSpeed(float speed)
    {
        currentSpeed = speed;
    }

    public void Attack(GameObject target)
    {
        animator.SetBool("isAttacking", true);
        currentTarget = target;
    }

    public void ResumeMove()
    {
        animator.SetBool("isAttacking", false);
        currentTarget = null;
    }

    public void DamageCurrentTarget(int damage)
    {
        if (!currentTarget) return;

        CharStats targetStats = currentTarget.GetComponent<CharStats>();

        if (targetStats)
        {
            targetStats.DealDamage(damage);
        }
    }
}
