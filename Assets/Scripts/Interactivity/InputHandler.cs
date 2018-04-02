using UnityEngine;
using System.Collections;

public class InputHandler : MonoBehaviour 
{
    public float range;
    public GameObject character;

	void Update () 
	{
        Debug.DrawRay(character.transform.position, character.transform.forward * range, Color.red);

        if (Input.GetMouseButton(0))
		{
            RaycastHit hit;
            Ray ray = new Ray(character.transform.position, character.transform.forward);
            
            if (Physics.Raycast(ray, out hit, range))
			{
				InteractiveObject obj = hit.collider.GetComponent<InteractiveObject>();
				if(obj)
				{
					obj.TriggerInteraction();
				}
			}
		}
	}
}
