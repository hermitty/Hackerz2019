using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadGameScene()
    {
        SceneManager.LoadScene("Game"); // 
        FindObjectOfType<GameSession>().ResetGame();
    }
    public void LoadGameOverScene()
    {
        SceneManager.LoadScene("GameOver"); // 
    }
    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void StartMenu()
    {
        SceneManager.LoadScene("Menu"); //
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
