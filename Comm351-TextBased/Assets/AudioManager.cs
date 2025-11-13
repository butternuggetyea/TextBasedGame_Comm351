using UnityEngine;

public class AudioManager : MonoBehaviour
{
    AudioSource _source;

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

    public void PlayText() 
    {
        _source.volume = volume/100;
        _source.pitch = Random.Range(1, 1.25f);
        _source.PlayOneShot(_clips[Random.Range(0, 2)]);
    }

}
