using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveTourneVis : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        int tourneVis = 0;
        PlayerPrefs.SetInt("valeurTourneVis", tourneVis);
    }


    //ici le code à executer quand on interagit avec l'objet
   void OnSelect()
    {
        Debug.Log("tournevis");
        int tourneVis = 1;
        PlayerPrefs.SetInt("valeurTourneVis", tourneVis);
        Destroy(gameObject);
    }

}
