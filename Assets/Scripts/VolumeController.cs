using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{

    public Slider volumeSlider;

    void Start()
    {
        if (PlayerPrefs.HasKey("volume"))
        {
            Load();
        }
        else
        {
            Save();
        }
    }

    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        Save();
    }

    void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("volume");
    }

    void Save()
    {
        PlayerPrefs.SetFloat("volume", volumeSlider.value);
    }
}
