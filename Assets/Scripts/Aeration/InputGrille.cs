using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace HoloToolkit.Unity.InputModule.Tests
{
    public class InputGrille : MonoBehaviour, IInputClickHandler
    {
        private Rigidbody gameObjectsRigidBody;
        private bool done;
        private string[] m_AnimNames;
        // Ecrivez dans start votre initialisation
        void Start()
        {
            //On créer un rigidbody pour soumettre l'objet à la gravité mais on le met kinematic pour qu'il ne déplacement seulement par des transform.position
            gameObjectsRigidBody = this.gameObject.AddComponent<Rigidbody>();
            gameObjectsRigidBody.mass = 5;
            gameObjectsRigidBody.isKinematic = true;
            done = false;

        }

        //ici le code à executer quand on interagit avec l'objet
        public void OnInputClicked(InputClickedEventData eventData)
        {
            int vis = PlayerPrefs.GetInt("valeurVis");

            Debug.Log("Interactive object");

            if (!GetComponent<Animation>().IsPlaying("GridFalling") && !done && vis <=0)
            {
                Debug.Log("Interactive object");
                GetComponent<Animation>().Play("GridFalling");
                done = true;
                gameObjectsRigidBody.isKinematic = false;
                int avancement = 3;
                PlayerPrefs.SetInt("avancementEnigme", avancement);
                eventData.Use();

            }
        }

    }
}
