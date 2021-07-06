using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCollider : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<LivesDisplay>().TakeLives();
    }
}
