using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Lane : MonoBehaviour
{

    private PlayerScript _player;

    //レーン数
    [SerializeField]
    private int _lane = 4;
    public int GetLaneNum()
    {
        return _lane;
    }

    //レーンごとのポジション
    private List<int> _lanePos;
    public List<int> GetLaneList()
    {
        return _lanePos;
    }


    void Awake()
    {
        _player = FindObjectOfType<PlayerScript>();
        _lanePos = new List<int>() {};

        //ポジションの計算
        int playerScaleX = (int)_player.GetScale().x;
        for (int i = 0; i < _lane; i++)
        {
            int pos = ((playerScaleX / (_lane * 2)) * (i * 2 + 1)) + (playerScaleX / 2 * -1);
            _lanePos.Add(pos);
            Debug.Log(_lanePos[i]);
        }
    }
}
