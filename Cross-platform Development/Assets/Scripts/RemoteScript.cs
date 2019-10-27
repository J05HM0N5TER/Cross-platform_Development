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

    /// <summary>
    /// Sets up what platform it is using to check collisions (VR or desktop)
    /// </summary>
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

    /// <summary>
    /// Checks if the player is interacting with anything and to react accordingly.
    /// </summary>
    void Update()
    {
        // If the user is not using a VR platform
        if (!isVR)
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit)/*If the mouse is pointing at something*/ &&
                Input.GetButton/*Down*/("Fire1")/*If mouse button is down*/)
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
        else
        {
            // Draw the laser for the controller
            Vector3[] points = new Vector3[]
                {
                    transform.position,
                    transform.position + (transform.rotation * transform.forward * lasorPointerLength)
                };

            line.SetPositions(points);

            RaycastHit hit;
            transform.rotation = OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTrackedRemote);
            
            if (Physics.Raycast(transform.position, transform.forward, out hit, validLayers)/*If the controller is pointing at something*/ && 
                OVRInput.Get(OVRInput.Button.Any)/*If the player has the interaction key pressed*/)
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
