using UnityEngine;
using System.Collections;

public class SH_Enemey : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {

        //transform.position = ( SH_GameManager.GM.ViableTargets[0].transform.position - transform.position) * (Speed * Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position, SH_GameManager.GM.ViableTargets[0].transform.position, Speed * Time.deltaTime);
	
	}

    public float Speed = 0.5f;
}
