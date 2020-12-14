using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static SoundManager Instance = null;

    public AudioClip goalBloop;
    public AudioClip lossBuzz;
    public AudioClip HitPaddleBloop;
    public AudioClip WinSound;
    public AudioClip WallSound;

    private AudioSource soundEffectAudio;

    void Start()
    {
        
        if (Instance == null)
        {
            Instance = this;

        }else if(Instance != this)
        {
            Destroy(gameObject);
        } //사운드 매니저 인스턴스(static)의 중복 검사

        AudioSource[] sources = GetComponents<AudioSource>();

        foreach(AudioSource source in sources)
        {
            if(source.clip == null)
            {
                soundEffectAudio = source;
            }
        }

    }

    public void PlayOneShot(AudioClip clip)
    {
        soundEffectAudio.PlayOneShot(clip);
    }

}
