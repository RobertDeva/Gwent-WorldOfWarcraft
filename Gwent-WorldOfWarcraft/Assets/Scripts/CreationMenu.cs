using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreationMenu : MonoBehaviour
{
    public AudioSource Creation;
    public GameObject CardCreationMenu;
    public GameObject DeckCreationMenu;
    public GameObject LeaderCreationMenu;
    

    public void CreateCards()
    {
        CardCreationMenu.transform.position = CardCreationMenu.transform.parent.position;
        CardCreationMenu.SetActive(true);
    }
    public void CreateDecks()
    {
        DeckCreationMenu.transform.position = DeckCreationMenu.transform.parent.position;
        DeckCreationMenu.SetActive(true);
    }
    public void CreateLeaders()
    {
        LeaderCreationMenu.transform.position = LeaderCreationMenu.transform.parent.position;
        LeaderCreationMenu.SetActive(true);
    }
    public void Exit()
    {
        SceneManager.LoadScene("Transition Scene");
    }
}
