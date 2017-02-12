using UnityEngine;
using System.Collections;

using Common;

public class PlayerScript : MonoBehaviour {

    
    [SerializeField]
    int _playerHp = 1;
    public int GetPlayerHp() { return _playerHp; }

    Fade gameOverFade;

    //位置情報取得
    public Vector3 GetPosition()
    {
        return transform.position;
    }
    public Vector3 GetScale()
    {
        return transform.localScale;
    }

    void Start()
    {
        gameOverFade = FindObjectOfType<Fade>();
    }

    public void SubLife(int damage)
    {
        //ダメージ！
        _playerHp -= damage;
    }
	void Update () {
        //hpなかったら死
        if (_playerHp <= 0)
        {
            if (gameOverFade.PlayFade() >= 2)
            {
                Debug.Log("GameOver");
                GameObject parent = transform.root.gameObject;
                Destroy(parent);
                //シーン切り替え
                FindObjectOfType<sceneManager>().NextScene(Define.GAME_OVER);
            }
        }
    }
/*
    void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.tag == "Enemy") {
            _playerHp -= 1;
        } 
    }
*/
}
