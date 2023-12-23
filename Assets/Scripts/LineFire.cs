using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineFire : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float spawnBulletTime = 1f;

    void Start()
    {
        StartCoroutine(CreateBullet());
    }

    private IEnumerator CreateBullet()
    {
        while (true)
        {
            Instantiate(bulletPrefab, transform.position, transform.rotation);

            yield return new WaitForSeconds(spawnBulletTime);
        }
    }
}
