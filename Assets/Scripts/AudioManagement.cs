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
    public Slider MusicSlider;
    public Slider EffectSlider;

    //All the audio sources
    public AudioSource MusicSource;
    public AudioSource CannonSource;

    //The music clips
    public AudioClip MainMusic;

    private void Update()
    {
        ChangeMusicVolume();
        ChangeEffectVolume();
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