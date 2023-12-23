using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public bool isCollected;
    private GameObject _player;
    private float _elapsedTime;
    

    private void Update()
    {
        if (!isCollected) return;
        _elapsedTime += Time.deltaTime;
        if (_elapsedTime >= 0.75f)
        {
            gameObject.SetActive(false);
            TriggerManager.Items++;
            return;
        };
        transform.position = Vector3.Lerp(transform.position, _player.transform.position, _elapsedTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }

        _player = other.gameObject;

        Collect();
    }

    private void Collect()
    {
        isCollected = true;
        AudioManager.instance.Play("Collect");
    }
}
