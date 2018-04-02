using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace HoloToolkit.Unity.InputModule.Tests
{
    public class InteractiveGlass_Valve : MonoBehaviour, IInputClickHandler
    {
        public GameObject glass;
        public AudioSource breakingglass;
        // Use this for initialization
        public void Start()
        {
            string v = "breakGlass";
            PlayerPrefs.SetInt(v, 0);
        }

        // Update is called once per frame
        public void OnInputClicked(InputClickedEventData eventData)
        {
            if (PlayerPrefs.GetInt("breakGlass") == 1)
            {
                Debug.Log("Break  glass");
                PlayerPrefs.SetInt("tab1", 1);
                breakingglass.Play();
                gameObject.SetActive(false);
                eventData.Use();
            }
            
        }
    }
}