using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Bird))]
[RequireComponent(typeof(AudioSource))]
public class BirdCollisionHandler : MonoBehaviour
{
    [SerializeField] private AudioClip _clip;

    private AudioSource _audio;
    private Bird _bird;

    private void Start()
    {
        _bird = GetComponent<Bird>();
        _audio = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _audio.PlayOneShot(_clip);
        _bird.Die();
    }
}
