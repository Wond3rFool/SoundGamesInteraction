using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMScript : MonoBehaviour
{
    public static SMScript instance;

    [SerializeField] private AudioSource musicSource, dialogue1Source, dialogue2Source;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayDialogue1(AudioClip clip, float timer)
    {
        dialogue1Source.clip = clip;
        if (!dialogue1Source.isPlaying)
        {
            dialogue1Source.PlayDelayed(timer);

        }
    }

    public void PlayDialogue2(AudioClip clip, float timer)
    {
        dialogue2Source.clip = clip;
        if (!dialogue2Source.isPlaying)
        {
            dialogue2Source.PlayDelayed(timer);

        }
    }
    public void PlayBGM(AudioClip bgm)
    {
        if(!musicSource.isPlaying)
            musicSource.PlayOneShot(bgm, 0.1f);
    
    }
}
