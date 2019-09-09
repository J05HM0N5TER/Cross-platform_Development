using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
	public GameObject spawnObject;
	public int spawnRate;

	public void OnClick()
	{
		for (int i = 0; i < 8; i++)
		{
			Instantiate(spawnObject, transform.position + new Vector3(0, 1.2f, 0), /*Quaternion.identity*/Random.rotation);
		}
	}
}
