using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MsgListenerModule<AudioManager>
{
    private static AudioManager instance;
    public static AudioManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new AudioManager();
            }
            return instance;
        }
    }

    public AudioSource music;
    public AudioSource sound;

    public static bool HasMusic
    {
        get
        {
            return PlayerPrefs.GetInt("str_HasMusic", 1) == 1;
        }
        set
        {
            PlayerPrefs.SetInt("str_HasMusic", value ? 1 : 0);
        }
    }

    public static bool HasSound
    {
        get
        {
            return PlayerPrefs.GetInt("str_HasSound", 1) == 1;
        }
        set
        {
            PlayerPrefs.SetInt("str_HasSound", value ? 1 : 0);
        }
    }
    public void Init(AudioSource musicSource,AudioSource soundSource)
    {
        this.music = musicSource;
        this.sound = soundSource;

        music.mute = !HasMusic;
        sound.mute = !HasSound;

        Bind(GameEventConst.EVENT_MUSIC_CHANGE);
        Bind(GameEventConst.EVENT_SOUND_CHANGE);
    }

    public override void Excute(string eventName, params object[] args)
    {
        if (GameEventConst.EVENT_MUSIC_CHANGE == eventName)
        {
            music.mute = !HasMusic;
        }
        if (GameEventConst.EVENT_SOUND_CHANGE == eventName)
        {
            sound.mute = !HasSound;
        }
    }


    public static void PlaySound(AudioClip clip)
    {
        if (HasSound)
        {
            Instance.sound.PlayOneShot(clip);
        }

    }

}
