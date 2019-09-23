using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptuleCountScript : MonoBehaviour
{
	TextMesh text;

    // Start is called before the first frame update
    void Start()
    {
		text = GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {
		text.text = GameObject.FindGameObjectsWithTag("Shootable").Length.ToString();

	}
}
