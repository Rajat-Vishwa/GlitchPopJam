using UnityEngine.SceneManagement;
using UnityEngine;

public class IntroLevel : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return)){
            SceneManager.LoadScene("Level 1");
        }
    }
}
