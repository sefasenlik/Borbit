using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1Menu : MonoBehaviour
{
    // Start is called before the first frame update
    public void ResetLevel()
    {
        SceneManager.LoadSceneAsync("Level1");
    }

    public void ExitLevel() {
        SceneManager.LoadSceneAsync("MainMenu");
    }
}
