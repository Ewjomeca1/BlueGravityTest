using System;
using UnityEngine;

public class Scr_Manager_AudioManager : MonoBehaviour, Scr_Interface_InventoryObserver
{
    [SerializeField] private static Scr_Manager_AudioManager _instance;
    
    public static Scr_Manager_AudioManager Instance
    {
        get { return _instance; }
    }

    [SerializeField] private Scr_Sound_SoundConfig[] _soundConfig;

    private AudioSource audioSource;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        
       
    }

    private void Start()
    {
        Scr_Inventory_BaseInventory.Instance.AddObserver(this);
    }

    public void OnInventoryChanged(Scr_Inventory_BaseInventory inventory)
    {
        PlaySound(SoundType.ItemPickup);
    }
    
    public void PlaySound(SoundType soundType)
    {
        Scr_Sound_SoundConfig config = GetSoundConfig(soundType);
        if (config != null && config.AudioClip != null)
        {
            audioSource.volume = config.Volume;
            audioSource.loop = config.Loop;
            audioSource.PlayOneShot(config.AudioClip);
        }
        else
        {
            Debug.LogWarning($"Sound config for {soundType} not found or audio clip is missing.");
        }
    }
    
    private Scr_Sound_SoundConfig GetSoundConfig(SoundType soundType)
    {
        foreach (var config in _soundConfig)
        {
            if (config.SoundType == soundType)
            {
                return config;
            }
        }
        return null;
    }
    
    private void OnDestroy()
    {
        if (Scr_Inventory_BaseInventory.Instance != null)
        {
            Scr_Inventory_BaseInventory.Instance.RemoveObserver(this);
        }
    }
}
