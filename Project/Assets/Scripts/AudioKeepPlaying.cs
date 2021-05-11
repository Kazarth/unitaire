using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioKeepPlaying : MonoBehaviour
{
    void Awake(){
        GameObject[] objs = GameObject.FindGameObjectsWithTag("MusicAudio");
        if(objs.Length > 1)
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);
    }
}
