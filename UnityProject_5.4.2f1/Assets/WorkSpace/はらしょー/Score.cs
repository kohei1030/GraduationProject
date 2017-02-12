﻿using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

// スコア関連のクラス
public class Score : MonoBehaviour
{
    // 上限スコア
    [SerializeField]
    const int MAX_SCORE = 9999999;

    // 現在プレイ中ゲームのスコア
    static private int _currentScore = 0;
    // アニメーション用実スコア
    [SerializeField]
    private int _toScore = 0;

    /* アニメーションスピード
     1だとなんとなく遅い気がするし、
     7だとなんとなく1の位が全ての数字になるのでランダムに増えてる感じするかなぁと
     3桁くらいずつ増える想定なので1000とか一度に増えるようなら要調整*/
    [SerializeField]
    private int increaseSpeed = 0;

    // ランキングに使用するスコア
    static private List<int> _rankingScore;

    // スコア表示用変数
    public Text _dispScore;
    // ランキング表示用変数
    public Text _dispHighScore;
    // リザルト表示用変数
    public Text _dispResultScore;

    void Start()
    {
        _currentScore = 0;
        _rankingScore = new List<int>() { 0, 0, 0 };
    }

    // タイトル用アップデート
    public void TitleUpdate()
    {
        DispHighScore();
    }

    // ゲーム本編用アップデート
    public void GameUpdate()
    {
        IncreaseScore(0);
        DispScore();
    }

    // リザルト用アップデート
    public void ResultUpdate()
    {
        SortingHighScore();
        DispResult();
    }

    void Update()
    {
        GameUpdate();
    }

    //エネミーから呼び出す加算関数
    public void AddScoreForEnemy(int addScore)
    {
        _toScore += addScore;
    }
    
    // スコア加算
    // plusScore : 敵を倒した際に手に入るスコアの値
    public void IncreaseScore(int plusScore)
    {
        // もし敵を倒したらに変える
        //if (Input.GetMouseButtonDown(0))
        //{
        //    _toScore += plusScore;
        //}

        // スコアを増やす
        if (_currentScore < _toScore)
        {
            // 上限スコアを越えない
            if (_currentScore >= MAX_SCORE)
            {
                return;
            }

            _currentScore += (int)increaseSpeed;

            // 限界値突破防止
            // 例として、100スコア取った際、7ずつ増えるので
            // 70,77,84,91,98,105とオーバーしてしまうのを防ぐため
            if (_currentScore > _toScore)
            {
                _currentScore = _toScore;
            }
        }
    }

    // スコア表示する
    void DispScore()
    {
        _dispScore.text = "Score:" + _currentScore;
    }

    // ハイスコアをソートする
    void SortingHighScore()
    {
        // スコアを追加して、Listをソートする
        _rankingScore.Add(_toScore);
        _rankingScore.Sort(delegate (int a, int b) { return b - a; });
    }

    // ３位までのハイスコアを表示する
    void DispHighScore()
    {
        _dispHighScore.text =
            "Rank1 : " + _rankingScore[0] + "\n" +
            "Rank2 : " + _rankingScore[1] + "\n" +
            "Rank3 : " + _rankingScore[2];
    }

    // リザルトを表示する
    void DispResult()
    {
        // ランキングを抜き出す
        int _playerRank = _rankingScore.IndexOf(_toScore);

        // 順位を表示する
        _dispResultScore.text = "あなたの\nランキングは...\n" + (_playerRank + 1) + " 位です!!";
    }
}
