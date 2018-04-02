using UnityEngine;
using System.Collections;



public abstract class InteractiveObject : MonoBehaviour 
{


    //Initialisation // attention, en C# pour ecrire une fonction héritée vous devez dire : exemple : public override void Start(){ Votre code ... ]
    public abstract void Start();

    //code à executer après l'appel à input handler // attention, en C# pour ecrire une fonction héritée vous devez dire : exemple : public override void TriggerInteraction(){ Votre code ... ]
    public abstract void TriggerInteraction();
       
}
