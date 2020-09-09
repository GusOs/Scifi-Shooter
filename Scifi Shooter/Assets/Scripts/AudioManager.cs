using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource musicAudioSource;
    public AudioSource FxAudioSource;

    public static AudioManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    //Comprueba si el sonido es MUSIC o FX para llamar a un método u otro
    public void PlaySound(Sound sound)
    {
        if (sound.soundType == Sound.SoundType.MUSIC)
        {
            PlayMusic(sound);
        }
        else if (sound.soundType == Sound.SoundType.FX)
        {
            PlayFxSound(sound);
        }
    }

    //Reproducción de Musica
    private void PlayMusic(Sound sound)
    {
        musicAudioSource.clip = sound.clip;
        musicAudioSource.volume = sound.volume;
        musicAudioSource.loop = sound.loop;

        musicAudioSource.Play();
    }

    //Reproducción de sonidos
    private void PlayFxSound(Sound sound)
    {
        FxAudioSource.clip = sound.clip;
        FxAudioSource.volume = sound.volume;
        FxAudioSource.loop = sound.loop;

        FxAudioSource.Play();
    }

    public void StopSound(Sound sound)
    {
        if (sound.soundType == Sound.SoundType.MUSIC)
        {
            StopMusic();
        }
        else if (sound.soundType == Sound.SoundType.FX)
        {
            StopFxSound();
        }
    }

    private void StopFxSound()
    {
        FxAudioSource.Stop();
    }

    private void StopMusic()
    {
        musicAudioSource.Stop();
    }
}
