using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class Shooting : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;

    [SerializeField] private float bulletForce = 20;
    private GameObject bullet;
    
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Transform blackScreen;


    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

        if (Boos.bossHealt == 1)
        {
            FinishBossScene();
        }
    }

    [ContextMenu("TestFinishBossScene")]
    private void FinishBossScene()
    {
        this.enabled = false;
        float volume = audioMixer.GetFloat("volume", out volume) ? volume : 0;
        
        // Set volume from volume variable to -80 in 2 seconds
        LeanTween.value(gameObject, volume, -80, 2).setOnUpdate((float val) =>
        {
            audioMixer.SetFloat("volume", val);
        });

        Transform up = blackScreen.transform.GetChild(0);
        Transform down = blackScreen.transform.GetChild(1);

        LeanTween.value(gameObject, 0f, 6f, 2f).setOnUpdate((float val) =>
        {
            var upLocalScale = up.localScale;
            var downLocalScale = down.localScale;
            upLocalScale.y = val;
            downLocalScale.y = val;

            up.localScale = upLocalScale;
            down.localScale = downLocalScale;
        }).setOnComplete(() =>
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        });

        Destroy(GetComponent<BoxCollider2D>());
    }

    void Shoot()
    {
        AudioManager.instance.Play("FireSong");
        bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
