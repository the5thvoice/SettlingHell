using UnityEngine;
using System.Collections;
/// <summary>
/// disable game introduction after a few seconds
/// </summary>
public class IntroductionScript : MonoBehaviour {

	float timer = 5;
	// Update is called once per frame
	void Update () {


        if (timer > 0)
        {
            timer -= Time.deltaTime;
            return;
        }

        gameObject.SetActive(false);


	
	}
}
