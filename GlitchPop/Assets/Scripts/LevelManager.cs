using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject player, pauseMenu, gameOverMenu;
    public bool isPaused;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        if(player.GetComponent<CombatSystem>().stats.alive == false){
            GameOver();
        }
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(!isPaused) Pause();
            else Resume();
        }

        if(GameObject.FindGameObjectWithTag("Enemy") == null){
            LevelClear();
        }
    }

    public void Pause(){
        Time.timeScale = 0;
        isPaused = true;
        pauseMenu.SetActive(true);
    }

    public void Resume(){
        Time.timeScale = 1;
        isPaused = false;
        pauseMenu.SetActive(false);
    }

    public void GameOver(){
        Time.timeScale = 0;
        gameOverMenu.SetActive(true);
    }

    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Resume();
    }

    public void Menu(){
        SceneManager.LoadScene(0);
    }

    public void LevelClear(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
