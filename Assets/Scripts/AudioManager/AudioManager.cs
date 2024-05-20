using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private const string PLAYER_PREFS_SOUND_VOLUME = "SoundVolume";
    private const string PLAYER_PREFS_MUSIC_VOLUME = "MusicVolume";

    public Sound[] sounds;

    public static AudioManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            if (s.name == "Theme")
            {
                s.source.volume = s.volume = PlayerPrefs.GetFloat(PLAYER_PREFS_MUSIC_VOLUME, 1f);
            }
            else
            {
                s.source.volume = s.volume = PlayerPrefs.GetFloat(PLAYER_PREFS_SOUND_VOLUME, 1f);
            }

            s.source.loop = s.loop;
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found");
            return;
        }

        s.source.Play();
    }

    public void OffSounds()
    {
        PlayerPrefs.SetFloat(PLAYER_PREFS_SOUND_VOLUME, 0f);

        foreach (Sound s in sounds)
        {
            if (s.name == "Theme")
            {
                continue;
            }
            else
            {
                s.source.volume = s.volume = PlayerPrefs.GetFloat(PLAYER_PREFS_SOUND_VOLUME);
            }
        }
    }

    public void OnSounds()
    {
        PlayerPrefs.SetFloat(PLAYER_PREFS_SOUND_VOLUME, 1f);

        foreach (Sound s in sounds)
        {
            if (s.name == "Theme")
            {
                continue;
            }
            else
            {
                s.source.volume = s.volume = PlayerPrefs.GetFloat(PLAYER_PREFS_SOUND_VOLUME);
            }
        }
    }

    public void OffMusic()
    {
        PlayerPrefs.SetFloat(PLAYER_PREFS_MUSIC_VOLUME, 0f);

        foreach (Sound s in sounds)
        {
            if (s.name == "Theme")
            {
                s.source.volume = s.volume = PlayerPrefs.GetFloat(PLAYER_PREFS_MUSIC_VOLUME);
            }
            else
            {
                continue;
            }
        }
    }

    public void OnMusic()
    {
        PlayerPrefs.SetFloat(PLAYER_PREFS_MUSIC_VOLUME, 1f);

        foreach (Sound s in sounds)
        {
            if (s.name == "Theme")
            {
                s.source.volume = s.volume = PlayerPrefs.GetFloat(PLAYER_PREFS_MUSIC_VOLUME);
            }
            else
            {
                continue;
            }
        }
    }

    public bool SoundsPlay()
    {
        if (PlayerPrefs.GetFloat(PLAYER_PREFS_SOUND_VOLUME) == 1f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool MusicPlay()
    {
        if (PlayerPrefs.GetFloat(PLAYER_PREFS_MUSIC_VOLUME) == 1f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
