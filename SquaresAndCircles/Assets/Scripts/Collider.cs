using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClassDemo
{
    public class Collider : MonoBehaviour
    {
        Rigidbody rb;
        private bool enterSquare = false;
        private bool enterCircle = false;
        private bool exitObject = false;

        void Start()
        {
            Rigidbody rb = GetComponent<Rigidbody>();
        }

        private void Update()
        {

        }

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

        private void OnCollisionEnter(Collision collision) {
            var objTag = collision.gameObject.tag;

            print(objTag);

            GameManager.HandleObjectEnter(objTag);
        }

        private void OnCollisionStay(Collision other) { }

        private void OnCollisionExit(Collision other) { }

    }

}