using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoloToolkit.Unity.InputModule.Tests
{
    
    public class Tournevis : MonoBehaviour, IInputClickHandler
    {
        // Use this for initialization
        void Start()
        {
            int avancement = 1;
            PlayerPrefs.SetInt("avancementEnigme", avancement);
            int tourneVis = 0;
            PlayerPrefs.SetInt("valeurTourneVis", tourneVis);

        }


        //ici le code à executer quand on interagit avec l'objet
        public void OnInputClicked(InputClickedEventData eventData)
        {
            Debug.Log("tournevis");
            int tourneVis = 1;
            PlayerPrefs.SetInt("valeurTourneVis", tourneVis);
            Destroy(gameObject);
            Debug.Log(PlayerPrefs.GetInt("valeurTourneVis"));
            int avancement = 2;
            PlayerPrefs.SetInt("avancementEnigme", avancement);
            eventData.Use();
        }

    }
}
