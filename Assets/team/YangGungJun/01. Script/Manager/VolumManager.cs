using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeManager : MonoBehaviour
{
    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private AudioMixer audioMixer;

    private const string MASTER_VOLUME_KEY = "MasterVolume";
    private const string SFX_VOLUME_KEY = "SFXVolume";

    private void Start()
    {
        float savedMaster = PlayerPrefs.GetFloat(MASTER_VOLUME_KEY, 0.75f);
        float savedSFX = PlayerPrefs.GetFloat(SFX_VOLUME_KEY, 0.75f);

        masterSlider.value = savedMaster;
        sfxSlider.value = savedSFX;

        SetMasterVolume(savedMaster);
        SetSFXVolume(savedSFX);

        masterSlider.onValueChanged.AddListener(SetMasterVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);
    }
    public void SetMasterVolume(float value)
    {
        float dB = Mathf.Log10(Mathf.Clamp(value, 0.0001f, 1f)) * 20f;
        audioMixer.SetFloat("MasterVolume", dB);
        PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, value);
    }
    public void SetSFXVolume(float value)
    {
        float dB = Mathf.Log10(Mathf.Clamp(value, 0.0001f, 1f)) * 20f;
        audioMixer.SetFloat("SFXVolume", dB);
        PlayerPrefs.SetFloat(SFX_VOLUME_KEY, value);
    }
}
