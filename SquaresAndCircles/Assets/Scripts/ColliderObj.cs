using UnityEngine;

namespace ClassDemo
{
    public class ColliderObj : MonoBehaviour
    {
        private bool enterSquare = false;
        private bool enterCircle = false;
        private bool exitObject = false;
        public static AudioClip quad;
        public AudioSource myAudioSource;

        void OnCollisionEnter(Collision collisionInfo) {

            myAudioSource = GetComponent<AudioSource>();
            var objTag = collisionInfo.gameObject.tag;
            var nameObject = collisionInfo.collider.name;
            Debug.Log("We hit a " + objTag + " named " + collisionInfo.collider.name);
            //Debug.Log(collisionInfo.collider.name); //Name of the Object On which we Collided or .tag
          
            GameManager.HandleObjectEnter(objTag);
        }

        void OnCollisionStay(Collision collisionInfo) {
            var objTag = collisionInfo.gameObject.tag;


            if (objTag == "square")
            {
                SoundManager.PlaySquare();
                Debug.Log("onCollisionStay SQUARE");
                enterSquare = true;
            }
            if (objTag == "circle")
            {
                SoundManager.PlayCircle2();
                Debug.Log("onCollisionStay CIRCLE");
                enterCircle = true;
            }

            GameManager.HandleObjectStay(objTag, enterSquare, enterCircle);
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

            exitObject = true;
            enterSquare = false;
            enterCircle = false;
            Debug.Log("We EXIT " + collisionInfo.collider.name);

            SoundManager.StopSounds();
            GameManager.HandleObjectExit(objTag, exitObject);
        }
    //print("I never collide EXIT!");
    //Debug.Log("I never collide EXIT");
    }

}

