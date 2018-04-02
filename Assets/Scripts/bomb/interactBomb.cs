using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace HoloToolkit.Unity.InputModule.Tests
{
    public class interactBomb : MonoBehaviour, IInputClickHandler
    {
        
        bool done;
        public AudioSource bombopened;
        // Use this for initialization
        void Start()
        {
            Debug.Log("je suis dans start");
            done = false;
            
        }
        private string[] m_AnimNames;
        public void OnInputClicked(InputClickedEventData eventData)
        {
            Debug.Log("touché");
            //si aucune animation n'est en execution
            if (!GetComponent<Animation>().IsPlaying("openBombe") && PlayerPrefs.GetInt("bombUnlocked")==1 && !done)
                {
                    Debug.Log("Interactive object");
                bombopened.Play();
                GetComponent<Animation>().Play("openBombe");
                done = true;

                        eventData.Use();
                    
                }
 
            

        }
    }
}