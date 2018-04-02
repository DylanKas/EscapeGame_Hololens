using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace HoloToolkit.Unity.InputModule.Tests
{
    public class Button_handler : MonoBehaviour, IInputClickHandler
    {
        int value;
        public AudioSource sound;
        // Use this for initialization
        void Start()
        {
            value = 0;
                PlayerPrefs.SetInt("isButtonDown", value);
            PlayerPrefs.SetInt("stopBuses", value);
            PlayerPrefs.SetInt("stopSmoke", value);
            PlayerPrefs.SetInt("launchSmoke", value);
        }

        public void OnInputClicked(InputClickedEventData eventData)
        {
            Debug.Log("Dommage !!!");
            PlayerPrefs.SetInt("tab3", 1);
            value = 1;
            sound.Play();
            PlayerPrefs.SetInt("tab5", 1);
            PlayerPrefs.SetInt("isButtonDown", value);
            
            StartCoroutine(waiter());
            
            eventData.Use();
        }

        IEnumerator waiter()
        {
            //Wait for 4 seconds
            value = 1;
            yield return new WaitForSeconds(3);
            PlayerPrefs.SetInt("launchSmoke", value);
            yield return new WaitForSeconds(18);
            PlayerPrefs.SetInt("stopBuses", value);
            yield return new WaitForSeconds(2);
            PlayerPrefs.SetInt("stopSmoke", value);
            Debug.Log("arretez tout !!!");

        }
    }
}
