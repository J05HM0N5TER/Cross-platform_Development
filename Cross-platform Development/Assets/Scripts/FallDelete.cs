using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDelete : MonoBehaviour
{
	public float deleteBorder = -5;
	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (transform.position.y < deleteBorder)
		{
			Destroy(gameObject);
		}
	}
	
}
