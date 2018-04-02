using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoloToolkit.Unity.InputModule.Tests
{
    public class InputVis : MonoBehaviour, IInputClickHandler
    {
        private string[] m_AnimNames;
        private bool lonely;
        private Rigidbody gameObjectsRigidBody;
        private bool done;
        public AudioSource vissound;
        // Use this for initialization
        void Start()
        {
            gameObjectsRigidBody = this.gameObject.AddComponent<Rigidbody>();
            gameObjectsRigidBody.mass = 5;
            gameObjectsRigidBody.isKinematic = true;
            done = false;
            int vis = 4;
            PlayerPrefs.SetInt("valeurVis", vis);

            int avancement = 1;
            PlayerPrefs.SetInt("avancementEnigme", avancement);
            PlayerPrefs.SetInt("valeurTourneVis", 0);
            /*
            int vis = PlayerPrefs.GetInt("valeurVis");
            vis--;
            PlayerPrefs.SetInt("valeurVis");*/
            m_AnimNames = new string[GetComponent<Animation>().GetClipCount()];
            int index = 0;
            foreach (AnimationState anim in GetComponent<Animation>())
            {
                m_AnimNames[index] = anim.name;
                index++;
            }
            done = false;

        }


        //ici le code à executer quand on interagit avec l'objet
        public void OnInputClicked(InputClickedEventData eventData)
        {
            if (PlayerPrefs.GetInt("valeurTourneVis") == 1)
            {
                //si aucune animation n'est en execution
                if (!GetComponent<Animation>().isPlaying)
                {
                    Debug.Log("Interactive object");
                    if (!done)
                    {
                        done = true;
                        GetComponent<Animation>().Play(m_AnimNames[0]);
                        vissound.Play();
                        int vis = PlayerPrefs.GetInt("valeurVis");
                        vis--;
                        PlayerPrefs.SetInt("valeurVis", vis);
                        gameObjectsRigidBody.isKinematic = false;
                        eventData.Use();
                    }
                }
            }

        }
    }
}
