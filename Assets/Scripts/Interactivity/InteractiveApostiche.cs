using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace HoloToolkit.Unity.InputModule.Tests
{
    public class InteractiveApostiche : MonoBehaviour
    {

        public GameObject texte1, texte2, texte3, victoryLabel,apostiche;

        void Start()
        {
            string s = "texte";
            victoryLabel.SetActive(false);
            apostiche.SetActive(true);
            PlayerPrefs.SetInt(s, 1);
            texte1.SetActive(false);
            texte2.SetActive(true);
            texte3.SetActive(false);
        }

        void Update()
        {
            
            if(PlayerPrefs.GetInt("slider1")==1 && PlayerPrefs.GetInt("slider2") == 1 && PlayerPrefs.GetInt("slider3") == 1)
            {
                Debug.Log("APOSTICHE GAGNE");
                PlayerPrefs.SetInt("tab4", 1);
                apostiche.SetActive(false);
                victoryLabel.SetActive(true);
            }

        }

    }
}