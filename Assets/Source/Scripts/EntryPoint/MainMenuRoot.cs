using AudioMixer;
using General.UI;
using Lean.Localization;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class MainMenuRoot : MonoBehaviour
{
    [SerializeField] private Button _playButton;
    [SerializeField] private SoundInitializer _soundInitializer;

    [Header("Localization")]
    private readonly string _russian = "Russian";
    private readonly string _english = "English";
    private readonly string _turkish = "Turkish";
    [SerializeField] private Button _toEnglish;
    [SerializeField] private Button _toRussian;
    [SerializeField] private Button _toTurkish;

    [Header("Other")]
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
        _soundInitializer.Init();

        if (_musicSource.IsAdded == false)
            _soundInitializer.AddMusicSource(_musicSource.Music);
        else
            _soundInitializer.AddMusicSourceWithoutVolumeChanging(_musicSource.Music);

        _sceneChanger.FadeOut();

        _toEnglish.onClick.AddListener(ChangeLanguageToEnglish);
        _toRussian.onClick.AddListener(ChangeLanguageToRussian);
        _toTurkish.onClick.AddListener(ChangeLanguageToTurkish);

        _playButton.onClick.AddListener(OnPlayButtonClick);
    }

    private void OnDestroy()
    {
        _toEnglish.onClick.RemoveListener(ChangeLanguageToEnglish);
        _toRussian.onClick.RemoveListener(ChangeLanguageToRussian);
        _toTurkish.onClick.RemoveListener(ChangeLanguageToTurkish);

        _playButton.onClick.RemoveListener(OnPlayButtonClick);
    }

    private void OnPlayButtonClick()
    {
        _sceneChanger.LoadScene(Scenes.Game.ToString());
    }

    private void ChangeLanguageToRussian()
    {
        SetLanguage(_russian);
    }

    private void ChangeLanguageToTurkish()
    {
        SetLanguage(_turkish);
    }

    private void ChangeLanguageToEnglish()
    {
        SetLanguage(_english);
    }

    private void SetLanguage(string language)
    {
        LeanLocalization.SetCurrentLanguageAll(language);
        LeanLocalization.UpdateTranslations();
    }
}
