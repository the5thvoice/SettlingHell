using UnityEngine;
using System.Collections;

public class SH_Projectile : MonoBehaviour
{

    public float Speed = 20;
    public bool OnScreen;

    public void Start()
    {
        if (SH_GameManager.GM.Ammo.Contains(gameObject))
            return;

        SH_GameManager.GM.Ammo.Add(gameObject);

    }



    // Update is called once per frame
    void Update()
    {
        if (OnScreen)
            transform.Translate(Vector2.up * Speed * Time.deltaTime);

    }

    public void OnBecameInvisible()
    {

        OnScreen = false;



    }

    public void OnBecameVisible()
    {
        OnScreen = true;

    }
}
