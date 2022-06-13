using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioPlayer : MonoBehaviour
{
    public AudioSource

            audioSourceMaster,
            audioSourceSlave;

    public AudioClip[] audioClipMaster;

    public bool

            toggleSound = false,
            isJukebox = false, blockChange = false;

    public bool isOn = true;

    void Awake()
    {
        //if isJukebox then generate random number between 0 and the length of the audioClipMaster mapArray, else do nothing
        if (isJukebox)
        {
            int randomNumber = Random.Range(0, audioClipMaster.Length);
            PlayLoopSound(true, randomNumber);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isOn)
        {
            if (isJukebox)
            {
                int randomNumber = Random.Range(0, audioClipMaster.Length);
                PlayLoopSound(true, randomNumber);
                isOn = true;
            }
        }
    }

    public void PlaySound(bool turnSwitchS, int track)
    {
        toggleSound = turnSwitchS;
        if (turnSwitchS)
        {
            //audioSourceMaster.clip = audioClipMaster[track];
            audioSourceMaster.PlayOneShot(audioClipMaster[track]);
        }
        else
        {
            audioSourceMaster.Stop();
        }
    }

    public void PlayCustomSound(bool turnSwitchS, AudioClip CustomSound)
    {
        toggleSound = turnSwitchS;
        if (turnSwitchS)
        {
            audioSourceMaster.PlayOneShot (CustomSound);
        }
        else
        {
            audioSourceMaster.Stop();
        }
    }

    public void PlayLoopSound(bool turnSwitchS, int track)
    {
        toggleSound = turnSwitchS;
        if (turnSwitchS)
        {
            audioSourceMaster.clip = audioClipMaster[track];
            audioSourceMaster.loop = true;
            audioSourceMaster.Play();
        }
        else
        {
            audioSourceMaster.Stop();
        }
    }
}
