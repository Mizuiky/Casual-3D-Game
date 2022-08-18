using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Utils
{
    public class SceneLoader : MonoBehaviour
    {
        public void LoadSceneByName(string name)
        {
            SceneManager.LoadScene(name);
        }

        public void LoadSceneByNumber(int sceneNumber)
        {
            SceneManager.LoadScene(sceneNumber);
        }
    }
}

