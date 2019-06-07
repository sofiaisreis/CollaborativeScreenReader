using UnityEngine;
using System;


/* APLICACAO PC ZENNIE */

[RequireComponent(typeof(AudioSource))]
public class Male : MonoBehaviour
{
    private AudioSource myAudioSource;
    public AudioClip
        M2_quadrado, M2_circulo, M2_triangulo,
        ding, selected, error;

    // Start is called before the first frame update
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!myAudioSource.isPlaying)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.white;
        }
    }

    public void PlaySquare()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.blue;
        myAudioSource.PlayOneShot(M2_quadrado);

    }

    public void PlayCircle()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.blue;
        myAudioSource.PlayOneShot(M2_circulo);
    }

    public void PlayTriangle()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.blue;
        myAudioSource.PlayOneShot(M2_triangulo);
    }

    public void PlaySelected()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.blue;
        myAudioSource.PlayOneShot(selected);
    }

    public void PlayError()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.blue;
        myAudioSource.PlayOneShot(error);
    }

    public void Stop()
    {
        myAudioSource.Stop();
    }
}