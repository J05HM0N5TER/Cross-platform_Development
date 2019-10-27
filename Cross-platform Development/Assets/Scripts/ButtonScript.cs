using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    // The capsule prefab
	public GameObject spawnObject;
    // How many spawn per frame
	public int spawnRate;
    // The offset from the button to the spawn position.
    public Vector3 spawnOffset = new Vector3(0, 1.2f, 0);

    /// <summary>
    /// Spawn the specified amount of capsules 
    /// </summary>
	public void OnClick()
	{
		for (int i = 0; i < spawnRate; i++)
		{
            // Create a new capsule at the needed position.
			Instantiate(spawnObject, transform.position + spawnOffset, Quaternion.identity/*Random.rotation*/);
		}
	}
}
