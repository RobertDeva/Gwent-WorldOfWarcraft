using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionMenu : MonoBehaviour
{
    public void PlayMultiplayer()
    {
        SceneManager.LoadScene("Multiplayer Scene");
    }
    public void PlaySinglePlayer()
    {
        SceneManager.LoadScene("Single Player Scene");
    }
    public void CreationMenu()
    {
        SceneManager.LoadScene("Cards & Decks Creation Scene");
    }
}
