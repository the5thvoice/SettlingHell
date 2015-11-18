using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SH_GameManager : MonoBehaviour {


    public List<GameObject> ViableTargets;
    public bool DebugMode;
    private Dictionary<Vector3, GameObject> _OccupiedGrids;
    public Dictionary<Vector3, GameObject> OccupiredGrids
    {
        get
        {
            if (_OccupiedGrids == null)
                _OccupiedGrids = new Dictionary<Vector3, GameObject>();

            return _OccupiedGrids;
        }
    }

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
