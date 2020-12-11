using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Script_AudioManager : MonoBehaviour
{
    public List<string> MapName;
    public List<AudioSource> Audio;
    private Dictionary<string, AudioSource> AudioMap = new Dictionary<string, AudioSource>();

    private void Awake()
    {
        int count = FindObjectsOfType<Script_AudioManager>().Length;
        if (count != 1) { Destroy(this); } else { DontDestroyOnLoad(this);}
        for (int i = 0; i < Audio.Count; i++) { AudioMap.Add(MapName[i], Audio[i]); }
    }

    private void OnLevelWasLoaded(int level)
    {
        string map = SceneManager.GetActiveScene().name;
        bool safe = AudioMap.ContainsKey(map) && !AudioMap[map].isPlaying;
        if (safe)
        {
            foreach (AudioSource au in Audio) { au.Stop(); }
            AudioMap[map].Play();
        }
    }

    private void Start()
    {
        if(AudioMap.ContainsKey(MapName[0])) { AudioMap[MapName[0]].Play(); }
    }
}
