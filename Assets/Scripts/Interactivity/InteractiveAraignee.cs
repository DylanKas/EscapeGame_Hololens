using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace HoloToolkit.Unity.InputModule.Tests
{
    public class InteractiveAraignee : MonoBehaviour, IInputClickHandler
    {

        public GameObject Araignee, Toile, Explosion,bouton;
        // Use this for initialization
        public void Start()
        {
            bouton.SetActive(false);
        }

        // Update is called once per frame
        public void OnInputClicked(InputClickedEventData eventData)
        {
            string v = "briquet";
            if (PlayerPrefs.GetInt(v) == 1)
            {
                GetComponent<AudioSource>().Play();
                PlayerPrefs.SetInt("tab2", 1);
                Araignee.SetActive(false);
                Toile.SetActive(false);
                Explosion.GetComponent<ParticleSystem>().Play();
                bouton.SetActive(true);
                Collider m_Collider = GetComponent<Collider>();
                m_Collider.enabled = false;
            }
            eventData.Use();
        }
    }
}