using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SH_SpawnBuilding : MonoBehaviour {


    public GameObject BuildingPrefab;



    public void SpawnBuilding()
    {
        GameObject newBuilding = Instantiate(BuildingPrefab) as GameObject;
        newBuilding.GetComponent<SH_Building>().CurrentState = BuildingState.OnMouse;
    }

}
