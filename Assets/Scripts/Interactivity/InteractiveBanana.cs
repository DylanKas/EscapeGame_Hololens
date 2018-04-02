using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace HoloToolkit.Unity.InputModule.Tests
{
    public class InteractiveBanana : MonoBehaviour, IInputClickHandler
    {

        // Use this for initialization
        void Start()
        {
            string v = "banana";
            PlayerPrefs.SetInt(v, 0);
        }

        // Update is called once per frame
        public void OnInputClicked(InputClickedEventData eventData)
        {
            gameObject.SetActive(false);
            string v = "banana";
            PlayerPrefs.SetInt(v, 1);
            eventData.Use();
        }
    }
}