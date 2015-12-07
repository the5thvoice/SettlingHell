using UnityEngine;
using System.Collections;

public class SH_Projectile : MonoBehaviour
{

    public float Speed = 20;
    public bool OnScreen;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(OnScreen)
            transform.Translate(Vector2.up * Speed * Time.deltaTime);

    }

    public void OnBecameInvisible()
    {

        OnScreen = false;
        


    }
}
