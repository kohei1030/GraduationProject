using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using Common;

public class Shooting : MonoBehaviour {

    [SerializeField]
    private GameObject _bullet;
    private Lane _lane;
    private List<Vector3> _lanePos;

    CreateEnemy createEnemy;
    PlayerScript player;

    bool firstShooted = false;

    //public Transform muzzle;

    void Start () {
       // Shoot();
        _lane = FindObjectOfType<Lane>();
        _lanePos = _lane.GetLaneList();

        createEnemy = FindObjectOfType<CreateEnemy>();
        player = FindObjectOfType<PlayerScript>();
    }

	void Update () {
        if (player.GetPlayerHp() > 0) Shoot();

        if (firstShooted || createEnemy.GetFirstEnemy() == null) return;
        if (createEnemy.GetFirstEnemy().transform.position.y <= (_lane.GetLaneSizeY() / 3) * 2)
        {
            GameObject bullet = GameObject.Instantiate(_bullet);
            EffectManagerVer2 effect = bullet.GetComponent<EffectManagerVer2>();
            Vector3 pos = _lanePos[createEnemy.GetFirstEnemyPos()];
            effect.SetDefaltPos(pos);
            firstShooted = true;
        }
    }

    void Shoot() {
        ShootSystem(0, Define.SHOT_KEY1);
        ShootSystem(1, Define.SHOT_KEY2);
        ShootSystem(2, Define.SHOT_KEY3);
        ShootSystem(3, Define.SHOT_KEY4);
    }

    private void ShootSystem(int laneNum,KeyCode key)
    {
        if (Input.GetKeyDown(key))
        {
            GameObject bullet = GameObject.Instantiate(_bullet);
            EffectManagerVer2 effect = bullet.GetComponent<EffectManagerVer2>();
            Vector3 pos = _lanePos[laneNum];
            effect.SetDefaltPos(pos);
        }
    }
}
