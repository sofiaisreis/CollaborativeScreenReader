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
                     aoSeuParceiroF, aoSeuParceiroM,
                     todosCirculosF, todosCirculosM,
                     todosQuadradosF, todosQuadradosM,
                     tarefaterminadaF, tarefaterminadaM,
                     tarefaterminadaAmobs,
                     selected,
                     errorSound,
                     soPodeQuad,
                     soPodeCirc;

    internal void TocaOFinal()
    {
        throw new NotImplementedException();
    }

    public bool TarefaQuadradosFemale = false;
    public bool TarefaCirculosMale = false;
    public bool TarefaChegouAoFim = false;
    public int faltamTotalF = -1;
    public int faltamTotalM = -1;
    public GameObject somEntrada;
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

    public void SelectionF(int lastObj, int selecaoQuad, int selecaoCirc, int totais)
    {
        myAudioSource.PlayOneShot(selected);
        System.Threading.Thread.Sleep((int)selected.length + 300);
        faltamTotalF = totais - selecaoQuad;
        faltamTotalM = totais - selecaoCirc;


        switch (lastObj)
        {
            case 1: //quadrado
                if (selecaoQuad <= totais)
                {
                    if (faltamTotalF == 1)
                    {
                        myAudioSource.PlayOneShot(f1qF);
                    }
                    else if (faltamTotalF == 2)
                    {
                        myAudioSource.PlayOneShot(f2qF);
                    }
                    else if (faltamTotalF == 3)
                    {
                        myAudioSource.PlayOneShot(f3qF);
                    }
                    else if (faltamTotalF == 4)
                    {
                        myAudioSource.PlayOneShot(f4qF);
                    }
                    else if (faltamTotalF == 5)
                    {
                        myAudioSource.PlayOneShot(f5qF);
                    }
                    else if (faltamTotalF == 0 || somEntrada.GetComponent<Sounds>().faltamXQuad == 0)
                    {
                        myAudioSource.PlayOneShot(todosQuadradosF);
                        TarefaQuadradosFemale = true;

                        if (TarefaCirculosMale || somEntrada.GetComponent<Sounds>().faltamXCirc == 0)
                        {
                            TocaTodos();
                        }
                        
                        // feedback ao outro
                        System.Threading.Thread.Sleep((int)todosQuadradosF.length + 2000);
                        if(faltamTotalM == 1)
                        {
                            myAudioSource.PlayOneShot(f1cF);
                            System.Threading.Thread.Sleep((int)todosQuadradosF.length + 1500);
                            myAudioSource.PlayOneShot(aoSeuParceiroF);
                        }
                        else if(faltamTotalM == 2)
                        {
                            myAudioSource.PlayOneShot(f2cF);
                            System.Threading.Thread.Sleep((int)f2cF.length + 1500);
                            myAudioSource.PlayOneShot(aoSeuParceiroF);
                        }
                        else if(faltamTotalM == 3)
                        {
                            myAudioSource.PlayOneShot(f3cF);
                            System.Threading.Thread.Sleep((int)f3cF.length + 1500);
                            myAudioSource.PlayOneShot(aoSeuParceiroF);
                        }
                        else if(faltamTotalM == 4)
                        {
                            myAudioSource.PlayOneShot(f4cF);
                            System.Threading.Thread.Sleep((int)f4cF.length + 1500);
                            myAudioSource.PlayOneShot(aoSeuParceiroF);
                        }
                        else if(faltamTotalM == 5)
                        {
                            myAudioSource.PlayOneShot(f5cF);
                            System.Threading.Thread.Sleep((int)todosQuadradosF.length + 1500);
                            myAudioSource.PlayOneShot(aoSeuParceiroF);
                        }
                    }
                }
                break;
        }
    }

    public void SelectionM(int lastObj, int selecaoQuad, int selecaoCirc, int totais)
    {
        myAudioSource.PlayOneShot(selected);
        System.Threading.Thread.Sleep((int)selected.length + 300);
        faltamTotalF = totais - selecaoQuad;
        faltamTotalM = totais - selecaoCirc;

        switch (lastObj)
        {
            case 2: //circulo
                if (selecaoCirc <= totais)
                {
                    if (faltamTotalM == 1)
                    {
                        myAudioSource.PlayOneShot(f1cM);
                    }
                    else if (faltamTotalM == 2)
                    {
                        myAudioSource.PlayOneShot(f2cM);
                    }
                    else if (faltamTotalM == 3)
                    {
                        myAudioSource.PlayOneShot(f3cM);
                    }
                    else if (faltamTotalM == 4)
                    {
                        myAudioSource.PlayOneShot(f4cM);
                    }
                    else if (faltamTotalM == 5)
                    {
                        myAudioSource.PlayOneShot(f5cM);
                    }
                    else if (faltamTotalM == 0 || somEntrada.GetComponent<Sounds>().faltamXCirc == 0)
                    {

                        myAudioSource.PlayOneShot(todosCirculosM);
                        TarefaCirculosMale = true;
                        
                        if (TarefaQuadradosFemale || somEntrada.GetComponent<Sounds>().faltamXQuad == 0) {
                            TocaTodos();
                        }

                        //feedback ao outro
                        System.Threading.Thread.Sleep((int)todosCirculosM.length + 2000);
                        if (faltamTotalF == 1)
                        {
                            myAudioSource.PlayOneShot(f1qM);
                            System.Threading.Thread.Sleep((int)f1qM.length + 1500);
                            myAudioSource.PlayOneShot(aoSeuParceiroM);
                        }
                        else if (faltamTotalF == 2)
                        {
                            myAudioSource.PlayOneShot(f2qM);
                            System.Threading.Thread.Sleep((int)f2qM.length + 1500);
                            myAudioSource.PlayOneShot(aoSeuParceiroM);
                        }
                        else if (faltamTotalF == 3)
                        {
                            myAudioSource.PlayOneShot(f3qM);
                            System.Threading.Thread.Sleep((int)f3qM.length + 1500);
                            myAudioSource.PlayOneShot(aoSeuParceiroM);
                        }
                        else if (faltamTotalF == 4)
                        {
                            myAudioSource.PlayOneShot(f4qM);
                            System.Threading.Thread.Sleep((int)f4qM.length + 1500);
                            myAudioSource.PlayOneShot(aoSeuParceiroM);
                        }
                        else if (faltamTotalF == 5)
                        {
                            myAudioSource.PlayOneShot(f5qM);
                            System.Threading.Thread.Sleep((int)f5qM.length + 1500);
                            myAudioSource.PlayOneShot(aoSeuParceiroM);
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
        faltamTotalF = totais - selecaoQuad;
        faltamTotalM = totais - selecaoCirc;

        switch (lastObj)
        {
            case 1: //quadrado
                if (selecaoQuad <= totais)
                {
                    if (faltamTotalF == 1)
                    {
                        myAudioSource.PlayOneShot(f1qF);
                    }
                    else if (faltamTotalF == 2)
                    {
                        myAudioSource.PlayOneShot(f2qF);
                    }
                    else if (faltamTotalF == 3)
                    {
                        myAudioSource.PlayOneShot(f3qF);
                    }
                    else if (faltamTotalF == 4)
                    {
                        myAudioSource.PlayOneShot(f4qF);
                    }
                    else if (faltamTotalF == 5)
                    {
                        myAudioSource.PlayOneShot(f5qF);
                    }
                    else if (faltamTotalF == 0 || somEntrada.GetComponent<Sounds>().faltamXQuad == 0)
                    {
                        myAudioSource.PlayOneShot(todosQuadradosF);
                        TarefaQuadradosFemale = true;
                        if (TarefaCirculosMale || somEntrada.GetComponent<Sounds>().faltamXCirc == 0)
                        {
                            TocaTodos();
                        }
                    }
                }
                break;
            case 2: //circulo
                if (selecaoCirc <= totais)
                {
                    if (faltamTotalM == 1)
                    {
                        myAudioSource.PlayOneShot(f1cM);
                    }
                    else if (faltamTotalM == 2)
                    {
                        myAudioSource.PlayOneShot(f2cM);
                    }
                    else if (faltamTotalM == 3)
                    {
                        myAudioSource.PlayOneShot(f3cM);
                    }
                    else if (faltamTotalM == 4)
                    {
                        myAudioSource.PlayOneShot(f4cM);
                    }
                    else if (faltamTotalM == 5)
                    {
                        myAudioSource.PlayOneShot(f5cM);
                    }
                    else if (faltamTotalM == 0 || somEntrada.GetComponent<Sounds>().faltamXCirc == 0)
                    {
                        myAudioSource.PlayOneShot(todosCirculosM);
                        TarefaCirculosMale = true;
                        if (TarefaQuadradosFemale || somEntrada.GetComponent<Sounds>().faltamXQuad == 0)
                        {
                            TocaTodos();
                        }
                    }
                }
                break;
        }
    }

    public void TocaTodos()
    {
        System.Threading.Thread.Sleep(2000);
        myAudioSource.PlayOneShot(tarefaterminadaAmobs);
    }

}
