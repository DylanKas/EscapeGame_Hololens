using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoloToolkit.Unity.InputModule.Tests
{
    public class InteractiveBottle : MonoBehaviour, IInputClickHandler
    {

        // Use this for initialization
        void Start()
        {
            string v = "bottle";
            PlayerPrefs.SetInt(v, 0);
        }

        // Update is called once per frame
        public void OnInputClicked(InputClickedEventData eventData)
        {
            string b = "sandwich";
            if (PlayerPrefs.GetInt(b) == 2)
            {
                gameObject.SetActive(false);
                string v = "bottle";
                PlayerPrefs.SetInt(v, 1);
            }
            eventData.Use();
        }
    }
}
