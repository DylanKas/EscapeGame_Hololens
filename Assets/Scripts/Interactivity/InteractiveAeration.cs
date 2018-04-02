using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveAeration : MonoBehaviour {
    private Rigidbody gameObjectsRigidBody; 
    private bool done;
	    // Ecrivez dans start votre initialisation
    void Start()
    {
        //On créer un rigidbody pour soumettre l'objet à la gravité mais on le met kinematic pour qu'il ne déplacement seulement par des transform.position
        gameObjectsRigidBody = this.gameObject.AddComponent<Rigidbody>();
        gameObjectsRigidBody.mass = 5;
        gameObjectsRigidBody.isKinematic = true;
            done = false;
      
    }

    //ici le code à executer quand on interagit avec l'objet
    void OnSelect()
    {
        int vis = PlayerPrefs.GetInt("valeurVis");
        
            Debug.Log("Interactive object");
     
                if (!done && vis<=0)
                {
                   	gameObjectsRigidBody.isKinematic = false;
                    done = true;
                   
					//L'objet est désormais soumis à la gravité
                    

                }
            }
        
    }

