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

    private SoundManager SoundManager;

    void Start()
    {
        SoundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        AmountOfMoney = 1000;
    }

    public void bet_1()
    {
        if(AmountOfMoney < 1){return;}
        SoundManager.PokerChipSound();
        CurrentBetSize = 1;
    }

    public void bet_5()
    {
        if(AmountOfMoney < 5){return;}
        SoundManager.PokerChipSound();
        CurrentBetSize = 5;
    }

    public void bet_25()
    {
        if(AmountOfMoney < 25){return;}
        SoundManager.PokerChipSound();
        CurrentBetSize = 25;
    }

    public void bet_50()
    {
        if(AmountOfMoney < 50){return;}
        SoundManager.PokerChipSound();
        CurrentBetSize = 50;
    }

    public void bet_100()
    {
        if(AmountOfMoney < 100){return;}
        SoundManager.PokerChipSound();
        CurrentBetSize = 100;
        Debug.Log("Bet 100");
    }
}
