using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayAudioPlayer : MonoBehaviour
{

    public Sound gameplayMusicSounds;

    void Start()
    {
        AudioManager.Instance.PlaySound(gameplayMusicSounds);
    }
}
