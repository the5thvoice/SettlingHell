using UnityEngine;
using System.Collections;

public enum BuildingState
{
    Placed,
    Selected,
    OnMouse,
}

public class SH_Building : MonoBehaviour {

    public BuildingState CurrentState;
    public float Cost;

	// Use this for initialization
	public virtual void Start () {

        if (SH_GameManager.GM.DebugMode == true)
        {
            SH_GameManager.GM.OccupiredGrids.Add(transform.position, gameObject);
        }
	
	}
	
	// Update is called once per frame
	public virtual void Update () {


        switch (CurrentState)
        {
            
            case BuildingState.OnMouse:
                MoveToMouse();
                break;
            case BuildingState.Placed:
                break;
            case BuildingState.Selected:
                break;

            default:
                return;


        }
        
	
	}


    public virtual void OnMouseUp()
    {
        
        if (CurrentState == BuildingState.OnMouse)
        {

            if(Cost > SH_GameManager.GM.TotalResource)
            {
                Destroy(gameObject);
                return;
            }

            SH_GameManager.GM.TotalResource -= Cost;
            CurrentState = BuildingState.Placed;
            SH_GameManager.GM.OccupiredGrids.Add(transform.position, gameObject);
            
        }
        
    }

    
    /// <summary>
    /// Moves Game Object to the position the mouse occupies on screen
    /// </summary>
    public virtual void MoveToMouse()
    {
        
        Vector3 Mpos = Input.mousePosition;
        Mpos.z = transform.position.z - Camera.main.transform.position.z;
        Vector3 Bpos = Camera.main.GetComponent<Camera>().ScreenToWorldPoint(Mpos);
        transform.position = new Vector3(Utility.RoundToPointFive(Bpos.x), Utility.RoundToPointFive(Bpos.y), Bpos.z);
    }

    public virtual void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.gameObject.GetComponent<SH_Projectile>()== null)
            return;

        collision.gameObject.GetComponent<SpriteRenderer>().enabled = false;

    }






}
