using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MenuEvents : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioMixer mixer;
    private float saveVolumeValue;

    void Start()
    {
      LoadVolumeValues();
    }

    public void SetVolume()
    {
        mixer.SetFloat("Volume", volumeSlider.value);
    }

    public void LoadLevel(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void SaveVolume()
    {
        saveVolumeValue = volumeSlider.value;
        PlayerPrefs.SetFloat("VolumeValue", saveVolumeValue);
        LoadVolumeValues();
    }


    void LoadVolumeValues()
    {
        saveVolumeValue = PlayerPrefs.GetFloat("VolumeValue");
        volumeSlider.value = saveVolumeValue;
    }
}
