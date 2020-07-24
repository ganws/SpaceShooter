using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioSource laser_ht;
    public AudioSource laser_fire;
    public AudioSource asteroid_explode;
    public AudioSource bgmusic;

    void Update()
    {


        AudioListener.volume = UIControl.GameVolume;

        if (UIControl.isMusicOn)
            bgmusic.volume = UIControl.GameVolume;
        else
            bgmusic.volume = 0;

        if (UIControl.isSoundOn)
        {
            laser_ht.volume = UIControl.GameVolume;
            laser_fire.volume = UIControl.GameVolume;
            asteroid_explode.volume = UIControl.GameVolume;
        }
        else
        {
            laser_ht.volume = 0f;
            laser_fire.volume = 0f;
            asteroid_explode.volume = 0f;
        }

    }

    // void playAudioClip(AudioSource or enum? )

}
