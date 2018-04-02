using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace HoloToolkit.Unity.InputModule.Tests
{
    public class InteractiveKey : MonoBehaviour, IInputClickHandler
    {
        public GameObject key;
        public void OnInputClicked(InputClickedEventData eventData)
        {
            Debug.Log("key taken");
            PlayerPrefs.SetInt("bombUnlocked", 1);
            key.SetActive(false);
        }

      



        // Use this for initialization
        void Start()
        {
            PlayerPrefs.SetInt("bombUnlocked", 0);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}