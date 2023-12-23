using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Unity.Mathematics;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class ObstacleFire : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private List<Transform> bulletPositions;
    [SerializeField] private float spawnBulletTime = 1f;

    private void Start()
    {
        StartCoroutine(CreateBullet());
    }

    private IEnumerator CreateBullet()
    {
        while (true)
        {
            foreach (Transform bulletTransform in bulletPositions)
            {
                Instantiate(bulletPrefab, bulletTransform.position, bulletTransform.rotation);
            }

            yield return new WaitForSeconds(spawnBulletTime);
        }
    }
}
