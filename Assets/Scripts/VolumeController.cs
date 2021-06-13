using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeController : MonoBehaviour
{
    public AudioSource music;
    public AudioSource[] sounds;

    void Start()
    {
        Settings settings = Storage.getSettings();
        settings = Storage.settingsNotNull(settings);
        music.volume = settings.musicVolume;
        foreach (AudioSource sound in sounds)
        {
            sound.volume = settings.soundsVolume;
        }
    }
}
