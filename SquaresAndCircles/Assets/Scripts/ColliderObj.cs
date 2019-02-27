using UnityEngine;

namespace ClassDemo
{
    public class ColliderObj : MonoBehaviour
    {
        private bool enterSquare = false;
        private bool enterCircle = false;
        private bool exitObject = false;

        public void OnSquare()
        {
            enterSquare = true;
        }

        public void OnCircle()
        {
            enterCircle = true;
        }

        public void OnExit()
        {
            exitObject = true;
            enterSquare = false;
            enterCircle = false;
        }

        void OnCollisionEnter(Collision collisionInfo) {
            var objTag = collisionInfo.gameObject.tag;
            //var objTag = collisionInfo.collider.tag;

          
            Debug.Log("We hit a " + objTag + " named " + collisionInfo.collider.name);
            //Debug.Log(collisionInfo.collider.name); //Name of the Object On which we Collided
            //or .tag
            GameManager.HandleObjectEnter(objTag);
        }

        void OnCollisionStay(Collision collisionInfo) {

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

            //print("I never collide EXIT!");
            //Debug.Log("I never collide EXIT");
        }

    }

}