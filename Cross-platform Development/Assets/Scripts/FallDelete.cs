using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDelete : MonoBehaviour
{
	public float deleteBorder = -5;

    /// <summary>
    /// Delete the capsule when if falls below the deleteBorder Y coordinate
    /// </summary>
    void Update()
    {
		if (transform.position.y < deleteBorder)
		{
			Destroy(gameObject);
		}
	}
	
}
