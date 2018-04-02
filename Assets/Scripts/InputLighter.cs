using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace HoloToolkit.Unity.InputModule.Tests
{
    public class InputLighter : MonoBehaviour, IInputClickHandler
    {
 
        // Ecrivez dans start votre initialisation
        void Start()
        {
            string v = "briquet";
            PlayerPrefs.SetInt(v, 0);
        }

        //ici le code à executer quand on interagit avec l'objet
        public void OnInputClicked(InputClickedEventData eventData)
        {
            gameObject.SetActive(false);
            string v = "briquet";
            PlayerPrefs.SetInt(v, 1);
        }

    }
}
