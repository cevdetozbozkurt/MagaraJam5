using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("PlayerBullet"))
        {
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
    }
}
