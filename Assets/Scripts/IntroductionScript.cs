using UnityEngine;
using System.Collections;

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
