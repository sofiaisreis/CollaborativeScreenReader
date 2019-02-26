using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
           // gameObject.GetComponent<Renderer>().material.color = new Color(255, 0, 0);
            // Read name of object
            //myAudioSource.PlayOneShot(quadrado);
        }
        /*
        public void OnMouseExit()
        {
            gameObject.GetComponent<Renderer>().material.color = new Color(1, 1, 1);

        }
        
        public void OnMouseDown()
        {
            //Read how many
            myAudioSource.PlayOneShot(selected);

            //Increment
            if (GameManager.GetSquaAtual() > 0)
            {
                print("Selected " + GameManager.IncrementSquares() + " squares of total of " + GameManager.GetSquaInit());
            }
            else if (GameManager.GetSquaAtual() == 0)
            {
                print("Selected " + GameManager.IncrementSquares() + " square of total of " + GameManager.GetSquaInit());
            }
            //hide
            gameObject.SetActive(false);
            //Destroy(this.gameObject);
        }
        */

        //COLIDERS
    }
}