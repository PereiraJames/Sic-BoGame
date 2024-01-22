using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;


public class Placement_Details : MonoBehaviour, IPointerClickHandler
{
    private GameObject Player_Info;
    private GameManager GameManager;
    public int AmountBet = 0;
    public int PayOutAmount = 2;
    public bool isDouble = false;
    public bool isSingle = false;
    public bool isBig = false;
    public bool isSmall = false;
    public bool isTriple = false;
    public bool isSingleSingle = false;
    public bool isDoubleDouble = false;
    public bool isAllTriple = false;

    public bool hasBet = false;

    public bool isWinning = false;
    
    public int SingleNumber = 0;
    public int SingleSingleNumber = 0;
    public int DoubleDoubleNumber1 = 0;
    public int DoubleDoubleNumber2 = 0;
    public int TripleNumber = 0;
    private GameObject chip;
    private GameObject chipAmount;
    

    void Start()
    {
        foreach (Transform child in gameObject.GetComponentsInChildren<Transform>())
        {
            Debug.Log(child);
            if(child.gameObject.name == "Chip")
            {
                chip = child.gameObject;
            }
            else if(child.gameObject.name == "ChipAmount")
            {
                chipAmount = child.gameObject;
            }
            
        }
        chip.SetActive(false);
        Player_Info = GameObject.Find("Player_Info");
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void ClearBet()
    {
        gameObject.GetComponent<Image>().color = Color.white;
        chip.SetActive(false);
        Player_Info.GetComponent<Player_Information>().AmountOfMoney += AmountBet;
        Player_Info.GetComponent<Player_Information>().TotalBetAmount -= AmountBet;
        AmountBet = 0;
        hasBet = false;
        GameManager.UpdatePlayerInfo();
    }

    public void ResetBet()
    {
        gameObject.GetComponent<Image>().color = Color.white;
        chip.SetActive(false);
        AmountBet = 0;
        hasBet = false;
        GameManager.UpdatePlayerInfo();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        int CurrentBetSize = Player_Info.GetComponent<Player_Information>().CurrentBetSize;
        int CurrentAmountOfMoney = Player_Info.GetComponent<Player_Information>().AmountOfMoney;
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            if(CurrentBetSize == 0 || CurrentAmountOfMoney < CurrentBetSize){return;}
            Player_Info.GetComponent<Player_Information>().AmountOfMoney -= CurrentBetSize;
            Player_Info.GetComponent<Player_Information>().TotalBetAmount += CurrentBetSize;
            AmountBet += CurrentBetSize;
            hasBet = true;
            chip.SetActive(true);
            chipAmount.GetComponent<TextMeshProUGUI>().text = AmountBet.ToString();
            Debug.Log("Bet " + CurrentBetSize + " on " + gameObject);
            GameManager.UpdatePlayerInfo();
        }
        else if(eventData.button == PointerEventData.InputButton.Right)
        {
            if(CurrentBetSize == 0){return;}
            ClearBet();
        }
    }

    public void PayOut()
    {
        gameObject.GetComponent<Image>().color = Color.yellow;
        if(!hasBet){return;}
        Debug.Log("Paid Out: " + gameObject);
        int PaidAmount = AmountBet * PayOutAmount;
        GameManager.TotalAmountWon += PaidAmount;
        Debug.Log("Won: " + PaidAmount);
        GameManager.UpdatePlayerInfo();
    }


    public void DisplayWin(List<int> dieRolls, int DiceTotal)
    {
        if(isDouble)
        {
            for (int i = 0; i < 3; i++)
            {
                int elementToCount = dieRolls[i];
                int count = dieRolls.Count(x => x == elementToCount);
                if(count >= 2)
                {
                    PayOut();
                }
            }
        }
        else if(isSingle)
        {
            if(DiceTotal == SingleNumber)
            {
                PayOut();
            }
        }
        else if(isSingleSingle)
        {
            if(dieRolls.Contains(SingleSingleNumber))
            {
                for (int i = 0; i < 3; i++)
                {
                    if(dieRolls[i] == SingleSingleNumber)
                    {
                        PayOut();
                    }
                }
            }
        }
        else if(isDoubleDouble)
        {
            if(dieRolls.Contains(DoubleDoubleNumber1) && dieRolls.Contains(DoubleDoubleNumber2))
            {
                PayOut();
            }
        }
        else if(isTriple)
        {
            for (int i = 0; i < 3; i++)
            {
                if(dieRolls[i] != TripleNumber)
                {
                    return;
                }
            }
            PayOut();
        }
        else if(DiceTotal >= 11 && isBig)
        {
            PayOut();
        }
        else if(DiceTotal < 11 && isSmall)
        {
            PayOut();
        }
        else if (isAllTriple)
        {
            int number = dieRolls[0];
            for (int i = 0; i < 3; i++)
            {
                if(dieRolls[i] != number)
                {
                    return;
                }
            }
            PayOut();
        }
    }

    // public void BetType()
    // {
    //     if(isDouble)
    //     {
            
    //         PayOut(12);
    //     }
    //     else if(isSingle)
    //     {
    //         PayOut();
    //         if(SingleNumber == 4 || SingleNumber == 17)
    //         {
    //             PayOut(61);
    //         }
    //         else if(SingleNumber == 5 || SingleNumber == 16)
    //         {
    //             Payout(21);
    //         }
    //         else if(SingleNumber == 6 || SingleNumber == 15)
    //         {
    //             PayOut(19);
    //         }
    //         else if(SingleNumber == 7 || SingleNumber == 14)
    //         {
    //             Payout(13);
    //         }
    //         else if(SingleNumber == 8 || SingleNumber == 13)
    //         {
    //             PayOut(9);
    //         }
    //         else if(SingleNumber == 9 || SingleNumber == 10 || SingleNumber == 11 || SingleNumber == 12)
    //         {
    //             PayOut(7);
    //         }

    //     }
    //     else if(isSingleSingle)
    //     {
    //         //For each dice shown needs to repeat
    //         PayOut(2);
    //     }
    //     else if(isDoubleDouble)
    //     {
    //         PayOut(7);
    //     }
    //     else if(isTriple)
    //     {
    //         PayOut(181);
    //     }
    //     else if(isBigSmall)
    //     {
    //         PayOut(2);
    //     }
    //     else if (isAllTriple)
    //     {
    //         PayOut(30);
    //     }
    // }
}
