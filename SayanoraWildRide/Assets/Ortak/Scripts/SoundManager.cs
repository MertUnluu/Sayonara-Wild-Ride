using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static SoundManager instance;
    public AudioSource source;//music


    public List<AudioClip> soundEffects;
    public List<AudioClip> musics;

    public int music_index = 0;

    private void Start()
    {
        instance = this;
        PlayMusic(music_index);
    }

    public void PlaySoundEffect(int index, Vector3 _position, float _pitch = 1.0f, float randomPitch = 0.0f, float _volume = 1.0f)
    {

        AudioClip ac = soundEffects[index];

        GameObject newSource = new GameObject("SFX:" + ac.name);
        newSource.transform.position = _position;
        AudioSource ao = newSource.AddComponent<AudioSource>();
        ao.volume = _volume;
        ao.pitch = _pitch + Random.Range(-randomPitch, randomPitch);
        ao.PlayOneShot(ac);

        Destroy(newSource, ac.length);
    }

    public void PlayMusic(int index)
    {
        source.clip = musics[index];
        source.Play();

    }

}