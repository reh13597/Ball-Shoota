using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    public AudioClip shootingSound;
    public AudioClip walkingSound;
    AudioSource audioSrc;

    void Start()
    {
        shootingSound = Resources.Load<AudioClip>("footstep");
        walkingSound = Resources.Load<AudioClip>("laser");

        audioSrc.GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "fire":
                audioSrc.PlayOneShot(shootingSound);
                break;
            case "walk":
                audioSrc.PlayOneShot(walkingSound);
                break;  

        }       
    }
}
