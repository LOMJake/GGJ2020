using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PooledSound : MonoBehaviour, IPoolable
{
    public Action OnDeactivate { get; set; }

    public GameObject GameObject => gameObject;

    public AudioSource audioSource;

    public void OnActivate()
    {

    }

    public void Deactivate()
    {
        GameObject.SetActive(false);
        OnDeactivate?.Invoke();
    }
}
