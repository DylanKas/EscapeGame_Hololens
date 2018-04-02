using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace HoloToolkit.Unity.InputModule.Tests
{
    public class HammerScript : MonoBehaviour, IInputClickHandler
    {

        // Ecrivez dans start votre initialisation
        void Start()
        {
            string v = "breakGlass";
            PlayerPrefs.SetInt(v, 0);
        }

        //ici le code à executer quand on interagit avec l'objet
        public void OnInputClicked(InputClickedEventData eventData)

        {
            Debug.Log("Click on hammer");
            string v = "breakGlass";
            PlayerPrefs.SetInt(v, 1);
            Destroy(gameObject);
            
            eventData.Use();
        }

    }
}
