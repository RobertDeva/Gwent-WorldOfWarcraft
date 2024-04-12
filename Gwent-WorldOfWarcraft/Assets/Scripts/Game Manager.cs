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
        Invoke(nameof(Play), 3.0f);
    }
    //This method mark the begin of a new round
    public void BeginRound()
    { if (Round3End == false)
            Round.text = "Begins a new round";
    }
    //This method show what round is playing
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

    //This method check what player is playing
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

   
    //This method finish the round
    public void EndRound()
    {
        if (P1.GetComponent<Player>().Passed && P2.GetComponent<Player>().Passed)
        {
            if (GameObject.Find("LeaderP1").GetComponent<LeaderCardDisplay>().WheaterCasted || GameObject.Find("LeaderP2").GetComponent<LeaderCardDisplay>().WheaterCasted)
            {
                if (GameObject.Find("LeaderP1").GetComponent<LeaderCardDisplay>().WheaterCasted)
                {
                    GameObject.Find("LeaderP1").GetComponent<LeaderCardDisplay>().LeaderEffect();
                    GameObject.Find("LeaderP1").GetComponent<LeaderCardDisplay>().WheaterCasted = false;
                }
                else
                {
                    GameObject.Find("LeaderP2").GetComponent<LeaderCardDisplay>().LeaderEffect();
                    GameObject.Find("LeaderP2").GetComponent<LeaderCardDisplay>().WheaterCasted = false;
                }
            }
            foreach(Transform card in GameObject.Find("MeleeZoneClima").transform)
            {
                card.GetComponent<CardDisplay>().CastEffect();
            }
            foreach (Transform card in GameObject.Find("RangeZoneClima").transform)
            {
                card.GetComponent<CardDisplay>().CastEffect();
            }
            foreach (Transform card in GameObject.Find("SiegeZoneClima").transform)
            {
                card.GetComponent<CardDisplay>().CastEffect();
            }

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
                Invoke(nameof(CheckWinner), 3.0f);
                RoundIndex++;
            }
            else
            {
                SetRoundResults();
                Invoke(nameof(CheckWinner), 3.0f);
            }
            GameObject.Find("DeckP1").GetComponent<Draw>().EffectDraw();
            GameObject.Find("DeckP2").GetComponent<Draw>().EffectDraw();
            GameObject.Find("DeckP1").GetComponent<Draw>().EffectDraw();
            GameObject.Find("DeckP2").GetComponent<Draw>().EffectDraw();
            P1.GetComponent<Player>().Passed = false;
            P2.GetComponent<Player>().Passed = false;
            P1Turn = false;
            P2Turn = false;
            Invoke(nameof(CleanField), 1.0f);
        }
    }
    //This method checks who won the round
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
    //This method checks who won the game
    public void CheckWinner()
    {
        if (Round3End == false)
        {
            if (VictoriesP1 >= 2 || VictoriesP2 >= 2)
            {
                if (VictoriesP1 > VictoriesP2)
                {
                    Round.text = "Player 1 wins the game";
                    Invoke(nameof(EngGame), 5.0f);
                }
                else if (VictoriesP1 < VictoriesP2)
                {
                    Round.text = "Player 2 wins the game";
                    Invoke(nameof(EngGame), 5.0f);
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
                Invoke(nameof(EngGame), 5.0f);
            }

        }
    }
    //This method jump to the previous Scene
    public void EngGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    //This method start the round
    public void Play()
    {
        if(Round1Playing == false || (Round2Playing == false && Round1End) || (Round3Playing == false && Round2End))
        {
            BeginRound();
            Invoke(nameof(CheckRound), 2.0f);
        }
        
    }

    //This method switch to  other player turn
    public void P1Pass()
    { 
        if (P1.GetComponent<Player>().IsPlaying)
        {
            P1start = false;
            P1.GetComponent<Player>().IsPlaying = false;
            if (P1.GetComponent<Player>().Played == false)
                P1.GetComponent<Player>().Passed = true;
            P1.GetComponent<Player>().Played = false;
            P1Turn = false;
            P2Turn = true;
            Turn.text = "P2 Turn";
        }
    }
    //This method switch to  other player turn
    public void P2Pass()
    {
        if (P2.GetComponent<Player>().IsPlaying)
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
    //This method clean the field after finish the round
    public void CleanField()
    {
        GameObject CementeryP1 = GameObject.Find("CementeryP1");
        GameObject CementeryP2 = GameObject.Find("CementeryP2");
        GameObject MeleeP1 = GameObject.Find("MeleeZoneP1");
        GameObject MeleeP2 = GameObject.Find("MeleeZoneP2");
        GameObject RangeP1 = GameObject.Find("RangeZoneP1");
        GameObject RangeP2 = GameObject.Find("RangeZoneP2");
        GameObject SiegeP1 = GameObject.Find("SiegeZoneP1");
        GameObject SiegeP2 = GameObject.Find("SiegeZoneP2");
        GameObject MeleeWheather = GameObject.Find("MeleeZoneClima");
        GameObject RangeWheather = GameObject.Find("RangeZoneClima");
        GameObject SiegeWheather = GameObject.Find("SiegeZoneClima");

        foreach(Transform card in MeleeP1.transform)
        {
            if(card.GetComponent<CardDisplay>().BondInField == false)
            {
                card.SetParent(CementeryP1.transform);
                card.gameObject.SetActive(false);
            }
        }
        foreach (Transform card in MeleeP2.transform)
        {
            if (card.GetComponent<CardDisplay>().BondInField == false)
            {
                card.SetParent(CementeryP2.transform);
                card.gameObject.SetActive(false);
            }
        }
        foreach (Transform card in RangeP1.transform)
        {
            if (card.GetComponent<CardDisplay>().BondInField == false)
            {
                card.SetParent(CementeryP1.transform);
                card.gameObject.SetActive(false);
            }
        }
        foreach (Transform card in RangeP2.transform)
        {
            if (card.GetComponent<CardDisplay>().BondInField == false)
            {
                card.SetParent(CementeryP2.transform);
                card.gameObject.SetActive(false);
            }
        }
        foreach (Transform card in SiegeP1.transform)
        {
            if (card.GetComponent<CardDisplay>().BondInField == false)
            {
                card.SetParent(CementeryP1.transform);
                card.gameObject.SetActive(false);
            }
        }
        foreach (Transform card in SiegeP2.transform)
        {
            if (card.GetComponent<CardDisplay>().BondInField == false)
            {
                card.SetParent(CementeryP2.transform);
                card.gameObject.SetActive(false);
            }
        }
        foreach (Transform card in MeleeWheather.transform)
        {
            if (card.GetComponent<CardDisplay>().BondInField == false)
            {
                card.SetParent(CementeryP1.transform);
                card.gameObject.SetActive(false);
            }
        }
        foreach (Transform card in RangeWheather.transform)
        {
            if (card.GetComponent<CardDisplay>().BondInField == false)
            {
                card.SetParent(CementeryP1.transform);
                card.gameObject.SetActive(false);
            }
        } foreach(Transform card in SiegeWheather.transform)
        {
            if(card.GetComponent<CardDisplay>().BondInField == false)
            {
                card.SetParent(CementeryP1.transform);
                card.gameObject.SetActive(false);
            }
        }
    }

   
}

