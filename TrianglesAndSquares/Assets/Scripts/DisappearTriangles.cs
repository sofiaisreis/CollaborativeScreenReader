using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ClassDemo.CountObjects;
using static ClassDemo.Audios;

namespace ClassDemo { 
    public class DisappearTriangles : MonoBehaviour
    {
        public AudioClip triangulo;
        public AudioClip selected;
        public AudioSource myAudioSource;


        void Start()
        {
            myAudioSource = GetComponent<AudioSource>();
            //GameObject[] max_triangles = GameObject.FindGameObjectsWithTag("triangle");

        }

        private void Update()
        {
        }

        public void OnMouseEnter()
        {
            //print("Mouse is over one Triangle."); //On table exists " + max_triangles.Length);
            gameObject.GetComponent<Renderer>().material.color = new Color(255, 0, 0);
            // Read name of object
            myAudioSource.PlayOneShot(triangulo);  
        }

        public void OnMouseExit()
        {
            gameObject.GetComponent<Renderer>().material.color = new Color(1,1,1);
            
        }

        public void OnMouseDown()
        {
            //Read how many
            myAudioSource.PlayOneShot(selected);
            myAudioSource.PlayOneShot(triangulo);

            //Increment
            if (CountObjects.GetTriAtual() > 0)
            {
                print("Selected " + CountObjects.IncrementTriangles() + " triangles a total of " + CountObjects.GetTriInit());
            }
            else if (CountObjects.GetTriAtual() == 0)
            {
                print("Selected " + CountObjects.IncrementTriangles() + " triangle a total of " + CountObjects.GetTriInit());
            }

            //hide
            //if(!myAudioSource.isPlaying)
                gameObject.SetActive(false);
            //Destroy(this.gameObject);
        }
    }
}