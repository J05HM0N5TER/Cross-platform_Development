using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
	//public Vector3 spawnPosition;
	public GameObject spawnObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

	public void OnClick()
	{
		//Instantiate(spawnObject, spawnPosition, /*Quaternion.identity*/Random.rotation);
		Instantiate(spawnObject, transform.position + new Vector3(0, 1.2f, 0), /*Quaternion.identity*/Random.rotation);
	}
}
