using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SH_SpawnBuilding : MonoBehaviour {


    public GameObject BuildingPrefab;


    /// <summary>
    /// spawns a new building when called by the "gameObjects" OnClick() event
    /// </summary>
    public void SpawnBuilding()
    {
        if (gameObject.tag != "HabitateBuilding")
        {
            if (SH_GameManager.GM.ViableTargets == null || SH_GameManager.GM.ViableTargets.Count < 1)
                return;
        }


        GameObject newBuilding = Instantiate(BuildingPrefab) as GameObject;
        newBuilding.GetComponent<SH_Building>().CurrentState = BuildingState.OnMouse;
    }

}
