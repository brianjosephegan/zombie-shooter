using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitDetector : MonoBehaviour
{
    public void TakeHit(float damage)
    {
        GetComponentInParent<EnemyHealth>().TakeDamage(damage);
    }
}
