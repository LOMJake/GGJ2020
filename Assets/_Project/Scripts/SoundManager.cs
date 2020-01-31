using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    public PooledSound pooledSoundPrefab;
    private ObjectPool<PooledSound> soundPool;
    protected override void Awake()
    {
        base.Awake();
        soundPool = new ObjectPool<PooledSound>(40);
        soundPool.Populate(pooledSoundPrefab);
    }

    public void PlaySound(AudioClip clip, Vector3 position)
    {
        if(soundPool.TryActivate(out PooledSound sound))
        {
            sound.transform.position = position;
            sound.audioSource.clip = clip;
            sound.audioSource.Play();
        }
    }
}
