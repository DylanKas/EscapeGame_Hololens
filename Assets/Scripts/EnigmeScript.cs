using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace HoloToolkit.Unity.InputModule.Tests
{
    public class EnigmeScript : MonoBehaviour, IInputClickHandler
    {
        public GameObject Tournevis,Grille,Marteau,Miroir,Animaux;
        // Use this for initialization
        public void Start()
        {

        }

        // Update is called once per frame
        public void OnInputClicked(InputClickedEventData eventData)
        {

            if (PlayerPrefs.GetInt("avancementEnigme") == 1)
            {
                Tournevis.GetComponent<AudioSource>().Play();
            }else if(PlayerPrefs.GetInt("avancementEnigme") == 2)
            {
                Grille.GetComponent<AudioSource>().Play();
            }
            else if (PlayerPrefs.GetInt("avancementEnigme") == 3)
            {
                Marteau.GetComponent<AudioSource>().Play();
            }
            else if (PlayerPrefs.GetInt("avancementEnigme") == 4)
            {
                Miroir.GetComponent<AudioSource>().Play();
            }
            else
            {
                Animaux.GetComponent<AudioSource>().Play();
            }
        }
    }
}