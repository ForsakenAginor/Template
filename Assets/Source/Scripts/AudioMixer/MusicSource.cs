using UnityEngine;

namespace AudioMixer
{
    public interface IMusicSource
    {
        bool IsAdded { get; }
        AudioSource Music { get; }
    }

    public class MusicSource : MonoBehaviour, IMusicSource
    {
        [SerializeField] private AudioSource _music;
        private bool _isAdded;

        public AudioSource Music
        {
            get
            {
                _isAdded = true;
                return _music;
            }
        }

        public bool IsAdded => _isAdded;
    }
}