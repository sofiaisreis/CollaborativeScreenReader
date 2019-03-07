using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour
{
    public AudioSource myAudioSource;   //Drag a reference to the audio source which will play the music.
    public AudioClip quadrado, circulo, selectedM, exitObjM;
    //public float lowPitchRange = .95f;              //The lowest a sound effect will be randomly pitched.
    //public float highPitchRange = 1.05f;            //The highest a sound effect will be randomly pitched.
    public static Renderer rend;
    

    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
        myAudioSource.playOnAwake = false;
        myAudioSource.clip = circulo;
        myAudioSource.clip = quadrado;
        rend = GetComponent<Renderer>();
        //Set the initial color (0f,0f,0f,0f)
        rend.material.color = new Color (0,0,0);
    }

    public void PlayCircle()
    {
        myAudioSource.Play();
        rend.material.color = new Color(0, 255, 0);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myAudioSource.Play();
            rend.material.color = new Color(0, 255, 0);
        }
        
    }
    public static void PlaySquare()
    {
        rend.material.color = new Color(255, 0, 0);
      //  myAudioSource.clip = quadradoM;
        //myAudioSource.PlayOneShot(quadradoM);
       // Debug.Log("I am playing " + myAudioSource);
    }

    public static void PlayCircle2()
    {
        rend.material.color = new Color(0, 0, 255);
        //myAudioSource.PlayOneShot(circuloM);
    }

    public static void StopSounds()
    {

        rend.material.color = new Color(0, 0, 0);
    }
    /*
    //Read how many
    myAudioSource.PlayOneShot(selected);


    //hide
    //if(!myAudioSource.isPlaying)
    gameObject.SetActive(false);
              //Destroy(this.gameObject);
*/
}

