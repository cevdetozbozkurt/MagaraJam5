using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TriggerManager : MonoBehaviour
{
    public delegate void OnExit();

    private static OnExit exitLevel;

    public delegate void OnPassDoor();

    private static OnPassDoor passDoor;
    
    [SerializeField] private Animator _animator;

    private Shooting _shooting;
    
    private GameObject[] doors;
    private GameObject[] rooms; 
    private SpriteRenderer[] doorLight;
    private int needItemCount;
    private int doorIndex = 0;
    private int roomIndex = 0;
    public static int Items = 0;

    public Transform respawnPoint;
    public int checkpointRunCount = 0;

    private void Awake()
    {
        _shooting = GetComponent<Shooting>();
        _shooting.enabled = false;
        GameObject temp1 = GameObject.FindGameObjectWithTag("Doors");
        if (temp1 == null)
            return;
        doors = new GameObject[temp1.transform.childCount];
        for (int i = 0; i < temp1.transform.childCount; i++)
        {
            doors[i] = temp1.transform.GetChild(i).gameObject;
        }
        
        GameObject temp2 = GameObject.FindGameObjectWithTag("Rooms");
        if (temp2 == null)
            return;
        rooms = new GameObject[temp2.transform.childCount];
        for (int i = 0; i < temp1.transform.childCount; i++)
        {
            rooms[i] = temp2.transform.GetChild(i).gameObject;
        }
        
        GameObject temp3 = GameObject.FindGameObjectWithTag("DoorLights");
        if (temp3 == null)
            return;
        doorLight = new SpriteRenderer[temp3.transform.childCount];
        for (int i = 0; i < temp1.transform.childCount; i++)
        {
            doorLight[i] = temp3.transform.GetChild(i).GetComponent<SpriteRenderer>();
        }
        
        needItemCount = rooms[roomIndex].transform.childCount;
        
        foreach (SpriteRenderer light in doorLight)
        {
            light.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    private void OnEnable()
    {
        exitLevel += ExitLevel;
        passDoor += PassDoor;
    }

    private void OnDisable()
    {
        exitLevel -= ExitLevel;
        passDoor -= PassDoor;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartScene();
        }
        else if (checkpointRunCount >= 10 && Input.GetKeyDown(KeyCode.T))
        {
            exitLevel.Invoke();
        }
        
        passDoor.Invoke();
    }

    public static void RestartScene()
    {
        Items = 0;
        Utils.RestartScene();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Exit"))
        {
            exitLevel.Invoke();
        }

        if (col.CompareTag("Crosshair"))
        {
            _shooting.enabled = true;
            _animator.SetBool("isTrigger", true);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Enemy") || col.gameObject.CompareTag("Bullet"))
        {
            AudioManager.instance.Play("Lose");
            if (!respawnPoint)
            {
                Debug.Log("there is no checkpoint, scene reloading");
                RestartScene();
                return;
            }
            SetPlayerAtCheckpointPosition();

            // TODO: düşmanların pozisyonları sıfırlanmalı
        }
    }

    public void SetPlayerAtCheckpointPosition()
    {
        checkpointRunCount++;
        
        transform.position = respawnPoint.position;
        transform.rotation = respawnPoint.rotation;
    }

    public void ExitLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Items = 0;
    }

    public void PassDoor()
    {
        if (Items == needItemCount && doorLight != null && doors != null)
        {
            doorLight[doorIndex].GetComponent<SpriteRenderer>().enabled = true;
            doors[doorIndex].GetComponent<BoxCollider2D>().isTrigger = true;
            if (doorIndex < doors.Length -1)
                doorIndex++;
            if(roomIndex < rooms.Length - 1)
                roomIndex++;
            needItemCount += rooms[roomIndex].transform.childCount;
        }
    }

}
