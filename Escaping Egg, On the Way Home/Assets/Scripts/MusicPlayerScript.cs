using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayerScript : MonoBehaviour
{
    //define the audio volume
    public AudioSource AudioSource;
    private float musicVolume = 1f;

    // Start is called before the first frame update
    void Start()
    {   
        AudioSource.Play();
        
    }

    // Update is called once per frame
    void Update()
    {
        AudioSource.volume = musicVolume;
        
    }

    //Update the volume based on the slider
    public void updateVolume( float volume){
        musicVolume = volume;
    }
}
