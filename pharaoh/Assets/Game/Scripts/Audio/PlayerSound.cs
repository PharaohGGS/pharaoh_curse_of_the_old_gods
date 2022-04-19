using Pharaoh.Gameplay.Components.Movement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AudioManager = Pharaoh.Managers.AudioManager;

[RequireComponent(typeof(AudioSource))]
public class PlayerSound : MonoBehaviour
{
    [SerializeField]
    private float audioSourceVolume;
    [SerializeField]
    private AudioClip[] footStepClips;
    [SerializeField]
    private AudioClip[] khepeshDrawClips;
    [SerializeField]
    private AudioClip[] khepeshSwingClips;
    [SerializeField]
    private AudioClip[] hookThrowClips;
    [SerializeField]
    private AudioClip[] jumpClips;


    private PlayerMovement playerMovementData;
    private AudioSource audioSource;

    private void Awake()
    {
        playerMovementData = GetComponent<PlayerMovement>();
        audioSource = GetComponent<AudioSource>();

        audioSource.volume = audioSourceVolume;
        audioSource.loop = false;
    }

    public void PlayerStepSound()
    {
        if(playerMovementData.IsGrounded && playerMovementData.IsRunning)
        {
            AudioClip footStepClip = GetRandomClip(footStepClips);
            audioSource.PlayOneShot(footStepClip);
        } 
    }

    public void PlayerHookSound()
    {
        AudioClip hookThrowClip = GetRandomClip(hookThrowClips);
        audioSource.PlayOneShot(hookThrowClip);
    }

    public void PlayerDrawsSound()
    {
        AudioClip khepeshDrawClip = GetRandomClip(khepeshDrawClips);
        audioSource.PlayOneShot(khepeshDrawClip);
    }


    private AudioClip GetRandomClip(AudioClip[] audioClips)
    {
        return audioClips[Random.Range(0, audioClips.Length)];
    }
}
