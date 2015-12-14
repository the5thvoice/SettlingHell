using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SH_DisplayResources : MonoBehaviour {

    Text TextDisp
    {

        get
        {
            return GetComponent<Text>();

        }
    }

	
	
	// Update is called once per frame
	void Update () {


        TextDisp.text = "Resources: " + SH_GameManager.GM.TotalResource.ToString();
	
	}
}
