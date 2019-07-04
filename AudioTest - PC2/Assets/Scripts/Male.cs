using UnityEngine;
using System;


/* APLICACAO PC ZENNIE */

[RequireComponent(typeof(AudioSource))]
public class Male : MonoBehaviour
{
    private AudioSource myAudioSource;
    public AudioClip
        M2_quadrado, M2_circulo, M2_triangulo,
        ding, selected, error, gz, soPodeCirc;
    public Select selection;

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

    public void PlaySelected(int lastObj, int selecao, int totais)
    {
        gameObject.GetComponent<Renderer>().material.color = Color.blue;
        myAudioSource.PlayOneShot(selected);
        selection.GetComponent<Select>().SelectionM(lastObj, selecao, totais);
    }

    public void PlayError(bool soPode = true)
    {
        gameObject.GetComponent<Renderer>().material.color = Color.blue;
        selection.GetComponent<Select>().ErrorM(soPode);
    }

    public void Stop()
    {
        myAudioSource.Stop();
    }
}