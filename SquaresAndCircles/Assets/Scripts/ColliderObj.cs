using UnityEngine;


[RequireComponent(typeof(AudioSource))]

public class ColliderObj : MonoBehaviour
{
   
    public AudioSource myAudioSource;   //Drag a reference to the audio source which will play the music.
    public AudioClip quadrado, circulo, selectedM, exitObjM;
    //public float lowPitchRange = .95f;              //The lowest a sound effect will be randomly pitched.
    //public float highPitchRange = 1.05f;            //The highest a sound effect will be randomly pitched.
    public bool tapToProcess = false;
    public bool isBeingDragged = false;
    public GameObject collidingObject = null;

    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
        myAudioSource.playOnAwake = false;
    }

    void OnCollisionEnter(Collision collisionInfo) {

        var objTag = collisionInfo.gameObject.tag;
        var nameObject = collisionInfo.collider.name;

        if (!tapToProcess) { 
            if (objTag == "square")
            {
                myAudioSource.PlayOneShot(quadrado);
            }
            else if (objTag == "circle")
            {
                myAudioSource.PlayOneShot(circulo);
            }
        }
    }

    void OnCollisionStay(Collision collisionInfo)
    {
        var objTag = collisionInfo.gameObject.tag;
        collidingObject = collisionInfo.gameObject;

        if (tapToProcess)
        {
            if (objTag == "square")
            {
                myAudioSource.PlayOneShot(quadrado);
            }
            else if (objTag == "circle")
            {
                myAudioSource.PlayOneShot(circulo);
            }
            tapToProcess = false;
        }
    }

    void OnCollisionExit(Collision collisionInfo) {

        var objTag = collisionInfo.gameObject.tag;
        myAudioSource.Stop();

        if (isBeingDragged) {
            myAudioSource.PlayOneShot(exitObjM);
        }

        collidingObject = null;
    }

    public void SelectObject()
    {
        myAudioSource.PlayOneShot(selectedM);
        Destroy(collidingObject);
        collidingObject = null;
    }
}


