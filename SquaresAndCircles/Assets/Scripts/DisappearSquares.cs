using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ClassDemo.CountObjects;
using static ClassDemo.SoundManager;

namespace ClassDemo {
    public class DisappearSquares : MonoBehaviour
    {
        public AudioClip quadrado;
        public AudioClip selected;
        public AudioSource myAudioSource;
        
        void Start()
        {
            myAudioSource = GetComponent<AudioSource>();
            //GameObject[] max_squares = GameObject.FindGameObjectsWithTag("square");
        }

        private void Update()
        {
        }

        public void OnMouseEnter()
        {
            //print("Mouse is over one Square."); //On table exists " + max_squares.Length);
            gameObject.GetComponent<Renderer>().material.color = new Color(255, 0, 0);
            // Read name of object
            myAudioSource.PlayOneShot(quadrado);
        }

        public void OnMouseExit()
        {
            gameObject.GetComponent<Renderer>().material.color = new Color(1, 1, 1);

        }

        public void OnMouseDown()
        {
            //Read how many
            myAudioSource.PlayOneShot(selected);

            //Increment
            if (CountObjects.GetSquaAtual() > 0)
            {
                print("Selected " + CountObjects.IncrementSquares() + " squares of total of " + CountObjects.GetSquaInit());
            }
            else if (CountObjects.GetSquaAtual() == 0)
            {
                print("Selected " + CountObjects.IncrementSquares() + " square of total of " + CountObjects.GetSquaInit());
            }
            //hide
            gameObject.SetActive(false);
            //Destroy(this.gameObject);
        }

    }
}