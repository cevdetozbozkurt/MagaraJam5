using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletManager : MonoBehaviour
{
    [SerializeField] private float destroyAfterSeconds = 3f;

    private void Start()
    {
        StartCoroutine(DestoryAfterTime(destroyAfterSeconds));
    }

    private IEnumerator DestoryAfterTime(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Walls") || col.gameObject.CompareTag("Enemy") || col.gameObject.CompareTag("Exit")
            || col.gameObject.CompareTag("Boss") || col.gameObject.CompareTag("Bullet")
            )
        {
            Destroy(gameObject);
            if (col.gameObject.CompareTag("Enemy"))
            {
                Boos.enemyCount--;
            }
        }
    }
}
