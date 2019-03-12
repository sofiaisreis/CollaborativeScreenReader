using UnityEngine;

namespace ClassDemo
{
    [RequireComponent(typeof(AudioSource))]

    public class ColliderObj : MonoBehaviour
    {
        /* private bool enterSquare = false;
         private bool enterCircle = false;
         private bool exitObject = false;
        */
        public AudioSource myAudioSource;   //Drag a reference to the audio source which will play the music.
        public AudioClip quadrado, circulo, selectedM, exitObjM;
        //public float lowPitchRange = .95f;              //The lowest a sound effect will be randomly pitched.
        //public float highPitchRange = 1.05f;            //The highest a sound effect will be randomly pitched.
        public static Renderer rend;

        void Start()
        {
            myAudioSource = GetComponent<AudioSource>();
            myAudioSource.playOnAwake = false;
            rend = GetComponent<Renderer>();
        }

        void OnCollisionEnter(Collision collisionInfo) {
            
            var objTag = collisionInfo.gameObject.tag;
            var nameObject = collisionInfo.collider.name;
            Debug.Log("We hit a " + objTag + " named " + collisionInfo.collider.name);
            //Debug.Log(collisionInfo.collider.name); //Name of the Object On which we Collided or .tag

            if (objTag == "square")
            {
                //myAudioSource.clip = quadrado;
                myAudioSource.PlayOneShot(quadrado);
                Debug.Log("REPRODUZI SOM QUADRADO");
                rend.material.color = new Color(0, 0, 255);
                Debug.Log("onCollisionEnter SQUARE");
                //enterSquare = true;
            }
            else if (objTag == "circle")
            {
                //myAudioSource.clip = circulo;
                myAudioSource.PlayOneShot(circulo);
                Debug.Log("TocaSOM");
                rend.material.color = new Color(0, 255, 0);
                Debug.Log("onCollisionEnter CIRCLE");
                //enterCircle = true;
            }

            GameManager.HandleObjectEnter(objTag);
        }

        void OnCollisionStay(Collision collisionInfo) {
            var objTag = collisionInfo.gameObject.tag;

            //GameObject soundManager = GameObject.FindGameObjectsWithTag("soundmanager")[0];

           

            GameManager.HandleObjectStay(objTag);
            /* print("I never collide STAY!");
            Debug.Log("I never collide STAY");
           
                //Se estiver em cima a colidir com o X, podemos apagar/destruir o mesmo
                if (collisionInfo.gameObject.tag == "square")
                {
                    gameObject.SetActive(false);
                    Destroy(collisionInfo.gameObject);
                }

                else if (collisionInfo.gameObject.tag == "circle")
                {
                    gameObject.SetActive(false);
                }
              */
        }

        void OnCollisionExit(Collision collisionInfo) {

            var objTag = collisionInfo.gameObject.tag;

            /*exitObject = true;
            enterSquare = false;
            enterCircle = false;

            */
            myAudioSource.Pause();
            Debug.Log("Parou, parou, PaROU!");
            Debug.Log("We EXIT " + collisionInfo.collider.name);

            //SoundManager.StopSounds();
            GameManager.HandleObjectExit(objTag);
        }
    //print("I never collide EXIT!");
    //Debug.Log("I never collide EXIT");
    }

}

