using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SH_GameManager : MonoBehaviour {


    public List<GameObject> ViableTargets;

    public static SH_GameManager GM;

    void Awake()
    {
        if (GM == null)
        {
            GM = this;
        }

    }
    


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
