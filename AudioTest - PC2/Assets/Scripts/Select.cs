using UnityEngine;
using System.Collections;

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
                     tcF, tcM,
                     tqF, tqM,
                     ttF, ttM,
                     selected,
                     errorSound,
                     soPodeQuad,
                     soPodeCirc;
    public bool ttfe = false;
    public bool ttma = false;
    /* Object:
     * quad = 1
     * circ = 2 */

    public void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }

    public void ErrorF(bool soPode)
    {
        myAudioSource.PlayOneShot(errorSound);
        if (soPode)
        {
            System.Threading.Thread.Sleep((int)errorSound.length + 300);
            if (soPode) myAudioSource.PlayOneShot(soPodeQuad);
        }
    }

    public void ErrorPublic()
    {
        myAudioSource.PlayOneShot(errorSound);
    }

    public void ErrorM(bool soPode)
    {
        myAudioSource.PlayOneShot(errorSound);
        if (soPode)
        {
            System.Threading.Thread.Sleep((int)errorSound.length + 300);
            if (soPode) myAudioSource.PlayOneShot(soPodeCirc);
        }

    }

    public void SelectionF(int lastObj, int selecao, int totais)
    {
        myAudioSource.PlayOneShot(selected);
        print("Secs: " + (int)selected.length);
        System.Threading.Thread.Sleep((int)selected.length + 300);
        print("lastObj: " + lastObj + "selecao: " + selecao + "totais: " + totais);
        print("SELECT_entrou");
        switch (lastObj)
        {
            case 1: //quadrado
                if (selecao < totais)
                {
                    int selecf = totais - selecao;
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
                }
                else if (selecao == totais)
                {
                    myAudioSource.PlayOneShot(tqF);
                    ttfe = true;
                    System.Threading.Thread.Sleep(2000);
                    if (ttfe && ttma)
                    {
                        myAudioSource.PlayOneShot(ttF);
                    }
                }
                else
                {
                    print("Something is wrong!");
                }
                break;

            //Acontece em God Mode
            case 2: //circulo
                if (selecao < totais)
                {
                    int selecf = totais - selecao;
                    if (selecf == 1)
                    {
                        myAudioSource.PlayOneShot(f1cM);
                    }
                    else if (selecf == 2)
                    {
                        myAudioSource.PlayOneShot(f2cM);
                    }
                    else if (selecf == 3)
                    {
                        myAudioSource.PlayOneShot(f3cM);
                    }
                    else if (selecf == 4)
                    {
                        myAudioSource.PlayOneShot(f4cM);
                    }
                    else if (selecf == 5)
                    {
                        myAudioSource.PlayOneShot(f5cM);
                    }
                }
                else if (selecao == totais)
                {
                    myAudioSource.PlayOneShot(tcM);
                    ttma = true;
                    ttfe = true;
                    System.Threading.Thread.Sleep(2000);
                    if (ttfe && ttma)
                    {
                        myAudioSource.PlayOneShot(ttM);
                    }
                }

                else
                {
                    print("Something is wrong!");
                }
                break;
        }        
    }

    public void SelectionM(int lastObj, int selecao, int totais)
    {
        myAudioSource.PlayOneShot(selected);
        print("Secs: " + (int)selected.length);
        System.Threading.Thread.Sleep((int)selected.length + 300);

        switch (lastObj)
        {
            //Acontece em God Mode
            case 1: //quadrado
                if (selecao < totais)
                {
                    int selecm = totais - selecao;
                    if (selecm == 1)
                    {
                        myAudioSource.PlayOneShot(f1qF);
                    }
                    else if (selecm == 2)
                    {
                        myAudioSource.PlayOneShot(f2qF);
                    }
                    else if (selecm == 3)
                    {
                        myAudioSource.PlayOneShot(f3qF);
                    }
                    else if (selecm == 4)
                    {
                        myAudioSource.PlayOneShot(f4qF);
                    }
                    else if (selecm == 5)
                    {
                        myAudioSource.PlayOneShot(f5qF);
                    }
                }
                else if (selecao == totais)
                {
                    myAudioSource.PlayOneShot(tqF);
                    ttfe = true;
                    System.Threading.Thread.Sleep(2000);
                    if (ttfe && ttma)
                    {
                        myAudioSource.PlayOneShot(ttF);
                    }
                }
                else
                {
                    print("Something is wrong!");
                }
                break;

            case 2: //circulo
                if (selecao < totais)
                {
                    int selecm = totais - selecao;
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
                }
                else if (selecao == totais)
                {
                    myAudioSource.PlayOneShot(tcM);
                    ttma = true;
                    System.Threading.Thread.Sleep(2000);
                    if (ttfe && ttma)
                    {
                        myAudioSource.PlayOneShot(ttM);
                    }
                }
                else
                {
                    print("Something is wrong!");
                }
                break;
        }
    }
}
