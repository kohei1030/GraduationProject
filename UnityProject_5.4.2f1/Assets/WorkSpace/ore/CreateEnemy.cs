using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CreateEnemy : MonoBehaviour
{

    [SerializeField]
    GameObject enemyObject;

    private Lane _lane;

    [SerializeField]
    float createSpeed = 1;
    [SerializeField]
    float addSpeed = 0.01f;
    private float _time;
    //private const float _DEFAULT_POS_Y = 20;

    private List<Vector3> _lanePos;
    private float _laneSizeY;
    GameObject firstEnemy;
    public GameObject GetFirstEnemy() { return firstEnemy; }
    [SerializeField]
    int firstEnemyPos = 2;
    public int GetFirstEnemyPos() { return firstEnemyPos; }

    int tutorialStep = 0;
    [SerializeField]
    GameObject startLogo;

    bool startTutorial = true;

    void Start()
    {
        _time = 0;

        //レーン情報取得
        _lane = FindObjectOfType<Lane>();
        _lanePos = _lane.GetLaneList();
        _laneSizeY = _lane.GetLaneSizeY();
    }

    void Update()
    {
        //チュートリアル終了前は処理を行わない
        if (!Tutorial()) return;

        //エネミー生成
        _time -= Time.deltaTime;
        if (_time <= 0.0)
        {
            createSpeed -= addSpeed;
            _time = createSpeed;

            //エネミー生成
            Create();
        }
    }

    GameObject Create(int enemyPos = -1)
    {
        //エネミー生成
        if (enemyPos == -1) enemyPos = Random.Range((int)0, (int)_lane.GetLaneNum());
        Vector3 pos = _lanePos[enemyPos] + new Vector3(0, _laneSizeY, 0);
        return Instantiate(enemyObject, pos, new Quaternion(0, 0, 0, 0)) as GameObject;
    }

    bool Tutorial()
    {
        switch (tutorialStep)
        {
            case 0:
                if (startTutorial) tutorialStep++;
                return false;
            case 1:
                //チュートリアルエネミー
                firstEnemy = Create(firstEnemyPos);
                tutorialStep++;
                return false;
            case 2:
                if (firstEnemy == null) tutorialStep++;
                return false;
            case 3:
                Vector3 pos = new Vector3(-2.0f, -10, 0);
                startLogo = Instantiate(startLogo,pos,new Quaternion(0,0,0,0))as GameObject;
                tutorialStep++;
                return false;
            case 4:
                startLogo.transform.position += new Vector3(0, 0.2f, 0);
                if (startLogo.transform.position.y >= _laneSizeY - 20) tutorialStep++;
                return false;
            case 5:
                Destroy(startLogo);
                tutorialStep++;
                return true;
            case 6:
                return true;
            default:
                return false;
        }
    }
}
