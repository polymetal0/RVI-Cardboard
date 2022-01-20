using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoloMusic : MonoBehaviour
{
    public AudioSource[] clips;
    public GameObject reverb;

    public void MuteAll(string soloClip)
    {
        if (soloClip == "Reverb")
        {
            reverb.SetActive(false);
        }
        else
        {
            foreach (AudioSource clip in clips)
            {
                if (clip.gameObject.name != soloClip)
                {
                    clip.mute = true;
                }
            }
        }

    }

    public void UnmuteAll()
    {
        foreach (AudioSource clip in clips)
        {
            clip.mute = false;
            
        }


        reverb.SetActive(true);


    }
}
