using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour
{

    private Status _enemyStatus;

    private void Start()
    {
        _enemyStatus = GetComponent<Status>();
    }

    private void Update()
    {
        Rigidbody rigid = _enemyStatus.GetRigidbody();
        float moveSpeed = _enemyStatus.GetMoveSpeed();
        Vector3 moveForce = new Vector3(0, moveSpeed * -1, 0);
        //移動
        rigid.AddForce(moveForce);
    }

    private void OnCollisionStay(Collision collision)
    {
        //被弾
        if (collision.gameObject.tag == "Shot")
        {
            _enemyStatus.SubLife(1);
        }
        //攻撃
        if (collision.gameObject.tag == "Player")
        {
            //デバックログ
            Debug.Log("エネミーくん渾身の一撃");

            Destroy(gameObject);

            //プレイヤーのライフを減らす関数を呼ぶ

        }
    }
}
