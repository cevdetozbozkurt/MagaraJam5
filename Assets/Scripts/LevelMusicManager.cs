using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMusicManager : MonoBehaviour
{
    [SerializeField] private List<string> namesToBePlayed;
    [SerializeField] private List<string> namesToBeStopped;
    
    void Start()
    {
        foreach (string s in namesToBePlayed)
        {
            AudioManager.instance.Play(s);
        }
        foreach (string s in namesToBeStopped)
        {
            AudioManager.instance.Stop(s);
        }
    }
}
