using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTuto : MonoBehaviour {

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Sphere")){ //Teste si le collider a le tag

            Debug.Log("YESSSSSSSSS");

        } 
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("ça rentre !!!");
    }
}
