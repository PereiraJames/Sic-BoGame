using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player_Information : MonoBehaviour
{
    public int AmountOfMoney;
    public int TotalBetAmount = 0;
    public int DiceTotal = 0;
    private GameObject NumberDisplay;
    private GameObject NumberText;
    
    void Start()
    {
        NumberDisplay = GameObject.Find("NumberDisplay");
        NumberText = GameObject.Find("NumberText");
        NumberDisplay.SetActive(false);
        AmountOfMoney = 1000;
    }

    private void bet_1()
    {
        if(AmountOfMoney < 1){return;}

        AmountOfMoney -= 1;
        TotalBetAmount += 1;
    }

    private void bet_5()
    {
        if(AmountOfMoney < 5){return;}

        AmountOfMoney -= 5;
        TotalBetAmount += 5;
    }

    private void bet_25()
    {
        if(AmountOfMoney < 25){return;}

        AmountOfMoney -= 25;
        TotalBetAmount += 25;
    }

    private void bet_50()
    {
        if(AmountOfMoney < 50){return;}

        AmountOfMoney -= 50;
        TotalBetAmount += 50;
    }

    private void bet_100()
    {
        if(AmountOfMoney < 100){return;}

        AmountOfMoney -= 100;
        TotalBetAmount += 100;
    }

    public void RollTheDice()
    {
        Debug.Log("RollALL");
        GameObject Player_Info = GameObject.Find("Player_Info");
        Player_Info.GetComponent<Player_Information>().DiceTotal = 0;

        GameObject Dice1 = GameObject.Find("Dice_01");
        GameObject Dice2 = GameObject.Find("Dice_02");
        GameObject Dice3 = GameObject.Find("Dice_03");

        Debug.Log(Dice1 + " "+ Dice2 + " " + Dice3);

        Dice1.GetComponent<Dice>().RollDie();
        Dice2.GetComponent<Dice>().RollDie();
        Dice3.GetComponent<Dice>().RollDie();

        StartCoroutine(DisplayWinNumber());
    }

    public IEnumerator DisplayWinNumber()
    {
        yield return new WaitForSeconds(2f);

        NumberText.GetComponent<TextMeshProUGUI>().text = DiceTotal.ToString();
        NumberDisplay.SetActive(true);

        yield return new WaitForSeconds(3f);

        NumberDisplay.SetActive(false);
    }
}
