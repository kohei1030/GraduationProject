using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Shooting : MonoBehaviour {

    public GameObject bullet;
    private Lane _lane;
    private List<int> _lanePos;

    //public Transform muzzle;

    void Start () {
       // Shoot();
        _lane = FindObjectOfType<Lane>();
        _lanePos = _lane.GetLaneList();
    }

	void Update () {
        Shoot();
    }

    void Shoot() {
        ShootSystem(0, KeyCode.Z);
        ShootSystem(1, KeyCode.X);
        ShootSystem(2, KeyCode.C);
        ShootSystem(3, KeyCode.V);
    }

    private void ShootSystem(int laneNum,KeyCode key)
    {
        if (Input.GetKeyDown(key))
        {
            GameObject bullets = GameObject.Instantiate(bullet) as GameObject;
            bullets.transform.position = new Vector3(_lanePos[laneNum],transform.position.y,transform.position.z);
        }
    }
}
