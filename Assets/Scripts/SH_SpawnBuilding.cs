using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SH_SpawnBuilding : MonoBehaviour {


    public GameObject BuildingPrefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SpawnBuilding()
    {
        GameObject newBuilding = Instantiate(BuildingPrefab) as GameObject;
        newBuilding.GetComponent<SH_Building>().CurrentState = BuildingState.OnMouse;
    }

}
