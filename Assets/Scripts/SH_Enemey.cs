using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SH_Enemey : MonoBehaviour {


    public GameObject TargetBuilding;
    public Vector3 CurrentDestination;
    private Vector3 previosPosition;
    private Vector3 SecondPrevious;

    public void Start()
    {
        CurrentDestination = new Vector3(Utility.RoundToPointFive(transform.position.x), Utility.RoundToPointFive(transform.position.y), transform.position.z);
        

    }



	
	// Update is called once per frame
	void Update () {

        if (transform.position == TargetBuilding.transform.position)
            return;

        if (transform.position == CurrentDestination)
        {
            updateCurrentDestination();
        }
        
        transform.position = Vector3.MoveTowards(transform.position, CurrentDestination, Speed * Time.deltaTime);
	
	}

    private void updateCurrentDestination()
    {
        List<Vector3> potentialDestinations = new List<Vector3>();
        float y = CurrentDestination.y - 0.5f;
        float x = CurrentDestination.x - 0.5f;

        // build a list of initall potental next steps in path finding
        while (y < CurrentDestination.y + 1)
        {
            while (x < CurrentDestination.x + 1)
            {
                potentialDestinations.Add(new Vector3(x, y, CurrentDestination.z));
                x += 0.5f;
            }
            x = CurrentDestination.x - 0.5f;
            y += 0.5f;

        }

        
        potentialDestinations.Remove(CurrentDestination);

        // tracks the last 2 steps so mob can't backtrack along it's path unless thats the only viable option
        if (potentialDestinations.Contains(previosPosition))
        {
            potentialDestinations.Remove(previosPosition);
        }
        if (potentialDestinations.Contains(SecondPrevious))
        {
            potentialDestinations.Remove(SecondPrevious);
        }

        // remove invalid tiles
        foreach (KeyValuePair<Vector3, GameObject> kvp in SH_GameManager.GM.OccupiredGrids)
        {
            if (potentialDestinations.Contains(kvp.Key))
            {
                if (SH_GameManager.GM.ViableTargets.Contains(kvp.Value))
                    continue;
                potentialDestinations.Remove(kvp.Key);
            }
        }

        
        SecondPrevious = previosPosition;
        previosPosition = CurrentDestination;
        if(potentialDestinations.Count > 0)
            CurrentDestination = potentialDestinations[(int)Random.Range(0,potentialDestinations.Count-1 )];
        for (int i = 0; i < potentialDestinations.Count; i++)
        {
            
            if (Vector3.Distance(potentialDestinations[i], TargetBuilding.transform.position) < Vector3.Distance(CurrentDestination, TargetBuilding.transform.position))
            {
                CurrentDestination = potentialDestinations[i];
                

            }
           
            
        }

        


    }

    public float Speed = 0.5f;
}
