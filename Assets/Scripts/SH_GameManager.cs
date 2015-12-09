using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class SH_GameManager : MonoBehaviour {


    public List<GameObject> ViableTargets;// lists the buildings that will be viable targts for enemy mobs
    public bool DebugMode;// debug mode
    private Dictionary<Vector3, GameObject> _OccupiedGrids;
    /// <summary>
    /// returs a list of all grids occuped by stationay game objects, orgnised by vector location 
    /// </summary>
    public Dictionary<Vector3, GameObject> OccupiredGrids
    {
        get
        {
            if (_OccupiedGrids == null)
                _OccupiedGrids = new Dictionary<Vector3, GameObject>();

            return _OccupiedGrids;
        }
    }


    private List<GameObject> _Enemies;
    /// <summary>
    /// list of all "Enemies" currently active
    /// </summary>
    public List<GameObject> Enemies
    {
        get
        {
            if (_Enemies == null)
                _Enemies = new List<GameObject>();

            return _Enemies;
        }
    }

    public GameObject AmmoPrefab;
    private List<GameObject> _Ammo;
    /// <summary>
    /// list of all ammo in scene. check for available unused ammo before instansiate a new one
    /// </summary>
    public List<GameObject> Ammo
    {
        get
        {
            if (_Ammo == null)
                _Ammo = new List<GameObject>();

            return _Ammo;
        }
    }

    /// <summary>
    /// Instansiate a projectile to be fired by Towers
    /// </summary>
    /// <returns>an instance of the Ammo Prefab</returns>
    internal GameObject GetAmmo()
    {

        if (Ammo.Count > 1)
        {
            foreach (GameObject GO in Ammo)
            {
                if (GO.GetComponent<SH_Projectile>().OnScreen)
                    continue;
                return GO;
            }
        }
        return Instantiate(AmmoPrefab) as GameObject;
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




    /// <summary>
    /// get a new viable target enemy
    /// </summary>
    /// <returns>game object</returns>
    internal GameObject NewTargetEnemeny()
    {
        foreach (GameObject GO in Enemies)
        {
            if (!GO.GetComponent<SH_Enemey>().Active)
                continue;

            return GO;
        }

        return null;
    }
}
