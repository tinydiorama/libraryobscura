using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem.HID;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource _audiosource;
    [SerializeField] private AudioSource _sfxsource;
    [SerializeField] private AudioClip[] songs;
    [SerializeField] private int songPlaying;
    public bool playlistStarted;

    private static AudioManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("more than one audio manager");
        }
        instance = this;
        songPlaying = 0;
    }
    private void Update()
    {
        /*if ( !_audiosource.isPlaying && playlistStarted )
        {
            ChangeSong();
        }*/
    }

    public static AudioManager GetInstance()
    {
        return instance;
    }

    public void FadeOutMusic(float transitionTime = 4.0f)
    {
        StartCoroutine(Fade(transitionTime));
    }

    private IEnumerator Fade(float transitionTime)
    {
        if ( _audiosource.isPlaying )
        {
            for (float i = 0; i < transitionTime; i += Time.deltaTime)
            {
                _audiosource.volume = (1 - (i / transitionTime));
                yield return null;
            }

            _audiosource.Stop();
        }
    }

    public void setMusicVolume(float volume)
    {
        _audiosource.volume = volume;
    }

    public void setSFXVolume(float volume)
    {
        _sfxsource.volume = volume;
    }

    public void StartPlaylist()
    {
        _audiosource.volume = 1;
        songPlaying = 0;
        _audiosource.loop = true;
        _audiosource.clip = songs[songPlaying];
        _audiosource.Play();
        playlistStarted = true;
    }
    public void ChangeSong()
    {
        _audiosource.volume = 1;
        songPlaying++;
        if ( songPlaying >= songs.Length)
        {
            songPlaying = 0;
        }
        playlistStarted = true;
        _audiosource.clip = songs[songPlaying];
        _audiosource.Play();
    }

    public void playSFXLoop(AudioClip clip)
    {
        _sfxsource.loop = true;
        _sfxsource.clip = clip;
        _sfxsource.Play();
    }

    public void playSFX(AudioClip clip)
    {
        _sfxsource.loop = false;
        _sfxsource.PlayOneShot(clip);
    }
    public void playSFX(AudioClip clip, float volume)
    {
        _sfxsource.loop = false;
        _sfxsource.PlayOneShot(clip, volume);
    }
}
