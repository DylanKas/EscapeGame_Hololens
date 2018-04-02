using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoloToolkit.Unity.InputModule.Tests
{
    public class InteractiveChampignon : MonoBehaviour, IInputClickHandler
    {

        // Use this for initialization
        void Start()
        {
            string c = "champi";
            PlayerPrefs.SetInt(c, 0);
        }
        // Update is called once per frame
        public void OnInputClicked(InputClickedEventData eventData)
        {
            GetComponent<AudioSource>().Play();
            string c = "champi";
            
            PlayerPrefs.SetInt(c, 1);
            gameObject.SetActive(false);
            eventData.Use();
        }
    }
}