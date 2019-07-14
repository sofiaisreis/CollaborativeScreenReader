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

    public void PlaySelected(int lastObj, int selecaoQuad, int selecaoCirc, int totais)
    {
        gameObject.GetComponent<Renderer>().material.color = Color.blue;
        myAudioSource.PlayOneShot(selected);
        selection.GetComponent<Select>().SelectionM(lastObj, selecaoQuad, selecaoCirc, totais);
    }

    public void PlaySelectedGod(int lastObj, int selecaoQuad, int selecaoCirc, int totais)
    {
        gameObject.GetComponent<Renderer>().material.color = Color.blue;
        myAudioSource.PlayOneShot(selected);
        selection.GetComponent<Select>().SelectionGod(lastObj, selecaoQuad, selecaoCirc, totais);
    }

    public void PlayError(bool soPode = true)
    {
        gameObject.GetComponent<Renderer>().material.color = Color.blue;
        selection.GetComponent<Select>().ErrorM(soPode);
    }

    public void PlayErrorVazio()
    {
        selection.GetComponent<Select>().ErrorFVazio();
    }


    //PUBLICS LOWER VOLUME
    public void PlaySelectedPublic(int lastObj, int selecao, int totais)
    {
        gameObject.GetComponent<Renderer>().material.color = Color.blue;
        publicos.GetComponent<Public>().SelectedPublicM(lastObj, selecao, totais);
    }

    public void PlayErrorPublic(bool soPode = true)
    {
        gameObject.GetComponent<Renderer>().material.color = Color.blue;
        //TO DO fica? publicos.GetComponent<Public>().ErrorPublicM(soPode);
    }

    public void PlayErrorVazioPublic()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.blue;
        publicos.GetComponent<Public>().ErrorVazioPublicM();
    }

    public void Stop()
    {
        myAudioSource.Stop();
    }
}