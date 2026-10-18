using Sketch.FPS;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace MiniJameGam.Menu
{
    public class SettingsManager : MonoBehaviour
    {
        [SerializeField]
        private PlayerController _player;

        [SerializeField]
        private Slider _xMouseSlider, _yMouseSlider, _bgmVolumeSlider, _soundVolumeSlider;

        [SerializeField]
        private AudioSource _bgm;

        [SerializeField]
        private GameObject _soundsContainer;
        private AudioSource[] _sounds;

        private void Awake()
        {
            _sounds = _soundsContainer.GetComponentsInChildren<AudioSource>();

            _bgm.volume = _bgmVolumeSlider.value;
            _xMouseSlider.value = _player.HorizontalSensitivity;
            _yMouseSlider.value = _player.VerticalSensitivity;
            OnSoundsVolumeChange(_soundVolumeSlider.value);
        }

        public void OnMouseXChange(float value)
        {
            _player.HorizontalSensitivity = value;
        }

        public void OnMouseYChange(float value)
        {
            _player.VerticalSensitivity = value;
        }

        public void OnBgmVolumeChange(float value)
        {
            _bgm.volume = value;
        }

        public void OnSoundsVolumeChange(float value)
        {
            foreach (var s in _sounds) s.volume = value;
        }
    }
}
