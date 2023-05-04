using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VolumeSlider : MonoBehaviour
{
    // https://www.youtube.com/watch?v=nTLgzvklgU8&ab_channel=Tarodev

    [SerializeField] private Slider slider;
    [SerializeField] private TextMeshProUGUI slidertext;

    void Start()
    {
        slider.onValueChanged.AddListener((v) =>{
            slidertext.text = v.ToString("0.00");
        });

        if(!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();
        }

        else
        {
            Load();
        }

    }
          public void ChangeVolume()
        {
            AudioListener.volume = slider.value;
            Save();
        }

        private void Load()
        {
            slider.value = PlayerPrefs.GetFloat("musicVolume");
        }

        private void Save()
        {
            PlayerPrefs.SetFloat("musicVolume", slider.value);
        }
}
