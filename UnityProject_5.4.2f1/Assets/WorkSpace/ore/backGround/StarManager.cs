using UnityEngine;
using System.Collections;

public class StarManager : MonoBehaviour {

    [SerializeField]
    private float _maxVal;

    [SerializeField]
    private float _speed;

    [SerializeField]
    private float _dispTime;

    private Vector3 addVal;

	void Start () {
        transform.localScale = new Vector3(0.0f, 0.0f, 1.0f);
        addVal = new Vector3(_speed, _speed, 0.0f);
	}
	
	void Update () {
        transform.localScale += addVal;

        if (transform.localScale.x > _maxVal || transform.localScale.x < 0)
        {
            addVal *= -1;
        }

        _dispTime -= Time.deltaTime;
        if (_dispTime <= 0)
        {
            Destroy(this.gameObject);
        }

	}
}
