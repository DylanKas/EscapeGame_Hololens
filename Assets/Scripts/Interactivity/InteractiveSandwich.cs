using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoloToolkit.Unity.InputModule.Tests
{
    public class InteractiveSandwich : MonoBehaviour, IInputClickHandler
    {

        // Use this for initialization
        void Start()
        {
            string v = "sandwich";
            PlayerPrefs.SetInt(v, 0);
        }

        // Update is called once per frame
        public void OnInputClicked(InputClickedEventData eventData)
        {
            string b = "banana";
            if (PlayerPrefs.GetInt(b) == 2)
            {
                gameObject.SetActive(false);
                string v = "sandwich";
                PlayerPrefs.SetInt(v, 1);
            }
            eventData.Use();
        }
    }
}