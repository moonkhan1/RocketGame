using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityProject1.Abstracts.Utilities;

public class SoundManager : SingletonThisObject<SoundManager>
{

    AudioSource [] _audioSource;
    private void Awake() {
        SingletonThisGameObject(this);

        _audioSource = GetComponentsInChildren<AudioSource>();
    }

public void PlayMusic(int index)
{
    if(!_audioSource[index].isPlaying)
    {
        _audioSource[index].Play();
    }
}
public void StopMusic(int index)
{
    if(_audioSource[index].isPlaying)
    {
        _audioSource[index].Stop();
    }
}
}
