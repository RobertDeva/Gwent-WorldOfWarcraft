using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool Round1Playing = false;
    bool Round1End = false;
    bool Round2Playing = false;
    bool Round2End = false;
    bool Round3Playing = false;
    bool Round3End = false;
    bool P1Turn = true;
    bool P1start = false;
    bool P2Turn = false;
    bool P2start = false;
    int VictoriesP1;
    int VictoriesP2;
    int RoundIndex = 1;
    GameObject P1;
    GameObject P2;
    RoundResult[] ResultsP1 = new RoundResult[3];
    RoundResult[] ResultsP2 = new RoundResult[3];
    public TMP_Text Round;
    public TMP_Text Turn;
    public TMP_Text Round1ResultsP1;
    public TMP_Text Round1ResultsP2;
    public TMP_Text Round2ResultsP1;
    public TMP_Text Round2ResultsP2;
    public TMP_Text Round3ResultsP1;
    public TMP_Text Round3ResultsP2;

    public enum RoundResult
    {
        W,
        L,
        T
    }

    // Start is called before the first frame update
    void Start()
    {
        P1 = GameObject.Find("Player1");
        P2 = GameObject.Find("Player2");
        VictoriesP1 = 0;
        VictoriesP2 = 0;
        Play(); 
        P1start = true;
        P2start = false;
    }

    private void Update()
    {
        Turns();
        EndRound();
        Invoke(nameof(Play), 5.0f);
    }
    public void BeginRound()
    { if (Round3End == false)
            Round.text = "Begins a new round";
    }
    public void CheckRound()
    {
        if (Round1Playing == false)
        {
            Round.text = "Round 1";
            Round1Playing = true;
        }
        else if (Round2Playing == false && Round1End == true)
        {
            Round.text = "Round 2";
            Round2Playing = true;
        }
        else if (Round3Playing == false && Round2End == true)
        {
            Round.text = "Round 3";
            Round3Playing = true;
        }
    }

    public void Turns()
    {
        if (!P1.GetComponent<Player>().Passed && !P2.GetComponent<Player>().Passed)
        {
            if((P1Turn && !P1.GetComponent<Player>().Passed && !P2Turn) || (P1start && !P1.GetComponent<Player>().Passed) || (!P1.GetComponent<Player>().Passed && P2.GetComponent<Player>().Passed))
            {
                P2.GetComponent<Player>().Drawed = false;
                Turn.text = "P1 Turn";
                if (!P1.GetComponent<Player>().Played)
                     P1.GetComponent<Player>().IsPlaying = true;
                P1start = false;
            }
            if ((P2Turn && !P2.GetComponent<Player>().Passed && !P1Turn) || (P2start && !P2.GetComponent<Player>().Passed) || (!P2.GetComponent<Player>().Passed && P1.GetComponent<Player>().Passed))
            {
                P1.GetComponent<Player>().Drawed = false;
                Turn.text = "P2 Turn";
                if (!P2.GetComponent<Player>().Played)
                    P2.GetComponent<Player>().IsPlaying = true;
               
                P2start = false;
            }
        }
    }

   

    public void EndRound()
    {
        if (P1.GetComponent<Player>().Passed && P2.GetComponent<Player>().Passed)
        {

            if (Round1End == false)
            {
                Round1End = true;
                SetRoundResults();
                RoundIndex++;
            }
            else if (Round2End == false)
            {
                Round2End = true;
                SetRoundResults();
                CheckWinner();
                RoundIndex++;
            }
            else
            {
                SetRoundResults();
                CheckWinner();
            }
            P1.GetComponent<Player>().Passed = false;
            P2.GetComponent<Player>().Passed = false;
            P1Turn = false;
            P2Turn = false;
            GameObject.Find("DeckP1").GetComponent<Draw>().OnClick();
            GameObject.Find("DeckP2").GetComponent<Draw>().OnClick();
            GameObject.Find("DeckP1").GetComponent<Draw>().OnClick();
            GameObject.Find("DeckP2").GetComponent<Draw>().OnClick();
        }
    }

    public void SetRoundResults()
    {
        if (RoundIndex == 1)
        {
            int PowerP1 = P1.GetComponent<Player>().GetFinalPower();
            int PowerP2 = P2.GetComponent<Player>().GetFinalPower();
            if (PowerP1 > PowerP2)
            {
                Round1ResultsP1.text = RoundResult.W.ToString();
                ResultsP1[RoundIndex - 1] = RoundResult.W;
                Round1ResultsP2.text = RoundResult.L.ToString();
                ResultsP2[RoundIndex - 1] = RoundResult.L;
                VictoriesP1++;
                Round.text = "Player 1 wins the round";
                P1start = true;
                P2start = false;
            }
            else if (PowerP1 < PowerP2)
            {

                Round1ResultsP1.text = RoundResult.L.ToString();
                ResultsP1[RoundIndex - 1] = RoundResult.L;
                Round1ResultsP2.text = RoundResult.W.ToString();
                ResultsP2[RoundIndex - 1] = RoundResult.W;
                VictoriesP2++;
                Round.text = "Player 2 wins the round";
                P1start = false;
                P2start = true;
            }
            else if (PowerP1 == PowerP2)
            {

                Round1ResultsP1.text = RoundResult.T.ToString();
                ResultsP1[RoundIndex - 1] = RoundResult.T;
                Round1ResultsP2.text = RoundResult.T.ToString();
                ResultsP2[RoundIndex - 1] = RoundResult.T;
                VictoriesP1++;
                VictoriesP2++;
                Round.text = "Nobody wins the round";
            }
        }
        else if (RoundIndex == 2)
        {
            int PowerP1 = P1.GetComponent<Player>().GetFinalPower();
            int PowerP2 = P2.GetComponent<Player>().GetFinalPower();
            if (PowerP1 > PowerP2)
            {
                Round1ResultsP1.text = RoundResult.W.ToString();
                ResultsP1[RoundIndex - 1] = RoundResult.W;
                Round1ResultsP2.text = RoundResult.L.ToString();
                ResultsP2[RoundIndex - 1] = RoundResult.L;
                VictoriesP1++;
                Round.text = "Player 1 wins the round";
                P1start = true;
                P2start = false;
            }
            else if (PowerP1 < PowerP2)
            {

                Round1ResultsP1.text = RoundResult.L.ToString();
                ResultsP1[RoundIndex - 1] = RoundResult.L;
                Round1ResultsP2.text = RoundResult.W.ToString();
                ResultsP2[RoundIndex - 1] = RoundResult.W;
                VictoriesP2++;
                Round.text = "Player 2 wins the round";
                P1start = false;
                P2start = true;
            }
            else if (PowerP1 == PowerP2)
            {

                Round1ResultsP1.text = RoundResult.T.ToString();
                ResultsP1[RoundIndex - 1] = RoundResult.T;
                Round1ResultsP2.text = RoundResult.T.ToString();
                ResultsP2[RoundIndex - 1] = RoundResult.T;
                VictoriesP1++;
                VictoriesP2++;
                Round.text = "Nobody wins the round";
            }
        }
        else if (RoundIndex == 3)
        {
            int PowerP1 = P1.GetComponent<Player>().GetFinalPower();
            int PowerP2 = P2.GetComponent<Player>().GetFinalPower();
            if (PowerP1 > PowerP2)
            {
                Round1ResultsP1.text = RoundResult.W.ToString();
                ResultsP1[RoundIndex - 1] = RoundResult.W;
                Round1ResultsP2.text = RoundResult.L.ToString();
                ResultsP2[RoundIndex - 1] = RoundResult.L;
                VictoriesP1++;
                Round.text = "Player 1 wins the round";
                P1start = true;
                P2start = false;
            }
            else if (PowerP1 < PowerP2)
            {

                Round1ResultsP1.text = RoundResult.L.ToString();
                ResultsP1[RoundIndex - 1] = RoundResult.L;
                Round1ResultsP2.text = RoundResult.W.ToString();
                ResultsP2[RoundIndex - 1] = RoundResult.W;
                VictoriesP2++;
                Round.text = "Player 2 wins the round";
                P1start = false;
                P2start = true;
            }
            else if (PowerP1 == PowerP2)
            {

                Round1ResultsP1.text = RoundResult.T.ToString();
                ResultsP1[RoundIndex - 1] = RoundResult.T;
                Round1ResultsP2.text = RoundResult.T.ToString();
                ResultsP2[RoundIndex - 1] = RoundResult.T;
                VictoriesP1++;
                VictoriesP2++;
                Round.text = "Nobody wins the round";
            }
        }
    }

    public void CheckWinner()
    {
        if (Round3End == false)
        {
            if (VictoriesP1 >= 2 || VictoriesP2 >= 2)
            {
                if (VictoriesP1 > VictoriesP2)
                {
                    Round.text = "Player 1 wins the game";
                    Invoke(nameof(EngGame), 3.0f);
                }
                else if (VictoriesP1 < VictoriesP2)
                {
                    Round.text = "Player 2 wins the game";
                    Invoke(nameof(EngGame), 3.0f);
                }
            }
        }
        else
        {
            if (VictoriesP1 >= 2 || VictoriesP2 >= 2)
            {
                if (VictoriesP1 > VictoriesP2)
                {
                    Round.text = "Player 1 wins the game";
                    
                }
                else if (VictoriesP1 < VictoriesP2)
                {
                    Round.text = "Player 2 wins the game";
                    
                }
                else
                {
                    Round.text = "Nobody wins the game";
                    
                }
                Invoke(nameof(EngGame), 3.0f);
            }

        }
    }

    public void EngGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void Play()
    {
        if(Round1Playing == false || (Round2Playing == false && Round1End) || (Round3Playing == false && Round2End))
        {
            BeginRound();
            Invoke(nameof(CheckRound), 2.0f);
        }
        
    }

    public void P1Pass()
    {
        P1start = false;
        P1.GetComponent<Player>().IsPlaying = false;
        if(P1.GetComponent<Player>().Played == false)
            P1.GetComponent<Player>().Passed = true;
        P1.GetComponent<Player>().Played = false;
        P1Turn = false;
        P2Turn = true;
        Turn.text = "P2 Turn";
    }
    public void P2Pass()
    {   
        P2start = false;
        P2.GetComponent<Player>().IsPlaying = false;
        if (P2.GetComponent<Player>().Played == false)
            P2.GetComponent<Player>().Passed = true;
        P2.GetComponent<Player>().Played = false;
        P2Turn = false;
        P1Turn = true;
        Turn.text = "P1 Turn";
    }

}

