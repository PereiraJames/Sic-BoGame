using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player_Information : MonoBehaviour
{
    public int AmountOfMoney;
    public int TotalBetAmount = 0;
    public int CurrentBetSize = 1;

    //Actionsf
    public bool IsBetting;
    
    void Start()
    {
        AmountOfMoney = 1000;
    }

    public void bet_1()
    {
        if(AmountOfMoney < 1){return;}

        CurrentBetSize = 1;
    }

    public void bet_5()
    {
        if(AmountOfMoney < 5){return;}

        CurrentBetSize = 5;
    }

    public void bet_25()
    {
        if(AmountOfMoney < 25){return;}

        CurrentBetSize = 25;
    }

    public void bet_50()
    {
        if(AmountOfMoney < 50){return;}

        CurrentBetSize = 50;
    }

    public void bet_100()
    {
        if(AmountOfMoney < 100){return;}

        CurrentBetSize = 100;
        Debug.Log("Bet 100");
    }
}
