using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundButton : MonoBehaviour
{
    public AudioClip clip;

    public void OnClicButtonSFX()
    {
        SoundManager.Instance.PlaySound(clip);
    }
    public void OnClicButtonMusic()
    {
        SoundManager.Instance.PlayMusic(clip);
    }
}
