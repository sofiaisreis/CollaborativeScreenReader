using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(AudioSource))]
public class Select : MonoBehaviour
{
    //select
    private AudioSource myAudioSource;
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
                     todosCirculosF, todosCirculosM,
                     todosQuadradosF, todosQuadradosM,
                     tarefaterminadaF, tarefaterminadaM,
                     tarefaterminadaAmobs,
                     selected,
                     errorSound,
                     soPodeQuad,
                     soPodeCirc;
    public bool TarefaQuadradosFemale = false;
    public bool TarefaCirculosMale = false;
    public bool TarefaChegouAoFim = false;
    public int selecf = -1;
    public int selecm = -1;
    public int selecTotalF = -1;
    public int selecTotalM = -1;
    /* Object:
     * quad = 1
     * circ = 2 */

    public void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }
    public void Update()
    {
    }

    public void ErrorF(bool soPode = true)
    {
        myAudioSource.PlayOneShot(errorSound);
        if (soPode)
        {
            System.Threading.Thread.Sleep((int)errorSound.length + 300);
            myAudioSource.PlayOneShot(soPodeQuad);
        }
    }
    public void ErrorM(bool soPode = true)
    {
        myAudioSource.PlayOneShot(errorSound);
        if (soPode)
        {
            System.Threading.Thread.Sleep((int)errorSound.length + 300);
            if (soPode) myAudioSource.PlayOneShot(soPodeCirc);
        }

    }

    public void ErrorFVazio()
    {
        myAudioSource.PlayOneShot(errorSound);
    }
    public void ErrorMVazio()
    {
        myAudioSource.PlayOneShot(errorSound);
    }

    public void SelectionF(int lastObj, int selecao, int totais)
    {
        myAudioSource.PlayOneShot(selected);
        System.Threading.Thread.Sleep((int)selected.length + 300);
        selecf = totais - selecao;

        switch (lastObj)
        {
            case 1: //quadrado
                if (selecao <= totais)
                {
                    if (selecf == 1)
                    {
                        myAudioSource.PlayOneShot(f1qF);
                    }
                    else if (selecf == 2)
                    {
                        myAudioSource.PlayOneShot(f2qF);
                    }
                    else if (selecf == 3)
                    {
                        myAudioSource.PlayOneShot(f3qF);
                    }
                    else if (selecf == 4)
                    {
                        myAudioSource.PlayOneShot(f4qF);
                    }
                    else if (selecf == 5)
                    {
                        myAudioSource.PlayOneShot(f5qF);
                    }
                    else if (selecf == 0)
                    {
                        myAudioSource.PlayOneShot(todosQuadradosF);
                        TarefaQuadradosFemale = true;
                        //TO DO feedback ao outro
                        if (TarefaCirculosMale)
                        {
                            System.Threading.Thread.Sleep(2000);
                            myAudioSource.PlayOneShot(tarefaterminadaAmobs);
                        }
                    }
                }
                break;
                /*
            //Acontece em God Mode
            case 2: //circulo
                if (selecao <= totais)
                {
                    if (selecm == 1)
                    {
                        myAudioSource.PlayOneShot(f1cM);
                    }
                    else if (selecm == 2)
                    {
                        myAudioSource.PlayOneShot(f2cM);
                    }
                    else if (selecm == 3)
                    {
                        myAudioSource.PlayOneShot(f3cM);
                    }
                    else if (selecm == 4)
                    {
                        myAudioSource.PlayOneShot(f4cM);
                    }
                    else if (selecm == 5)
                    {
                        myAudioSource.PlayOneShot(f5cM);
                    }
                    else if (selecm == 0)
                    {
                        myAudioSource.PlayOneShot(todosCirculosM);
                        TarefaCirculosMale = true;
                        if (TarefaQuadradosFemale)
                        {
                            System.Threading.Thread.Sleep(2000);
                            myAudioSource.PlayOneShot(tarefaterminadaAmobs);
                        }
                    }
                }
                break;*/
        }
    }

    public void SelectionM(int lastObj, int selecao, int totais)
    {
        myAudioSource.PlayOneShot(selected);
        System.Threading.Thread.Sleep((int)selected.length + 300);
        selecm = totais - selecao;
        switch (lastObj)
        {/*
            //Acontece em God Mode
            case 1: //quadrado
                if (selecao <= totais)
                {
                    if (selecf == 1)
                    {
                        myAudioSource.PlayOneShot(f1qF);
                    }
                    else if (selecf == 2)
                    {
                        myAudioSource.PlayOneShot(f2qF);
                    }
                    else if (selecf == 3)
                    {
                        myAudioSource.PlayOneShot(f3qF);
                    }
                    else if (selecf == 4)
                    {
                        myAudioSource.PlayOneShot(f4qF);
                    }
                    else if (selecf == 5)
                    {
                        myAudioSource.PlayOneShot(f5qF);
                    }
                    else if (selecf == 0)
                    {
                        myAudioSource.PlayOneShot(todosQuadradosF);
                        TarefaQuadradosFemale = true;
                        if (TarefaCirculosMale)
                        {
                            System.Threading.Thread.Sleep(2000);
                            myAudioSource.PlayOneShot(tarefaterminadaAmobs);
                        }
                    }
                }
                break;*/

            case 2: //circulo
                if (selecao <= totais)
                {
                    if (selecm == 1)
                    {
                        myAudioSource.PlayOneShot(f1cM);
                    }
                    else if (selecm == 2)
                    {
                        myAudioSource.PlayOneShot(f2cM);
                    }
                    else if (selecm == 3)
                    {
                        myAudioSource.PlayOneShot(f3cM);
                    }
                    else if (selecm == 4)
                    {
                        myAudioSource.PlayOneShot(f4cM);
                    }
                    else if (selecm == 5)
                    {
                        myAudioSource.PlayOneShot(f5cM);
                    }
                    else if (selecm == 0)
                    {

                        myAudioSource.PlayOneShot(todosCirculosM);
                        TarefaCirculosMale = true;
                        //TO DO feedback ao outro
                        if (TarefaQuadradosFemale) {
                            System.Threading.Thread.Sleep(2000);
                            myAudioSource.PlayOneShot(tarefaterminadaAmobs);
                        }
                    }
                }
                break;
        }
    }

    //TO DO , TO TEST
    public void SelectionGod(int lastObj, int selecaoQuad, int selecaoCirc, int totais)
    {
        myAudioSource.PlayOneShot(selected);
        System.Threading.Thread.Sleep((int)selected.length + 300);
        selecTotalF = totais - selecaoQuad;
        selecTotalM = totais - selecaoCirc;

        switch (lastObj)
        {
            case 1: //quadrado
                if (selecTotalF <= totais)
                {
                    if (selecTotalF == 1)
                    {
                        myAudioSource.PlayOneShot(f1qF);
                    }
                    else if (selecTotalF == 2)
                    {
                        myAudioSource.PlayOneShot(f2qF);
                    }
                    else if (selecTotalF == 3)
                    {
                        myAudioSource.PlayOneShot(f3qF);
                    }
                    else if (selecTotalF == 4)
                    {
                        myAudioSource.PlayOneShot(f4qF);
                    }
                    else if (selecTotalF == 5)
                    {
                        myAudioSource.PlayOneShot(f5qF);
                    }
                    else if (selecTotalF == 0)
                    {
                        myAudioSource.PlayOneShot(todosQuadradosF);
                        TarefaQuadradosFemale = true;
                        if (TarefaCirculosMale)
                        {
                            System.Threading.Thread.Sleep(2000);
                            myAudioSource.PlayOneShot(tarefaterminadaAmobs);
                        }
                    }
                }
                break;
            case 2: //circulo
                if (selecTotalM <= totais)
                {
                    if (selecTotalM == 1)
                    {
                        myAudioSource.PlayOneShot(f1cM);
                    }
                    else if (selecTotalM == 2)
                    {
                        myAudioSource.PlayOneShot(f2cM);
                    }
                    else if (selecTotalM == 3)
                    {
                        myAudioSource.PlayOneShot(f3cM);
                    }
                    else if (selecTotalM == 4)
                    {
                        myAudioSource.PlayOneShot(f4cM);
                    }
                    else if (selecTotalM == 5)
                    {
                        myAudioSource.PlayOneShot(f5cM);
                    }
                    else if (selecTotalM == 0)
                    {
                        myAudioSource.PlayOneShot(todosCirculosM);
                        TarefaCirculosMale = true;
                        if (TarefaQuadradosFemale)
                        {
                            System.Threading.Thread.Sleep(2000);
                            myAudioSource.PlayOneShot(tarefaterminadaAmobs);
                        }
                    }
                }
                break;
        }
    }
}
