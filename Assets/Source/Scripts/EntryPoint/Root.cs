using AudioMixer;
using General.UI;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Root : MonoBehaviour
{
    [Header("Other")]
    [SerializeField] private SoundInitializer _soundInitializer;
    [SerializeField] private Button _closeButton;

    private void Start()
    {
        InitAudioMixer();

        _closeButton.onClick.AddListener(OnCloseButtonClick);
        SceneChangerSingleton.Instance.FadeOut();
    }

    private void OnDestroy()
    {
        _closeButton.onClick.RemoveListener(OnCloseButtonClick);
    }

    private void OnCloseButtonClick()
    {
        SceneChangerSingleton.Instance.LoadScene(Scenes.Menu.ToString());
    }

    private void InitAudioMixer()
    {
        _soundInitializer.Init();

        if (MusicSingleton.Instance.IsAdded == false)
            _soundInitializer.AddMusicSource(MusicSingleton.Instance.Music);
        else
            _soundInitializer.AddMusicSourceWithoutVolumeChanging(MusicSingleton.Instance.Music);

    }

    private void AddAudioSourceToMixer(AudioSource audioSource)
    {
        if (audioSource == null)
            throw new ArgumentNullException(nameof(audioSource));

        _soundInitializer.AddEffectSource(audioSource);
    }
}
