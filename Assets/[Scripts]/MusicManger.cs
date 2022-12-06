using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MusicManger : MonoBehaviour
{
    [SerializeField]
    AudioMixer mainMixer;

    public enum TrackID
    {
        TOWN,
        WILD
    }
    [Tooltip("Track order should line up with trackID enum in MusicManager.cs")]
    [SerializeField]
    AudioClip[] tracks;

    private MusicManger() { }
    private static MusicManger instance = null;
    public static MusicManger Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<MusicManger>();
                SceneManager.sceneLoaded += instance.OnSceneLoaded; 
            }
            return instance;
        }
        private set { instance = value; }
    }

    [Tooltip("One track for crossfading. the order is arbitrary")]
    [SerializeField]
    AudioSource MusicSource1;

    [Tooltip("Another track for crossfading. the order is arbitrary")]
    [SerializeField]
    AudioSource MusicSource2;

    [SerializeField]
    AudioSource transitionSound;

    // Start is called before the first frame update
    void Start()
    {
        MusicManger original = Instance;
        MusicManger[] mangers = FindObjectsOfType<MusicManger>();
        //GameObject.FindObjectsOfType<>();
        foreach(MusicManger manger in mangers)
        {
            if(manger != original)
            {
                Destroy(manger.gameObject);
            }
        }
        if(this == original)
        {
            DontDestroyOnLoad(gameObject);
        }

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene newScene, LoadSceneMode LoadMode)
    {
        transitionSound.Play();
        if(newScene.name == "Town")
        {
            CrossFadeTo(TrackID.TOWN);
        }

        if(newScene.name == "Overworld")
        {
            CrossFadeTo(TrackID.WILD);
        }
    }

    /// <summary>
    /// stop everything and play on source 1
    /// </summary>
    /// <param name="whichTrackToPlay"></param>
    public void PlayTrack(TrackID whichTrackToPlay)
    {
        MusicSource1.Stop();
        MusicSource2.Stop();
        MusicSource1.clip = tracks[(int)whichTrackToPlay];
        MusicSource1.Play();
    }

    /// <summary>
    /// Assuming one track is already playing, we crossfade to end with another track playing solo on a different source
    /// </summary>
    /// <param name="goalTrack"></param>
    public void CrossFadeTo(TrackID goalTrack, float duration = 3.0f)
    {
        AudioSource oldTrack = MusicSource1;
        AudioSource newTrack = MusicSource2;

        if(MusicSource1.isPlaying)
        {
            oldTrack = MusicSource1;
            newTrack = MusicSource2;
        }
        
        else if (MusicSource2.isPlaying)
        {
            oldTrack = MusicSource2;
            newTrack = MusicSource1;
        }

        newTrack.clip = tracks[(int)goalTrack];
        newTrack.Play();

        StartCoroutine(CrossFadeCoroutine(oldTrack, newTrack, duration));
    }

    private IEnumerator CrossFadeCoroutine(AudioSource oldTrack, AudioSource newTrack, float duration)
    {
        float time = 0.0f;
        while(time < duration)
        {
            float tValue = time / duration;

            newTrack.volume = tValue;
            oldTrack.volume = 1.0f - tValue;

            time += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        oldTrack.Stop();
        oldTrack.volume = 1.0f;
    }

    public void SetMusicVolume(float volumeDB)
    {
        mainMixer.SetFloat("VolumeMusic", volumeDB);
    }

    public void SetSFXVolume(float volumeDB)
    {
        mainMixer.SetFloat("VolumeSFX", volumeDB);
    }
}
