using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SH_Enemey : MonoBehaviour {


    public GameObject TargetBuilding;
    public Vector3 CurrentDestination;
    private Vector3 previousPosition;
    private Vector3 SecondPrevious;
    public float Speed = 0.5f;
    public float Health = 0.1f;
    public bool Active = true;
    public float Strength;
    

    public void Start()
    {
        CurrentDestination = new Vector3(Utility.RoundToPointFive(transform.position.x), Utility.RoundToPointFive(transform.position.y), transform.position.z);
        SH_GameManager.GM.Enemies.Add(gameObject);

    }



	
	// Update is called once per frame
	void Update () {


        if (!Active)
            return;

        CheckPotentialTarget();
        if (TargetBuilding == null)
            return;
        move();
        CheckHealth(); 


        
	
	}
    /// <summary>
    /// checks for a viable target, and if no target currently active set found target as new target
    /// </summary>
    private void CheckPotentialTarget()
    {
        if (TargetBuilding != null)
            if(SH_GameManager.GM.ViableTargets.Contains(TargetBuilding))// checks to see if current target is still viable target
                return;

        TargetBuilding = SH_GameManager.GM.GetViableTarget(transform.position);

        if (TargetBuilding == null)
            Deactivate();
    }

    /// <summary>
    /// checks if Health is less then 0 and performs Death logic if true
    /// </summary>
    private void CheckHealth()
    {
        if (Health > 0)
            return;

        Deactivate();



    }

    /// <summary>
    /// deactivates enemy, rendering it available for respawn
    /// </summary>
    private void Deactivate()
    {
        TargetBuilding = null;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        Active = false;
    }

    /// <summary>
    /// encapsulates all pathfinding and movement for enemy
    /// </summary>
    private void move()
    {
        // checks if it's reached it's ultimate target and applies damage
        if (transform.position == TargetBuilding.transform.position)
        {
            if (TargetBuilding.GetComponent<SH_HabBuilding>() != null)
                TargetBuilding.GetComponent<SH_HabBuilding>().Damage(Strength);
            Deactivate();

        }
            

        if (transform.position == CurrentDestination)
        {

            updateCurrentDestination();
        }

        transform.position = Vector3.MoveTowards(transform.position, CurrentDestination, Speed * Time.deltaTime);
    }

    /// <summary>
    /// updates the current destiation vector. if it can't up vector all it does is up date it's previous and second previous positons to allow it to backtrack
    /// </summary>
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
        if (potentialDestinations.Contains(previousPosition))
        {
            potentialDestinations.Remove(previousPosition);
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

        // updates path currently follow
        SecondPrevious = previousPosition;
        previousPosition = CurrentDestination;

        //updats to next destination
        if(potentialDestinations.Count > 0)
            CurrentDestination = potentialDestinations[(int)Random.Range(0,potentialDestinations.Count-1 )];
        for (int i = 0; i < potentialDestinations.Count; i++)
        {
            // check how close the next potental destinatin is to it's target
            if (Vector3.Distance(potentialDestinations[i], TargetBuilding.transform.position) < Vector3.Distance(CurrentDestination, TargetBuilding.transform.position))
            {
                CurrentDestination = potentialDestinations[i];
                

            }
           
            
        }

        


    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("collision");

        GameObject collidedObject = collision.gameObject;

        if (collidedObject.GetComponent<SH_Projectile>() == null)
        {
            return;
        }

        Health -= collidedObject.GetComponent<SH_Projectile>().Damage;
        collidedObject.GetComponent<SpriteRenderer>().enabled = false;
        

    

    }






    internal void ResetDestnations(Vector3 Reset)
    {
        CurrentDestination = Reset;
    }
}
