using UnityEngine;


[RequireComponent(typeof(AudioSource))]

public class ColliderObj : MonoBehaviour
{
   
    public AudioSource myAudioSource;   //Drag a reference to the audio source which will play the music.
    public AudioClip quadrado, circulo, selectedM, exitObjM;
    //public float lowPitchRange = .95f;              //The lowest a sound effect will be randomly pitched.
    //public float highPitchRange = 1.05f;            //The highest a sound effect will be randomly pitched.
    public static Renderer rend;
    public bool tapToProcess = false;
    public bool isBeingDragged = false;
    public GameObject collidingObject = null;

    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
        myAudioSource.playOnAwake = false;
        rend = GetComponent<Renderer>();
    }

    void OnCollisionEnter(Collision collisionInfo) {

        var objTag = collisionInfo.gameObject.tag;
        var nameObject = collisionInfo.collider.name;
        //Debug.Log("We hit a " + objTag + " named " + collisionInfo.collider.name);
        //Debug.Log(collisionInfo.collider.name); //Name of the Object On which we Collided or .tag

        if (!tapToProcess) { 
            if (objTag == "square")
            {
                myAudioSource.PlayOneShot(quadrado);
                rend.material.color = new Color(0, 0, 255);
            }
            else if (objTag == "circle")
            {
                myAudioSource.PlayOneShot(circulo);
                rend.material.color = new Color(0, 255, 0);
            }
        }
        GameManager.HandleObjectEnter(objTag);
    }

    void OnCollisionStay(Collision collisionInfo) {
        var objTag = collisionInfo.gameObject.tag;

        collidingObject = collisionInfo.gameObject;

        //GameObject soundManager = GameObject.FindGameObjectsWithTag("soundmanager")[0];

        //print("Estou no: " + collisionInfo.collider.tag);
        GameManager.HandleObjectStay(objTag);

        if (tapToProcess)
        {
            if (objTag == "square")
            {
                myAudioSource.PlayOneShot(quadrado);
                rend.material.color = new Color(0, 0, 255);
            }
            else if (objTag == "circle")
            {
                myAudioSource.PlayOneShot(circulo);
                rend.material.color = new Color(0, 255, 0);
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
        
        GameManager.HandleObjectExit(objTag);

        collidingObject = null;
    }

    public void SelectObject()
    {
        myAudioSource.PlayOneShot(selectedM);
        Destroy(collidingObject);
        collidingObject = null;
    }
}


