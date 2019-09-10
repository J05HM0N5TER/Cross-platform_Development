using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoteScript : MonoBehaviour
{
	public GameObject UICanvas;
	public GameObject oculusGo;
	public LayerMask validLayers;
	private bool isVR;

	public bool canShoot;

	public float lasorPointerLength;
	private LineRenderer line;
	// Start is called before the first frame update
	void Start()
	{
		isVR = Application.platform == RuntimePlatform.Android;
		line = GetComponent<LineRenderer>();
		if (isVR)
		{
			oculusGo = transform.gameObject;
			line.enabled = true;
		}
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
						ButtonScript test = hit.collider.transform.gameObject.GetComponent<ButtonScript>();
						test.OnClick();
					}
					else if (canShoot && hit.transform.gameObject.tag == "Shootable")
					{
						Destroy(hit.collider.gameObject);
					}
				}
			}
		}
		else
		{
			//if (UICanvas.GetComponent<Toggle>().Value)
			//{
				Vector3[] points = new Vector3[]
					{
					transform.position,
					this.transform.position + (this.transform.rotation * transform.forward * lasorPointerLength)
					};

				line.SetPositions(points);
			//}

			RaycastHit hit;
			transform.rotation = OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTrackedRemote);

			if (Physics.Raycast(transform.position, transform.forward, out hit, validLayers) && OVRInput.Get(OVRInput.Button.Any))
			{
				if (hit.transform.gameObject.tag == "Button")
				{
					hit.collider.gameObject.GetComponent<ButtonScript>().OnClick();
				}
				else if (canShoot && hit.transform.gameObject.tag == "Shootable")
				{
					Destroy(hit.collider.gameObject);
				}
			}
		}
	}
}
