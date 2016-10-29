using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    
    [SerializeField]
    int _playerHp = 1;


	void Start () {
        _playerHp = 1;
	}
	
	void Update () {
        if (_playerHp <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.tag == "Enemy") {
            _playerHp -= 1;

        }

      
    }

}
