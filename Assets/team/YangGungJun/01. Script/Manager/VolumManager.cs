using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using static UnityEngine.Rendering.DebugUI;

public class VolumeManager : MonoBehaviour
{
    private Slider masterSlider;
    private Slider sfxSlider;
    private Slider BGMSlider;
    [SerializeField] private AudioMixer audioMixer;

    private const string MASTER_VOLUME_KEY = "MasterVolume";
    private const string SFX_VOLUME_KEY = "SFXVolume";
    private const string BGM_VOLUME_KEY = "BGMVolume";

    float beforeMaster;
    float beforeSFX;
    float beforeBGM;


    private void Start()
    {
        float savedMaster = PlayerPrefs.GetFloat(MASTER_VOLUME_KEY, 0.75f);
        float savedSFX = PlayerPrefs.GetFloat(SFX_VOLUME_KEY, 0.75f);
        float savedBGM = PlayerPrefs.GetFloat(BGM_VOLUME_KEY, 0.75f);

        masterSlider.value = savedMaster;
        sfxSlider.value = savedSFX;
        BGMSlider.value = savedBGM;

        SetMasterVolume(savedMaster);
        SetSFXVolume(savedSFX);
        SetBGMVolume(savedBGM);
        masterSlider.onValueChanged.AddListener(SetMasterVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);
        BGMSlider.onValueChanged.AddListener(SetBGMVolume);
    }
    public void SetSliders(Slider master, Slider sfx, Slider bgm)
    {
        masterSlider = master;
        sfxSlider = sfx;
        BGMSlider = bgm;

        masterSlider.value = PlayerPrefs.GetFloat("MasterVolume", 0.75f);
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume", 0.75f);
        BGMSlider.value = PlayerPrefs.GetFloat("BGMVolume", 0.75f);

        masterSlider.onValueChanged.AddListener(SetMasterVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);
        BGMSlider.onValueChanged.AddListener(SetBGMVolume);
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
    public void SetBGMVolume(float value)
    {
        float dB = Mathf.Log10(Mathf.Clamp(value, 0.0001f, 1f)) * 20f;
        audioMixer.SetFloat("BGMVolume", dB);
        PlayerPrefs.SetFloat(BGM_VOLUME_KEY, value);
    }
    public void MuteAll()
    {
        beforeMaster = masterSlider.value;
        beforeSFX = sfxSlider.value;
        beforeBGM = BGMSlider.value;


        masterSlider.value = 0;
        sfxSlider.value = 0;
        BGMSlider.value = 0;

        audioMixer.SetFloat("MasterVolume", -80f);
        audioMixer.SetFloat("SFXVolume", -80f);
        audioMixer.SetFloat("BGMVolume", -80f);

        PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, 0);
        PlayerPrefs.SetFloat(SFX_VOLUME_KEY, 0);
        PlayerPrefs.SetFloat(BGM_VOLUME_KEY, 0);
    }

    public void MuteNoAll()
    {

        masterSlider.onValueChanged.RemoveListener(SetMasterVolume);
        sfxSlider.onValueChanged.RemoveListener(SetSFXVolume);
        BGMSlider.onValueChanged.RemoveListener(SetBGMVolume);


        masterSlider.value = beforeMaster;
        sfxSlider.value = beforeSFX;
        BGMSlider.value = beforeBGM;


        SetMasterVolume(beforeMaster);
        SetSFXVolume(beforeSFX);
        SetBGMVolume(beforeBGM);


        masterSlider.onValueChanged.AddListener(SetMasterVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);
        BGMSlider.onValueChanged.AddListener(SetBGMVolume);
    }

}
