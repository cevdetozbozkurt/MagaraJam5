using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void Start()
    {
        try
        {
            transform.GetChild(0);
        }
        catch (Exception)
        {
            Debug.LogError("Her Checkpointin, playerin ışınlanacağı bir gameobject child'ına sahip olması gerekir");
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.CompareTag("Player"))
        {
            return;
        }
        
        TriggerManager triggerManager = Utils.player.GetComponent<TriggerManager>();
        triggerManager.respawnPoint = transform.GetChild(0).transform;
    }
}
