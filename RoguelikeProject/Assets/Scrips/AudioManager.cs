using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {

    public AudioSource bgMusic;
    public AudioSource exAudio;

    public float maxPitch = 1;
    public float minPitch = 0.2f;



    private static AudioManager _instance;

    public static  AudioManager Instance{

        get {
            return _instance;
        }
}

    void Awake() {
        _instance = this;
    }

   public void RandomPlay(params AudioClip[] clips) {
        float pitch = Random.Range(minPitch,maxPitch);
        int index = Random.Range(0, clips.Length);
        AudioClip temp=clips[index];

        exAudio.clip = temp;
        exAudio.pitch = pitch;
        exAudio.Play();
    }

   public void StopBgMusic()
   {

        bgMusic.Stop();
    }
}
