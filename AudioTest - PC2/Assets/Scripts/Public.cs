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

    public void SelectedPublicF(int lastObj, int selecaoQuad, int selecaoCirc, int totais)
    {
        faltamTotalF = totais - selecaoQuad;
        faltamTotalM = totais - selecaoCirc;
        myAudioSourceLow.PlayOneShot(selected);
        System.Threading.Thread.Sleep((int)selected.length + 300);
        switch (lastObj)
        {
            case 1: //quadrado
                if (selecaoQuad <= totais)
                {
                    if (faltamTotalF == 1) myAudioSourceLow.PlayOneShot(f1qF);
                    else if (faltamTotalF == 2) myAudioSourceLow.PlayOneShot(f2qF);
                    else if (faltamTotalF == 3) myAudioSourceLow.PlayOneShot(f3qF);
                    else if (faltamTotalF == 4) myAudioSourceLow.PlayOneShot(f4qF);
                    else if (faltamTotalF == 5) myAudioSourceLow.PlayOneShot(f5qF);
                    else if (faltamTotalF == 0 || somEntrada.GetComponent<Sounds>().faltamXQuad == 0)
                    {
                        sele.GetComponent<Select>().TarefaQuadradosFemale = true;
                    }
                }
                break;
        }
    }

    public void SelectedPublicM(int lastObj,int selecaoQuad, int selecaoCirc, int totais)
    {
        faltamTotalF = totais - selecaoQuad;
        faltamTotalM = totais - selecaoCirc;
        myAudioSourceLow.PlayOneShot(selected);
        System.Threading.Thread.Sleep((int)selected.length + 300);

        switch (lastObj)
        {
            case 2: //circulo
                if (selecaoCirc <= totais)
                {
                    if (faltamTotalM == 1) myAudioSourceLow.PlayOneShot(f1cM);
                    else if (faltamTotalM == 2) myAudioSourceLow.PlayOneShot(f2cM);
                    else if (faltamTotalM == 3) myAudioSourceLow.PlayOneShot(f3cM);
                    else if (faltamTotalM == 4) myAudioSourceLow.PlayOneShot(f4cM);
                    else if (faltamTotalM == 5) myAudioSourceLow.PlayOneShot(f5cM);
                    else if (faltamTotalM == 0 || somEntrada.GetComponent<Sounds>().faltamXCirc == 0)
                    {
                        sele.GetComponent<Select>().TarefaCirculosMale = true;
                    }
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
