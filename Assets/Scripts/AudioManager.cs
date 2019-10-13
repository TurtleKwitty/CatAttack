using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioClip bigExplosion, chopWood, laserShot1, laserShot2, metalHit, mineExplosion, miningRock;
    static AudioSource audioSrc;
    void Start()
    {
        bigExplosion = Resources.Load<AudioClip>("bigExplosion");
        chopWood = Resources.Load<AudioClip>("chopWood");
        laserShot1 = Resources.Load<AudioClip>("laserShot1");
        laserShot2 = Resources.Load<AudioClip>("laserShot2");
        metalHit = Resources.Load<AudioClip>("metalHit");
        mineExplosion = Resources.Load<AudioClip>("mineExplosion");
        miningRock = Resources.Load<AudioClip>("miningRock");

        audioSrc = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch(clip)
        {
            case "bigExplosion":
                audioSrc.PlayOneShot(bigExplosion);
                break;
            case "chopWood":
                audioSrc.PlayOneShot(chopWood);
                break;
            case "laserShot1":
                audioSrc.PlayOneShot(laserShot1);
                break;
            case "laserShot2":
                audioSrc.PlayOneShot(laserShot2);
                break;
            case "metalHit":
                audioSrc.PlayOneShot(metalHit);
                break;
            case "mineExplosion":
                audioSrc.PlayOneShot(mineExplosion);
                break;
            case "miningRock":
                audioSrc.PlayOneShot(miningRock);
                break;
        }
    }
}
