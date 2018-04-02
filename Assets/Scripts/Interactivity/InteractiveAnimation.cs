using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    namespace HoloToolkit.Unity.InputModule.Tests
{
    public class InteractiveAnimation : MonoBehaviour, IInputClickHandler
    {
        //Deux etats pour les animations
        public enum eInteractiveState
        {
            Active,     //Open 
            Inactive,   //Close
        }


        private eInteractiveState m_State;
        private string[] m_AnimNames;
        private bool lonely;
        private bool done;


        // Ecrivez dans start votre initialisation
        void Start() {
            m_State = eInteractiveState.Inactive;
            /*
            int children = transform.childCount;
            for (int i = 0; i < children; ++i) { 
                print("For loop: " + transform.GetChild(i));
            }
            */

            /*
                Rigidbody gameObjectsRigidBody = this.gameObject.AddComponent<Rigidbody>();  // Add the rigidbody.
                gameObjectsRigidBody.mass = 5;
                gameObjectsRigidBody.isKinematic = true;
                */

            m_AnimNames = new string[GetComponent<Animation>().GetClipCount()];
            int index = 0;
            foreach (AnimationState anim in GetComponent<Animation>())
            {
                m_AnimNames[index] = anim.name;
                index++;
            }
            if (index == 1)
            {
                lonely = true;
                done = false;
            }
            else
                lonely = false;
        }

        //ici le code à executer quand on interagit avec l'objet
        public void OnInputClicked(InputClickedEventData eventData)
        {
            //si aucune animation n'est en execution
            if (!GetComponent<Animation>().isPlaying)
            {
                Debug.Log("Interactive object");
                if (lonely)
                {
                    if (!done)
                    {
                        GetComponent<Animation>().Play(m_AnimNames[0]);
                        m_State = eInteractiveState.Active;
                        done = true;
                    }
                }
                else
                {
                    //on choisit quelle animation executer
                    switch (m_State)
                    {
                        case eInteractiveState.Active:
                            GetComponent<Animation>().Play(m_AnimNames[1]);
                            m_State = eInteractiveState.Inactive;
                            break;
                        case eInteractiveState.Inactive:
                            GetComponent<Animation>().Play(m_AnimNames[0]);
                            m_State = eInteractiveState.Active;
                            break;
                        default:
                            break;
                    }


                }
            }
            eventData.Use();
        }
    } }