using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ses : MonoBehaviour
{
    [SerializeField] private AudioSource Ses;
    [SerializeField] private AudioClip SesClip;
    private void Awake()
    {
        Ses.clip = SesClip;
        foreach (Button obje in Resources.FindObjectsOfTypeAll<Button>())
        {
            obje.onClick.AddListener(() => SesCal());
        } 
    }
    public void SesCal()
    {
        Ses.Play();
    }
}
