using UnityEngine;

public class AudioManager : MonoBehaviour
{
    AudioSource _source;

    public AudioSource _soundEffects;

    public float volume;

    public AudioClip[] _clips;

    private void Awake()
    {
        _source = GetComponent<AudioSource>();
    }

    public void PlayButtonHover() 
    {
        _source.volume = volume / 100;
       
        _source.PlayOneShot(_clips[2]);

    }

    public void StopAllEffects() 
    {
        _soundEffects.Stop();
    }

    public void PlayOnCharIndex(AudioClip clip) 
    {
        _soundEffects.volume = volume / 100;
        _soundEffects.pitch = 1;
        _soundEffects.PlayOneShot(clip);
    }

    public void PlayText() 
    {
        _source.volume = volume/100;
        _source.pitch = Random.Range(1, 1.25f);
        _source.PlayOneShot(_clips[Random.Range(0, _clips.Length-1)]);
    }

}
