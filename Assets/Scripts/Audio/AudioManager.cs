using System;
using UnityEngine;


public class AudioManager : MonoBehaviour
{
    [Header("Audio Sources")]
    [SerializeField]
    private AudioSource sfxSource;

    [Header("Clips")]
    [SerializeField]
    private AudioClip spinClip;

    [SerializeField]
    private AudioClip reelStopClip;

    [SerializeField]
    private AudioClip winClip;

    public static Action OnReelStop; 
    private void OnEnable()
    {
        EventBus.Subscribe<SpinRequestedEvent>(OnSpinStarted);


        EventBus.Subscribe<WinCalculatedEvent>(OnWinCalculated);
        OnReelStop += OnReelStopped;
    }

    private void OnDisable()
    {
        EventBus.UnSubscribe<SpinRequestedEvent>(OnSpinStarted);

        OnReelStop -= OnReelStopped;
        EventBus.UnSubscribe<WinCalculatedEvent>(OnWinCalculated);
    }

    private void OnSpinStarted(SpinRequestedEvent obj)
    {
        PlaySFX(spinClip);
    }

    private void OnReelStopped( )
    {
        Debug.Log("reel");
        PlaySFX(reelStopClip);
    }

    private void OnWinCalculated(WinCalculatedEvent obj)
    {
        if (obj.result.hasWin)
        {
            PlaySFX(winClip);
        }
    }

    private void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }
}