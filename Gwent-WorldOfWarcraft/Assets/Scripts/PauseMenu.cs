using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    GameObject OptionsMenu;
    // Start is called before the first frame update
    void Start()
    {
        OptionsMenu = GameObject.Find("Options Menu");
        transform.gameObject.SetActive(false);
        OptionsMenu.SetActive(false);
    }

    public void Resume()
    {
        transform.gameObject.SetActive(false);
    }
    public void Pause()
    {
        transform.gameObject.SetActive(true);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Exit()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void Options()
    {
        OptionsMenu.SetActive(true);
    }
}