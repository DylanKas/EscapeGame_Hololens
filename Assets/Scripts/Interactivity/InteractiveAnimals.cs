using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace HoloToolkit.Unity.InputModule.Tests
{
    public class InteractiveAnimals : MonoBehaviour, IInputClickHandler
    {

        public GameObject Singe, Elephant, Poisson, Tigre, ChestC,Keypad,ChestO,parent,hp;
        // Use this for initialization
        void Start()
        {
            string v = "codeBon";
            hp.SetActive(true);
            PlayerPrefs.SetInt(v, 0);
        }

        void Update()
        {
            string v = "codeBon";
            if (PlayerPrefs.GetInt(v) ==1)
            {
                ChestC.SetActive(false);
                ChestO.SetActive(true);
                PlayerPrefs.SetInt("tab5", 1);
                ChestO.transform.parent = parent.transform;
            }

        }
        // Update is called once per frame
        public void OnInputClicked(InputClickedEventData eventData)
        {
            string v = "banana";
            string v2 = "sandwich";
            string v3 = "bottle";
            string v4 = "viande";
            if (PlayerPrefs.GetInt(v) == 1)
            {
                Singe.SetActive(false);
                Elephant.SetActive(true);
                PlayerPrefs.SetInt(v, 2);
            }
            else
            {
                AudioSource audio = Singe.GetComponent<AudioSource>();
                audio.Play();
            }
            
            if (PlayerPrefs.GetInt(v) == 2 && PlayerPrefs.GetInt(v2) == 1)
            {
                Elephant.SetActive(false);
                Poisson.SetActive(true);
                PlayerPrefs.SetInt(v2, 2);
            }
            else
            {
                AudioSource audio = Elephant.GetComponent<AudioSource>();
                audio.Play();
            }
            if (PlayerPrefs.GetInt(v2) == 2 && PlayerPrefs.GetInt(v3) == 1)
            {
                Poisson.SetActive(false);
                Tigre.SetActive(true);
                PlayerPrefs.SetInt(v3, 2);
            }
            else
            {
                AudioSource audio = Poisson.GetComponent<AudioSource>();
                audio.Play();
            }
            if (PlayerPrefs.GetInt(v3) == 2 && PlayerPrefs.GetInt(v4) == 1)
            {
                Tigre.SetActive(false);
                PlayerPrefs.SetInt(v4, 2);
            }
            else
            {
                AudioSource audio = Tigre.GetComponent<AudioSource>();
                audio.Play();
            }
            if (PlayerPrefs.GetInt(v4) == 2)
            {
                Tigre.SetActive(false);
                ChestC.SetActive(true);
                Keypad.SetActive(true);
                PlayerPrefs.SetInt(v4, 3);
            }
            else
            {
               
                AudioSource audio = ChestC.GetComponent<AudioSource>();
                audio.Play();
            }
            if(PlayerPrefs.GetInt(v4) == 3)
            {
                int avancement = 5;
                PlayerPrefs.SetInt("avancementEnigme", avancement);
            }
            eventData.Use();
        }
    }
}