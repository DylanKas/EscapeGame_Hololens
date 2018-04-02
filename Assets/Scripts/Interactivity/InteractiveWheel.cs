using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace HoloToolkit.Unity.InputModule.Tests
{
    public class InteractiveWheel : MonoBehaviour, IInputClickHandler
    {
        int currentNumber = 0;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        public void OnInputClicked(InputClickedEventData eventData)
        {
                GetComponent<AudioSource>().Play();
                if (currentNumber < 9)
                {
                    currentNumber++;
                }
                else
                {
                    currentNumber = 0;
                }
           transform.localRotation = Quaternion.RotateTowards(transform.localRotation, Quaternion.Euler(0, 0, currentNumber * -36), 200);
            eventData.Use();
        }
    }
}