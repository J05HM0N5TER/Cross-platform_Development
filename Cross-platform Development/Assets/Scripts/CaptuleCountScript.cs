using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptuleCountScript : MonoBehaviour
{
	TextMesh text;

    /// <summary>
    /// Cache the text mesh
    /// </summary>
    void Start()
    {
		text = GetComponent<TextMesh>();
    }

    /// <summary>
    /// Set the display for how many capsules exist at the time
    /// </summary>
    void Update()
    {
		text.text = GameObject.FindGameObjectsWithTag("Shootable").Length.ToString();

	}
}
