using UnityEngine;
using System.Collections;

public class EffectManagerVer2 : MonoBehaviour
{
    bool _play = false;

    [SerializeField]
    GameObject _Bullet;

    private GameObject _topObj;
    [SerializeField]
    private GameObject _effectObj;

    [SerializeField]
    private int _createSpeed = 1;
    private float _count = 0;

    private int _createLimit = 4;
    private int _createCount = 0;

    private Vector3 _defaultPos = new Vector3(0, -20, 0);
    private Vector3 _angle = new Vector3(0, 0, 60);
    private int _way = 1;

    private ParticleSystem _particleSystem;

    void Start()
    {
        _defaultPos = _Bullet.transform.position;

        _topObj = Instantiate(_effectObj);
        _topObj.transform.Rotate(_angle);
        _topObj.transform.position = _defaultPos;

        _count = 0;

    }

    void Update()
    {

        //バレットの位置に修正
        if (_defaultPos != _Bullet.transform.position&&!_play)
        {
            _defaultPos = _Bullet.transform.position;
            _topObj.transform.position = _defaultPos;
            _play = true;
        }

        if (!_play) return;
        _count += Time.deltaTime;
        //if (_count >= _createSpeed)
        for (int i = 0; i < _createSpeed; i++)
        {
            //次のオブジェを生成＆位置角度調整
            GameObject nextObj = Instantiate(_effectObj);
            float degree = (_angle.z + 90);
            float radian = degree * Mathf.PI / 180;
            float sizeY = _topObj.transform.localScale.y;
            float posX = Mathf.Cos(radian) * sizeY;
            float posY = Mathf.Sin(radian) * sizeY;
            Vector3 pos = (new Vector3(posX, posY, 0)) + _topObj.transform.position;
            nextObj.transform.position = pos;

            _topObj = nextObj;

            _createCount++;
            _count = 0;
            if (_createCount >= _createLimit)
            {
                _way = _way * -1;
                if (_way >= 0)
                {
                    _createLimit = Random.Range(7, 9);
                    _angle.z = Random.Range(20, 60);
                }
                _angle *= _way;
                _createCount = 0;
            }
            nextObj.transform.Rotate(_angle);

            _particleSystem = _topObj.transform.FindChild("effectObj").FindChild("Particle System").GetComponent<ParticleSystem>();
            _particleSystem.startRotation = _way * -1;
        }
    }
}
