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

	// Use this for initialization
	void Start () {
	
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


    public void OnMouseUp()
    {
        
        if (CurrentState == BuildingState.OnMouse)
        {
            
            CurrentState = BuildingState.Placed;
            
        }

    }

    
    /// <summary>
    /// Moves Game Object to the position the mouse occupies on screen
    /// </summary>
    public virtual void MoveToMouse()
    {
        
        Vector3 pos = Input.mousePosition;
        pos.z = transform.position.z - Camera.main.transform.position.z;
        transform.position = Camera.main.GetComponent<Camera>().ScreenToWorldPoint(pos);
    }
}
