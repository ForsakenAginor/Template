using AudioMixer;
using General.UI;
using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class Root : MonoBehaviour
{
    [Header("Other")]
    [SerializeField] private SoundInitializer _soundInitializer;
    [SerializeField] private Button _closeButton;
    private ISceneChanger _sceneChanger;
    private IMusicSource _musicSource;

    [Inject]
    public void Construct(ISceneChanger sceneChanger, IMusicSource musicSource)
    {
        _sceneChanger = sceneChanger;
        _musicSource = musicSource;
    }

    private void Start()
    {
        InitAudioMixer();

        _closeButton.onClick.AddListener(OnCloseButtonClick);
        _sceneChanger.FadeOut();
    }

    private void OnDestroy()
    {
        _closeButton.onClick.RemoveListener(OnCloseButtonClick);
    }

    private void OnCloseButtonClick()
    {
        _sceneChanger.LoadScene(Scenes.Menu.ToString());
    }

    private void InitAudioMixer()
    {
        _soundInitializer.Init();

        if (_musicSource.IsAdded == false)
            _soundInitializer.AddMusicSource(_musicSource.Music);
        else
            _soundInitializer.AddMusicSourceWithoutVolumeChanging(_musicSource.Music);

    }

    private void AddAudioSourceToMixer(AudioSource audioSource)
    {
        if (audioSource == null)
            throw new ArgumentNullException(nameof(audioSource));

        _soundInitializer.AddEffectSource(audioSource);
    }
}
