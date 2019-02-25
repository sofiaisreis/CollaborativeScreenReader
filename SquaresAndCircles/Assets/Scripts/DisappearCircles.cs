using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ClassDemo.CountObjects;
using static ClassDemo.SoundManager;

namespace ClassDemo { 
    public class DisappearCircles : MonoBehaviour
    {
        public AudioClip circle; //tenho que por TO DO
        public AudioClip selected;
        public AudioSource myAudioSource;


        void Start()
        {
            myAudioSource = GetComponent<AudioSource>();
            //GameObject[] max_circles = GameObject.FindGameObjectsWithTag("circle");

        }

        private void Update()
        {
        }

        public void OnMouseEnter()
        {
            //print("Mouse is over one Circle."); //On table exists " + max_circles.Length);
            gameObject.GetComponent<Renderer>().material.color = new Color(255, 0, 0);
            // Read name of object
            myAudioSource.PlayOneShot(circle);  
        }

        public void OnMouseExit()
        {
            gameObject.GetComponent<Renderer>().material.color = new Color(1,1,1);
            
        }

        public void OnMouseDown()
        {
            //Read how many
            myAudioSource.PlayOneShot(selected);
            myAudioSource.PlayOneShot(circle);

            //Increment
            if (CountObjects.GetCircAtual() > 0)
            {
                print("Selected " + CountObjects.IncrementCircles() + " circles a total of " + CountObjects.GetCircInit());
            }
            else if (CountObjects.GetCircAtual() == 0)
            {
                print("Selected " + CountObjects.IncrementCircles() + " circle a total of " + CountObjects.GetCircInit());
            }

            //hide
            //if(!myAudioSource.isPlaying)
                gameObject.SetActive(false);
            //Destroy(this.gameObject);
        }
    }
}