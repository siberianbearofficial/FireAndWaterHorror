using System;
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    public Slider musicVolumeSlider;
    public Slider soundsVolumeSlider;

    void Start()
    {
        Settings settings = Storage.getSettings();
        settings = Storage.settingsNotNull(settings);
        print("Music volume:");
        print(settings.musicVolume);
        print("Sounds volume:");
        print(settings.soundsVolume);
        musicVolumeSlider.value = settings.musicVolume;
        soundsVolumeSlider.value = settings.soundsVolume;

        musicVolumeSlider.onValueChanged.AddListener(saveMusicVolume);
        soundsVolumeSlider.onValueChanged.AddListener(saveSoundsVolume);
    }

    private void saveMusicVolume(float musicVolume)
    {
        Settings settings = Storage.getSettings();
        settings = Storage.settingsNotNull(settings);
        settings.musicVolume = musicVolume;
        Storage.saveSettings(settings);
    }

    private void saveSoundsVolume(float soundsVolume)
    {
        Settings settings = Storage.getSettings();
        settings = Storage.settingsNotNull(settings);
        settings.soundsVolume = soundsVolume;
        Storage.saveSettings(settings);
    }
}

[Serializable]
public class Settings
{
    public float musicVolume;
    public float soundsVolume;
}

public class Storage
{
    public static void saveSettings(float musicVolume, float soundsVolume)
    {
        Settings settings = new Settings();
        settings.musicVolume = musicVolume;
        settings.soundsVolume = soundsVolume;
        PlayerPrefs.SetString("Settings", JsonUtility.ToJson(settings));
    }

    public static Settings settingsNotNull(Settings settings)
    {
        if (settings == null)
        {
            settings = new Settings();
            settings.musicVolume = 1f;
            settings.musicVolume = 1f;
        }
        return settings;
    }

    public static void saveSettings(Settings settings)
    {
        PlayerPrefs.SetString("Settings", JsonUtility.ToJson(settings));
    }

    public static Settings getSettings()
    {
        return JsonUtility.FromJson<Settings>(PlayerPrefs.GetString("Settings"));
    }
}