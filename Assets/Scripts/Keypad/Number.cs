using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoloToolkit.Unity.InputModule.Tests
{
    public class Number : MonoBehaviour, IInputClickHandler
    {
        public GameObject keypad;

        public void OnInputClicked(InputClickedEventData eventData)
        {
            keypad.GetComponent<Code>().recevoirSignal(gameObject);
            eventData.Use();
        }
    }
}
