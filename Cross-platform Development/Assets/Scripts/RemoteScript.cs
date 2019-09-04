using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoteScript : MonoBehaviour
{
	private bool isVR;
    // Start is called before the first frame update
    void Start()
    {
		isVR = Application.platform == RuntimePlatform.Android;
    }

    // Update is called once per frame
    void Update()
    {
		if (!isVR)
		{
			if (Input.GetButton/*Down*/("Fire1"))
			{
				RaycastHit hit;
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

				if (Physics.Raycast(ray, out hit))
				{
					if (hit.collider.tag == "Button")
					{
						ButtonScript test = hit.collider.transform.parent.gameObject.GetComponent<ButtonScript>();
						test.OnClick();
					}
				}
			}
		}
		else
		{

		}
	}
}
