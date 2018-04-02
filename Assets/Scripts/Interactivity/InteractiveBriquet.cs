using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace HoloToolkit.Unity.InputModule.Tests
{
    public class InteractiveBriquet : MonoBehaviour, IInputClickHandler
    {

        // Use this for initialization
        public void Start()
        {
            string v = "briquet";
            PlayerPrefs.SetInt(v, 0);
        }

        // Update is called once per frame
        public void OnInputClicked(InputClickedEventData eventData)
        {
            Debug.Log("selected briquet");
            PlayerPrefs.SetInt("tab0", 1);
            gameObject.SetActive(false);
            string v = "briquet";
            PlayerPrefs.SetInt(v, 1);
            eventData.Use();
        }
    }
}