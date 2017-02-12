using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class CreateStar : MonoBehaviour {

    [SerializeField]
    private List<GameObject> _stars;

    private List<GameObject> _dispStar;

    [SerializeField]
    private float _createSpeed;

    private float _count = 0;

	void Update () {
        _count -= Time.deltaTime;
        if (_count <= 0)
        {
            GameObject star = _stars[(int)UnityEngine.Random.Range(0, _stars.Count)];

            Vector2 minPos = new Vector2(transform.position.x - transform.localScale.x / 2, transform.position.y - transform.localScale.y / 2);
            Vector2 maxPos = new Vector2(transform.position.x + transform.localScale.x / 2, transform.position.y + transform.localScale.y / 2);

            Vector3 pos = new Vector3(UnityEngine.Random.Range(minPos.x, maxPos.x), UnityEngine.Random.Range(minPos.y, maxPos.y), transform.position.z);

            GameObject.Instantiate(star).transform.position = pos;

            _count = _createSpeed;
        }
	}
}
