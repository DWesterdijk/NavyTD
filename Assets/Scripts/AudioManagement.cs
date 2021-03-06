using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Controls all the audio in the game
/// </summary>
public class AudioManagement : MonoBehaviour
{
    //Audio volume sliders
    public Slider MasterVolumeSlider;
    public Slider MusicSlider;
    public Slider EffectSlider;

    //AUdio buttons
    public Button CloseTab;
    public Button OpenTab;

    //All the audio sources
    public AudioSource MusicSource;
    public AudioSource CannonSource;

    //Percentage
    float MasterVolume;
    float _tempEffectVolume;
    float _tempMusicVolume;

    private void Start()
    {
        //Deactivates on start of the game
        this.gameObject.SetActive(false);
    }

    private void Update()
    {
        ChangeMasterVolume();
        ChangeMusicVolume();
        ChangeEffectVolume();
    }

    //Opens the volume menu
    public void OpenVolumeMenu()
    {
        this.gameObject.SetActive(true);
        CloseTab.gameObject.SetActive(true);
        OpenTab.gameObject.SetActive(false);
    }

    //Closes the volume menu
    public void CloseVolumeMenu()
    {
        this.gameObject.SetActive(false);
        CloseTab.gameObject.SetActive(false);
        OpenTab.gameObject.SetActive(true);
    }

    public void ChangeMasterVolume()
    {
        MasterVolume = MasterVolumeSlider.value * 100f;
        _tempEffectVolume = EffectSlider.value;
        _tempEffectVolume /= 100; _tempEffectVolume *= MasterVolume;
        CannonSource.volume = _tempEffectVolume;
        
        _tempMusicVolume = MusicSlider.value;
        _tempMusicVolume /= 100; _tempMusicVolume *= MasterVolume;
        MusicSource.volume = _tempMusicVolume;
    }

    //Changes the volume of the music to the given slider value
    public void ChangeMusicVolume()
    {
        MusicSource.volume = MusicSlider.value;
    }

    //Changes the volume of the sound effects to the given slider value
    public void ChangeEffectVolume()
    {
        CannonSource.volume = EffectSlider.value;
    }

    //Plays the given music clip on the music audio source
    public void PlayMusic(AudioClip audioClip)
    {
        MusicSource.Stop();
        MusicSource.clip = audioClip;
        MusicSource.Play();
    }

    //Plays the given audiosource
    public void PlayEffect(AudioSource audioSource)
    {
        audioSource.Play();
    }
}