using UnityEngine;
using System.Collections;

public class SH_Spawner : MonoBehaviour {


    public int SpawnAmount;
    public float MaxDelay;
    public float MinDelay;
    public float Health;

	// Use this for initialization
	void Start () {

        SH_SpawnController.OnSpawnWave += SpawnEnemy;
	
	}

    private void SpawnEnemy()
    {

        StartCoroutine(Spawn());
        


    }

    public IEnumerator Spawn()
    {
        for (int i =0; i < SpawnAmount; i++)
        {
            yield return new WaitForSeconds(Random.Range(MinDelay, MaxDelay));
            GameObject Enemy = SH_SpawnController.SC.SpawnEnemy();
            Enemy.transform.position = transform.position;
            Enemy.GetComponent<SpriteRenderer>().enabled = true;
            Enemy.GetComponent<SH_Enemey>().ResetDestnations(transform.position);
            Enemy.GetComponent<SH_Enemey>().Health = Health;
            Enemy.GetComponent<SH_Enemey>().Active = true;
            


        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    
    public void OnDisable()
    {
        SH_SpawnController.OnSpawnWave -= SpawnEnemy;// cleanup code, in the event that the Spawner may be disabled

    }


}
