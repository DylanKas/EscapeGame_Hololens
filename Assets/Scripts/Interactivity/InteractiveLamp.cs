using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace HoloToolkit.Unity.InputModule.Tests
{
    public class InteractiveLamp : MonoBehaviour, IInputClickHandler
    {
        public GameObject enigmeAnimaux;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        public void OnInputClicked(InputClickedEventData eventData)
        {
            enigmeAnimaux.SetActive(true);
            eventData.Use();
        }
    }
}