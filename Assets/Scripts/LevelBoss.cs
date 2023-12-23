using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class LevelBoss : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera vcam;
    [SerializeField] private float delay = 0.1f;
    [SerializeField] private float newOrthoSize = 19f;
    [SerializeField] private float timeToZoom = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
        LeanTween.delayedCall(delay, () =>
        {
            LeanTween.value(gameObject, vcam.m_Lens.OrthographicSize, newOrthoSize, timeToZoom).setOnUpdate((float val) =>
            {
                vcam.m_Lens.OrthographicSize = val;
            });
        });
    }
}
