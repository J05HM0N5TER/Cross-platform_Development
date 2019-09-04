using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallRespawn : MonoBehaviour
{
	private Vector3 respawnPosition;
	public float respawnBorder = - 5;

    // Start is called before the first frame update
    void Start()
    {
		respawnPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
		if (transform.position.y < respawnBorder)
		{
			transform.position = respawnPosition;
		}
    }
}
