using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Female : MonoBehaviour
{
    private AudioSource myAudioSource;
    private AudioSource myAudioSourceLower;
    public AudioClip
        F1_quadrado, F1_circulo, F1_triangulo,
        ding, selected, error, gz, soPodeQuad;
    public Select selection;
    public Public publicos;


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
        gameObject.GetComponent<Renderer>().material.color = Color.magenta;
        myAudioSource.PlayOneShot(F1_quadrado);

    }

    public void PlayCircle()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.magenta;
        myAudioSource.PlayOneShot(F1_circulo);

    }

    public void PlayTriangle()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.magenta;
        myAudioSource.PlayOneShot(F1_triangulo);
    }

    public void PlaySelected(int lastObj, int selecao, int totais)
    {
        gameObject.GetComponent<Renderer>().material.color = Color.magenta;
        selection.GetComponent<Select>().SelectionF(lastObj, selecao, totais);
    }

    public void PlayError(bool soPode = true)
    {
        gameObject.GetComponent<Renderer>().material.color = Color.magenta;
        selection.GetComponent<Select>().ErrorF(soPode);

    }

    public void PlayErrorVazio()
    {
        selection.GetComponent<Select>().ErrorFVazio();
    }



    // PUBLICS LOWER VOLUME
    public void PlaySelectedPublic(int lastObj, int selecao, int totais)
    {
        publicos.GetComponent<Public>().SelectedPublicF(lastObj, selecao, totais);
    }

    public void PlayErrorPublic(bool soPode = true)
    {
        gameObject.GetComponent<Renderer>().material.color = Color.magenta;
        publicos.GetComponent<Public>().ErrorVazioPublicF();
        //publicos.GetComponent<Public>().ErrorPublicF(soPode);
    }

    public void PlayErrorVazioPublic()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.magenta;
        publicos.GetComponent<Public>().ErrorVazioPublicF();
    }

    public void Stop()
    {
        myAudioSource.Stop();
    }
}
