using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boos : MonoBehaviour
{
    
    [SerializeField] private GameObject[] enemies;
    private bool isAllEnemiesDied = false;
    public static int bossHealt = 20;
    public static int enemyCount;
    [SerializeField] private GameObject bossHealtImage;
    private float filledAmount;
    
    [SerializeField] private Transform playerPos;
    [SerializeField] private Rigidbody2D rb;

    private void Awake()
    {
        enemyCount = 6;
        filledAmount = bossHealtImage.GetComponent<Image>().fillAmount / 20;
    }

    private void Update()
    {
        if (enemyCount == 0)
        {
            isAllEnemiesDied = true;
            bossHealtImage.SetActive(true);
        }
    }

    private void FixedUpdate()
    {
        Vector2 lookDir = new Vector2(playerPos.position.x,playerPos.position.y) - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            TriggerManager.RestartScene();
        }
        else if (col.gameObject.CompareTag("PlayerBullet"))
        {
            Destroy(col.gameObject);
            if (!isAllEnemiesDied) return;
            bossHealt--;
            if (bossHealt > 1)
            {
                bossHealtImage.GetComponent<Image>().fillAmount -= filledAmount;
            }
        }
    }
}
