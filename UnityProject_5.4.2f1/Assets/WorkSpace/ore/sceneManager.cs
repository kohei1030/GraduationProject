using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

using Common;

namespace Common
{
    public static class Define
    {

        public const string TITLE = "title";
        public const string MAIN_GAME = "mainGame";
        public const string GAME_OVER = "GameOver";

        //public const KeyCode SHOT_KEY1 = KeyCode.X;
        //public const KeyCode SHOT_KEY2 = KeyCode.M;
        //public const KeyCode SHOT_KEY3 = KeyCode.UpArrow;
        //public const KeyCode SHOT_KEY4 = KeyCode.Keypad3;

        public const KeyCode SHOT_KEY1 = KeyCode.Z;
        public const KeyCode SHOT_KEY2 = KeyCode.X;
        public const KeyCode SHOT_KEY3 = KeyCode.C;
        public const KeyCode SHOT_KEY4 = KeyCode.V;
    }
}

public class sceneManager : MonoBehaviour
{

    void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void NextScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
