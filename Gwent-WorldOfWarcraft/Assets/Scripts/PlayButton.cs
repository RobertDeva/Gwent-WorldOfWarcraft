using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public AudioSource PlayGame;
    public AudioSource TransitionTrack;

    private void Start()
    {
       // TransitionTrack.Play();
    }
    public void Play()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
   
}
