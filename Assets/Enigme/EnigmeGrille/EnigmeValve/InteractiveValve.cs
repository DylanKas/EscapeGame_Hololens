using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace HoloToolkit.Unity.InputModule.Tests
{
    public class InteractiveValve : MonoBehaviour, IInputClickHandler
    {

        private int timeToTurnValve = 0;
        public void OnInputClicked(InputClickedEventData eventData)
        {
            Debug.Log("WaterUP");
            PlayerPrefs.SetInt("waterUP", 1);
            GetComponent<AudioSource>().Play();
            StartCoroutine(WaterUp());
        }

        public IEnumerator WaterUp()
        {
            timeToTurnValve = 1;
            yield return new WaitForSeconds(6);
            timeToTurnValve = 0;

        }



        // Use this for initialization
        void Start()
        {
            Debug.Log("Start Valve");
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}