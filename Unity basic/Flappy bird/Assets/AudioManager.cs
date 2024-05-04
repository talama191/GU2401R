using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [SerializeField] private AudioClip jumpClip;
    [SerializeField] private AudioClip deadClip;

    private AudioSource audioSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayJumpClip()
    {
        audioSource.PlayOneShot(jumpClip);
    }

    public void PlayDeadClip()
    {
        audioSource.PlayOneShot(deadClip);
    }
}
