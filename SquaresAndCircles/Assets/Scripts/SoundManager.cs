using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClassDemo
{
    public class SoundManager : MonoBehaviour {

        AudioClip one, two, three, four, five;
        AudioSource myAudioSource;
        public AudioClip quadrado;
        public AudioClip circle;
        public AudioClip selected;

        void Start()
        {
            myAudioSource = GetComponent<AudioSource>();
        }

        void OnCollisionEnter(Collision collision)
        {/*
            foreach (ContactPoint contact in collision.contacts)
            {
                Debug.DrawRay(contact.point, contact.normal, Color.white);
            }
            if (collision.relativeVelocity.magnitude > 2)
                myAudioSource.Play();
        */}



    }

}