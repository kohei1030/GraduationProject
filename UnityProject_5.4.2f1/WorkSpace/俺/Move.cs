using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

	private Status _enemyStatus;

	void Start () {
		_enemyStatus = GetComponent<Status> ();
		float moveSpeed = _enemyStatus.GetMoveSpeed ();
	}
}
