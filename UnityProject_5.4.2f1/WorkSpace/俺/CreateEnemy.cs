using UnityEngine;
using System.Collections;

public class CreateEnemy : MonoBehaviour {

    [SerializeField]
    GameObject enemyObject;

    [SerializeField]
    float createSpeed = 1;
    private float _time;
    [SerializeField]
    int lane = 4;
    [SerializeField]
    float width;
    private float _DEFAULT_POS_X;
    private const float _DEFAULT_POS_Y = 5;

    private int _randomInt;

	void Start () {
        _time = createSpeed;
        _DEFAULT_POS_X = width /2  * -1;
        Vector3 pos = new Vector3((width/lane)+_DEFAULT_POS_X, _DEFAULT_POS_Y, 0);
        Instantiate(enemyObject, pos, new Quaternion(0, 0, 0, 0));
	}
	
	void Update () {
        //エネミー生成
        _time -= Time.deltaTime;
        if (_time <= 0.0)
        {
            _time = createSpeed;

            //エネミー生成
            _randomInt = Random.Range((int)0, (int)lane);
            Vector3 pos = new Vector3((width / lane)*_randomInt+_DEFAULT_POS_X, _DEFAULT_POS_Y, 0);
            Instantiate(enemyObject, pos, new Quaternion(0, 0, 0, 0));
        }
	}
}
