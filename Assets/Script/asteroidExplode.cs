using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidExplode : MonoBehaviour
{
    private AudioSource source;

    private void Start()
    {
        //source = FindObjectOfType<AudioClip>().name("")
    }
    private void OnDestroy()
    {
        source.Play();
        Debug.Log("asteroid explode");
    }
}
