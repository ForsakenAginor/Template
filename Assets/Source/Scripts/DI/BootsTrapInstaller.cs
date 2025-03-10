using AudioMixer;
using General.UI;
using UnityEngine;
using Zenject;

namespace DI
{
    public class BootsTrapInstaller : MonoInstaller
    {
        [SerializeField] private SceneChanger _sceneChanger;
        [SerializeField] private MusicSource _musicSource;

        public override void InstallBindings()
        {
            InitSceneChanger();
            InitMusicSource();
        }

        private void InitSceneChanger()
        {
            Container
                .Bind<ISceneChanger>()
                .To<SceneChanger>()
                .FromComponentInNewPrefab(_sceneChanger)
                .AsSingle();
        }

        private void InitMusicSource()
        {
            Container
                .Bind<IMusicSource>()
                .To<MusicSource>()
                .FromComponentInNewPrefab(_musicSource)
                .AsSingle();
        }
    }
}