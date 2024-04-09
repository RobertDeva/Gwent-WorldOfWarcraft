using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameTracker : MonoBehaviour
{
    public bool start = false;
    private bool Round1Playing = false;
    private bool Round2Playing = false;
    private bool Round3Playing = false;
    bool FirstPlayerTurn;
    bool SecondPlayerTurn;
    GameObject P1;
    GameObject P2;
    GameObject RoundTracker;
    RoundResult [] ResultsP1 = new RoundResult [3];
    RoundResult [] ResultsP2 = new RoundResult [3];
    int VictoriesP1 = 0;
    int VictoriesP2 = 0;
    public TMP_Text Turn;
    public TMP_Text Round;
    public TMP_Text P1FirstResult;
    public TMP_Text P2FirstResult;
    public TMP_Text P1SecondResult;
    public TMP_Text P2SecondResult;
    public TMP_Text P1LastResult;
    public TMP_Text P2LastResult;
    

    GameObject FirstPlayer;
    GameObject SecondPlayer;

    // Start is called before the first frame update
    void Start()
    {
        P1 = GameObject.Find("Player1");
        FirstPlayer = P1;
        P2 = GameObject.Find("Player2");
        SecondPlayer = P2;
        RoundTracker = GameObject.Find("RoundTracker");
        start = true;
    }
    public void Play()
    {
      while(start == true)
      {     
            Round1Playing = true;
            PlayRound();
            SetResults(0);
            P1FirstResult.text = ResultsP1[0].ToString();
            P2FirstResult.text = ResultsP2[0].ToString();
            Round2Playing = true;
            PlayRound();
            SetResults(1);
            P1SecondResult.text = ResultsP1[1].ToString();
            P2SecondResult.text = ResultsP2[1].ToString();

            if(VictoriesP1 == 2 && VictoriesP2 != 2)
            {
                Round.text = "Player 1 Wins";               
                start = false;               
            }
            else if(VictoriesP1 != 2 && VictoriesP2 == 2)
            {
                Round.text = "Player 2 Wins";               
                start = false;              
            }
            Round3Playing = true;
            PlayRound();
            SetResults(2);
            P1LastResult.text = ResultsP1[2].ToString();
            P2LastResult.text = ResultsP2[2].ToString();
            if(VictoriesP1 == VictoriesP2)
            {
                Round.text = "Nobody Wins";
                start = false;
            }
            else if(VictoriesP1 > VictoriesP2)
            {
                Round.text = "Player 1 Wins";               
                start = false;              
            }
            else if(VictoriesP1 < VictoriesP2)
            {
                Round.text = "Player 2 Wins";
                start = false;              
            }
      }
    }
    public enum RoundResult
    {
        W,
        L,
        T,
    }
    
    public void StartRound()
    {
        
       Round.text = "New Round Begins";
      
    }
    public void CheckRound()
    {
        if(Round1Playing || Round2Playing || Round3Playing)
        {
            if(Round1Playing && Round2Playing && Round3Playing)
            {
                Round.text = "Round 3";
            }
            else if(Round1Playing && Round2Playing)
            {
                Round.text = "Round 2";
            }
            else if(Round1Playing)
            {
                Round.text = "Round1";
            }
        }
    }
    public void ContinueRound()
    {
        Round.text = "";
    }
    public void PlayRound()
    {
        Invoke(nameof(StartRound), 1.0f);
        Invoke(nameof(CheckRound), 1.0f);
        Invoke(nameof(ContinueRound), 1.0f);
       
        while(P1.GetComponent<Player>().Passed == false && P2.GetComponent<Player>().Passed == false  )
        {
            FirstPlayerTurn = true;
            FirstPlayer.GetComponent<Player>().IsPlaying = true;

            while(FirstPlayer.GetComponent<Player>().IsPlaying == true && FirstPlayer.GetComponent<Player>().Passed == false && SecondPlayerTurn == false)
            {
                if (FirstPlayerTurn == P1)
                    Turn.text = "P1 Turn";
                else
                    Turn.text = "P2 Turn";
            }
            FirstPlayerTurn = false;
            FirstPlayer.GetComponent<Player>().Played = false;
            FirstPlayer.GetComponent <Player>().Drawed = false;
            SecondPlayerTurn = true;
            SecondPlayer.GetComponent<Player>().IsPlaying = true;
            while(SecondPlayer.GetComponent<Player>().IsPlaying == true && SecondPlayer.GetComponent<Player>().Passed == false && FirstPlayerTurn == false)
            {
                if (SecondPlayerTurn == P2)
                    Turn.text = "P2 Turn";
                else
                    Turn.text = "P1 Turn";
            }
            SecondPlayerTurn = false;
            SecondPlayer.GetComponent<Player>().Played = false;
            SecondPlayer.GetComponent <Player>().Drawed = false;
        }
    }
   
    // Method used to define Round winner
    private void SetResults(int x)
    {
        if (x < 3 && x >= 0)
        {
            int PowerP1 = P1.GetComponent<Player>().GetFinalPower();
            int PowerP2 = P2.GetComponent<Player>().GetFinalPower();

            if (PowerP1 == PowerP2)
            {
                ResultsP1[x] = RoundResult.T;
                ResultsP2[x] = RoundResult.T;
                VictoriesP1++;
                VictoriesP2++;
                Round.text = "Round" + " " + x + 1.ToString() + " haven't winner";
                
            }
            else if (PowerP1 > PowerP2)
            {
                ResultsP1[x] = RoundResult.W;
                ResultsP2[x] = RoundResult.L;
                VictoriesP1++;
                Round.text = "Round" + " " + x + 1.ToString() + " Player 1 Wins";
                FirstPlayer = P1;
                SecondPlayer = P2;
            }
            else if (PowerP1 < PowerP2)
            {
                ResultsP1[x] = RoundResult.L;
                ResultsP2[x] = RoundResult.W;
                VictoriesP2++;
                Round.text = "Round" + " " + x + 1.ToString() + " Player 2 Wins";
                FirstPlayer = P2;
                SecondPlayer = P1;
            }
        }
    }

    
}
