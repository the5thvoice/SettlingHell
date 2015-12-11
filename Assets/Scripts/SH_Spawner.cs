using UnityEngine;
using System.Collections;

public class SH_Spawner : MonoBehaviour {

	// Use this for initialization
	void Start () {

        SH_SpawnController.OnSpawnWave += SpawnEnemy;
	
	}

    private void SpawnEnemy()
    {
        GameObject Enemy = SH_SpawnController.SC.SpawnEnemy();
        Enemy.transform.position = transform.position;
        Enemy.GetComponent<SpriteRenderer>().enabled = true;
        Enemy.GetComponent<SH_Enemey>().ResetDestnations(transform.position);
        Enemy.GetComponent<SH_Enemey>().Active = true;


    }
	
	// Update is called once per frame
	void Update () {
	
	}

    
    public void OnDisable()
    {
        SH_SpawnController.OnSpawnWave -= SpawnEnemy;// cleanup code, in the event that the Spawner may be disabled

    }


}
