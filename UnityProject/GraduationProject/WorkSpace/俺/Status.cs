using UnityEngine;
using System.Collections;

public class Status : MonoBehaviour {
	[SerializeField]
	private float _moveSpeed = 1;
	public float GetMoveSpeed(){
		retun _moveSpeed;
	}
	[SerializeField]
	private int _life = 1;
	public int GetLife(){
		return _life;
	}
}

