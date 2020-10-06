using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;
[System.Serializable]
public class Sound
{
    public string NameOfAudio;
    public AudioClip Clip;
    [Range(0f,1f)]
    public float Volume;
    [Range(0.1f, 3f)]
    public float Pitch;

    [Range(0f, 1f)]
    public float SpatialBlend;
    public float minRollOffDistance;
    public float maxRollOffDistance;
    [HideInInspector]
    public AudioSource Source;
    public bool Loop;
}
public class AudioManager : MonoBehaviour
{
    #region Start and Update/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    private void Awake()
    {
        DontDestroyAudioManager();
        UpdateUISoundsOnStart();
        UpdatePlayerSoundsOnStart();
    }

    private void Start()
    {
        FindObjectOfType<AudioManager>().PlayPlayerSoundNotOne("Ambience");
        StartCoroutine(Soundouts());
        StartCoroutine(Soundouts2());
    }
    private void Update()
    {
       
    }
    public bool keepPlaying = true;
    IEnumerator Soundouts()
    { 
        while (keepPlaying)
        {
            FindObjectOfType<AudioManager>().PlayPlayerSoundNotOne("Ambience2");
            yield return new WaitForSeconds(15f);
         }
    }
    IEnumerator Soundouts2()
    { 
        while (keepPlaying)
        {
            FindObjectOfType<AudioManager>().PlayPlayerSoundNotOne("Ambience3");
            yield return new WaitForSeconds(30f);
         }
    }
    public static AudioManager instance;
    private void DontDestroyAudioManager()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }
    #endregion///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    #region UISounds/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    [SerializeField]
    private Sound[] UISounds;
    private void UpdateUISoundsOnStart()
    {
        foreach (Sound UISound in UISounds)
        {
            UISound.Source = gameObject.AddComponent<AudioSource>();
            UISound.Source.clip = UISound.Clip;
            UISound.Source.volume = UISound.Volume;
            UISound.Source.pitch = UISound.Pitch;
            UISound.Source.loop = UISound.Loop;
            UISound.Source.spatialBlend = UISound.SpatialBlend;
        }
    }
    public void PlayUISound(string NameOfAudio)
    {

        Sound UISound = Array.Find(UISounds, Sound => Sound.NameOfAudio == NameOfAudio);
        if(UISound==null)
        {
            Debug.LogWarning("UISound: " + NameOfAudio + " not found!");
            return;
        }
        UISound.Source.PlayOneShot(UISound.Source.clip);
    }
    #endregion///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    #region PlayerSounds//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    [SerializeField]
    private Sound[] PlayerSounds;
    private void UpdatePlayerSoundsOnStart()
    {
        foreach (Sound PlayerSound in PlayerSounds)
        {
            PlayerSound.Source = gameObject.AddComponent<AudioSource>();
            PlayerSound.Source.clip = PlayerSound.Clip;
            PlayerSound.Source.volume = PlayerSound.Volume;
            PlayerSound.Source.pitch = PlayerSound.Pitch;
            PlayerSound.Source.loop = PlayerSound.Loop;
            PlayerSound.Source.spatialBlend = PlayerSound.SpatialBlend;
            PlayerSound.Source.rolloffMode = AudioRolloffMode.Logarithmic;
            PlayerSound.Source.minDistance = PlayerSound.minRollOffDistance;
            PlayerSound.Source.maxDistance = PlayerSound.maxRollOffDistance;
        }
    }
    public void PlayPlayerSound(string NameOfAudio)
    {
        Sound PlayerSound = Array.Find(PlayerSounds, Sound => Sound.NameOfAudio == NameOfAudio);
        if (PlayerSound == null)
        {
            Debug.LogWarning("PlayerSound: " + NameOfAudio + " not found!");
            return;
        }
        PlayerSound.Source.PlayOneShot(PlayerSound.Source.clip);
    }
    public void PlayPlayerSoundNotOne(string NameOfAudio)
    {
        Sound PlayerSound = Array.Find(PlayerSounds, Sound => Sound.NameOfAudio == NameOfAudio);
        if (PlayerSound == null)
        {
            Debug.LogWarning("PlayerSound: " + NameOfAudio + " not found!");
            return;
        }
        PlayerSound.Source.Play();
    }
    public void StopPlayerSound(string NameOfAudio)
    {
        Sound PlayerSound = Array.Find(PlayerSounds, Sound => Sound.NameOfAudio == NameOfAudio);
        if (PlayerSound == null)
        {
            Debug.LogWarning("PlayerSound: " + NameOfAudio + " not found!");
            return;
        }
        PlayerSound.Source.Stop();
    }
    #endregion////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    #region EnemySounds////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //
    #endregion////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
}
