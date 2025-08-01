using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sounds
{
    public int Id;
    public string Name;
    public AudioClip audioClip;
}
public class SoundManager : MonoBehaviour
{

    public List<Sounds> SFXList = new();
    public List<Sounds> BGMList = new();
    public AudioClip SetSoundSFX(int Id)
    {
        return SFXList[Id].audioClip;
    }
    public AudioClip SetSoundBGM(int Id)
    {
        return BGMList[Id].audioClip;
    }

}
