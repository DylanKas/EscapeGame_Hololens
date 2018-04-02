using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace HoloToolkit.Unity.InputModule.Tests
{
    public class InteractiveHallucination : MonoBehaviour
    {

        public GameObject cubeHallucination,champi,animaux;
        // Use this for initialization
        void Start()
        {
            PlayerPrefs.SetInt("foods", 0);
            cubeHallucination.SetActive(false);
            animaux.SetActive(false);
            champi.SetActive(true);
        }

        // Update is called once per frame
        void Update()
        {
            if (PlayerPrefs.GetInt("champi") == 1)
            {
                PlayerPrefs.SetInt("foods", 1);
                StartCoroutine(Wait());
                Debug.Log("ok hallu");
                PlayerPrefs.SetInt("champi", 0);
                
                /*cubeHallucination.SetActive(false);
                EnigmeAnimaux.SetActive(false);
                stuff.SetActive(false);*/
            }
        }
        public IEnumerator Wait()
        {
            
            cubeHallucination.SetActive(true);
            animaux.SetActive(true);
            champi.SetActive(false);
            champi.GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(20);
            cubeHallucination.SetActive(false);
            PlayerPrefs.SetInt("foods", 0);
            animaux.SetActive(false);
            champi.SetActive(true);
           
        }
    }
}