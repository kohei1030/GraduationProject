using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {

    public GameObject bullet;

    //public Transform muzzle;

    
    // Use this for initialization
    void Start () {
       // Shoot();
    }
	
	// Update is called once per frame
	void Update () {
        Shoot();
    }

    void Shoot() {
        if (Input.GetKeyDown(KeyCode.Z))
        {
          GameObject  bullets = GameObject.Instantiate(bullet) as GameObject;
            //bullets.transform.position = muzzle.position;
            
        }

    }
    
}
