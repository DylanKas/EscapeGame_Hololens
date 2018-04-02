using System;
using UnityEngine;

namespace HoloToolkit.Unity.InputModule.Tests
{
    /// <summary>
    /// This class implements IInputClickHandler to handle the tap gesture.
    /// It increases the scale of the object when tapped.
    /// </summary>
    public class BreakGlass : MonoBehaviour, IInputClickHandler
    {

        public GameObject miroir, miroirHS;

        public void OnInputClicked(InputClickedEventData eventData)
        {
            
                // Increase the scale of the object just as a response.
                if (!this.GetComponent<Rigidbody>())
                {
                    int avancement = 5;
                    PlayerPrefs.SetInt("avancementEnigme", avancement);
                    miroir.SetActive(false);
                    GetComponent<BoxCollider>().enabled = false;
                    miroirHS.SetActive(true);
                    eventData.Use(); // Mark the event as used, so it doesn't fall through to other handlers.
                }

            
        }
    }
}
