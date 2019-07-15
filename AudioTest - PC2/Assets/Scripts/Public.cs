using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(AudioSource))]
public class Public : MonoBehaviour
{
    //public
    private AudioSource myAudioSourceLow;
    public AudioClip f1cF, f1cM,
                     f2cF, f2cM,
                     f3cF, f3cM,
                     f4cF, f4cM,
                     f5cF, f5cM,
                     f1qF, f1qM,
                     f2qF, f2qM,
                     f3qF, f3qM,
                     f4qF, f4qM,
                     f5qF, f5qM,
                     selected,
                     errorSound,
                     soPodeQuad,
                     soPodeCirc;
    public Select sele;
    public GameObject somEntrada;
    public bool TTF = false;
    public bool TTM = false;

    public int faltamTotalF = -1;
    public int faltamTotalM = -1;

    /* Object:
     * quad = 1
     * circ = 2 */

    public void Start()
    {
        myAudioSourceLow = GetComponent<AudioSource>();
    }
    
    //PUBLICS

    public void SelectedPublicF(int lastObj, int selecao, int totais)
    {
        myAudioSourceLow.PlayOneShot(selected);
        System.Threading.Thread.Sleep((int)selected.length + 300);
        switch (lastObj)
        {
            case 1: //quadrado
                if (selecao <= totais)
                {
                    int selecf = totais - selecao;
                    if (selecf == 1) myAudioSourceLow.PlayOneShot(f1qF);
                    else if (selecf == 2) myAudioSourceLow.PlayOneShot(f2qF);
                    else if (selecf == 3) myAudioSourceLow.PlayOneShot(f3qF);
                    else if (selecf == 4) myAudioSourceLow.PlayOneShot(f4qF);
                    else if (selecf == 5) myAudioSourceLow.PlayOneShot(f5qF);
                    else if (selecf == 0) print("Acabaram os quadrados!");
                }
                else
                {
                    print("Something is wrong!");
                }
                break;
        }
    }

    public void SelectedPublicM(int lastObj,int selecao, int totais)
    {
        myAudioSourceLow.PlayOneShot(selected);
        System.Threading.Thread.Sleep((int)selected.length + 300);
        switch (lastObj)
        {
            case 2: //circulo
                if (selecao <= totais)
                {
                    int selecm = totais - selecao;
                    if (selecm == 1) myAudioSourceLow.PlayOneShot(f1qF);
                    else if (selecm == 2) myAudioSourceLow.PlayOneShot(f2qF);
                    else if (selecm == 3) myAudioSourceLow.PlayOneShot(f3qF);
                    else if (selecm == 4) myAudioSourceLow.PlayOneShot(f4qF);
                    else if (selecm == 5) myAudioSourceLow.PlayOneShot(f5qF);
                    else if (selecm == 0) print("Acabaram os circulos!");
                }
                else
                {
                    print("Something is wrong!");
                }
                break;
        }
    }
    

    public void ErrorPublicF(bool soPode = true)
    {
        myAudioSourceLow.PlayOneShot(errorSound);
        if (soPode)
        {
            System.Threading.Thread.Sleep((int)errorSound.length + 300);
            //myAudioSourceLow.PlayOneShot(soPodeQuad);
        }
    }

    public void ErrorPublicM(bool soPode = true)
    {
        myAudioSourceLow.PlayOneShot(errorSound);
        if (soPode)
        {
            System.Threading.Thread.Sleep((int)errorSound.length + 300);
            //myAudioSourceLow.PlayOneShot(soPodeCirc);
        }
    }


    public void ErrorVazioPublicF()
    {
        myAudioSourceLow.PlayOneShot(errorSound);
    }

    public void ErrorVazioPublicM()
    {
        myAudioSourceLow.PlayOneShot(errorSound);
    }
}
