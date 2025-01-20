using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip[] clips;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        OnIntroBGM();
    }

    public void OnIntroBGM()
    {
        audioSource.clip = clips[0]; // 인트로 BGM
        audioSource.loop = true;
        audioSource.Play();
    }

    public void OnMainBGM()
    {
        audioSource.clip = clips[1]; // 메인 BGM
        audioSource.Play();
    }
    
    public void OnStop()
    {
        audioSource.Stop();
    }

    public void OnEventSound(int clipIndex)
    {
        audioSource.PlayOneShot(clips[clipIndex]); // 3 -> 점프 사운드 / 4 -> 충돌 사운드
    }
}
