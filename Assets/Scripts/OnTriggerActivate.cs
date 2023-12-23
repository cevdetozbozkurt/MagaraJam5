using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class OnTriggerActivate : MonoBehaviour
{
    [SerializeField] private List<GameObject> gameObjectsToBeActivated;
    [SerializeField] private float delay = 0.1f;
    
    [HideInInspector] public bool isRun;

    private void Awake()
    {
        isRun = false;

        foreach (GameObject o in gameObjectsToBeActivated)
        {
            o.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.CompareTag("Player") || isRun)
        {
            return;
        }

        isRun = true;

        LeanTween.delayedCall(delay, () =>
        {
            foreach (GameObject o in gameObjectsToBeActivated)
            {
                o.SetActive(true);
            }
        });
    }
}
