using UnityEngine;
using System.Collections;

//RigidBodyの追加
[RequireComponent(typeof(Rigidbody))]

public class Status : MonoBehaviour {

    //移動速度
	[SerializeField]
	private float _moveSpeed = 1;
	public float GetMoveSpeed()
    {
		return _moveSpeed;
	}
    //ライフ
	[SerializeField]
    private int _life = 1;
	public int GetLife()
    {
		return _life;
	}

    public void SubLife(int damage)
    {
        if (_life > 0)
        {
            _life -= damage;
        }
        if (_life <= 0)
        {
            _life = 0;
            DestroyOwn();
        }
    }

    //リジッドボディー
    private Rigidbody _rigidbody;
    public Rigidbody GetRigidbody()
    {
        return _rigidbody;
    }

    private void Awake()
    {
        this.tag = "Enemy";
        _rigidbody = GetComponent<Rigidbody>();
    }

    //消滅
    private void DestroyOwn()
    {
        //デバックログ
        Debug.Log("エネミーくん無念の戦死");

        //スコア加算関数呼び出し

        //消滅
        Destroy(gameObject);
    }
}