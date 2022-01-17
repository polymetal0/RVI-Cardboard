using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoloMusic : MonoBehaviour
{
    public AudioSource[] clips;
    public GameObject reverb;
    // Start is called before the first frame update
    void Start()
    {
        //clips = GetComponentsInChildren<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
                    Debug.Log("puta " + soloClip + clip.gameObject.name);
                }
                else
                {
                    clip.mute = false;
                }
            }
        }

    }

    public void UnMuteAll()
    {
        foreach (AudioSource clip in clips)
        {
            clip.mute = false;
            
        }


        reverb.SetActive(true);


    }
}
