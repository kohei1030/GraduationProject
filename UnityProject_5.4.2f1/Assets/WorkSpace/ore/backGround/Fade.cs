using UnityEngine;
using System.Collections;

public class Fade : MonoBehaviour {

    private Renderer _renderer;
    float addVal = 1;
    int fadeCount = 0;

	void Start () {
        _renderer = GetComponent<Renderer>();
	}

    public int PlayFade()
    {
        _renderer.material.color += new Color(0, 0, 0, 0.04f * addVal);
        if (_renderer.material.color.a >= 0.5) addVal *= -1;
        else if (_renderer.material.color.a <= 0)
        {
            addVal *= -1;
            fadeCount++;
        }
        return fadeCount;
    }
}
