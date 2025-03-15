using UnityEngine;

[System.Serializable]
public class Scr_Sound_SoundConfig
{
    [SerializeField] private SoundType _soundType;
    [SerializeField] private AudioClip _audioClip;
    [SerializeField] [Range(0f, 1f)] private float _volume = 1f;
    [SerializeField] private bool _loop = false;

    public SoundType SoundType
    {
        get { return _soundType; }
    }
    public AudioClip AudioClip
    {
        get { return _audioClip; }
    }
    public float Volume
    {
        get { return _volume; }
    }
    public bool Loop
    {
        get { return _loop; }
    }
}

public enum SoundType
{
    ItemPickup,
    Ambient,
    UIClick,
}
