using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public List<int> dieRolls = new List<int>();
    private GameObject NumberDisplay;
    private GameObject NumberText;
    private GameObject Player_Info;
    private GameObject WonAmountDisplay;
    private GameObject WonAmountText;
    private GameObject DisplayOverlay;
    public int DiceTotal = 0;
    private Button RollDiceButton;
    public int TotalAmountWon = 0;

    private SoundManager SoundManager;

    void Start()
    {
        SoundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();

        NumberDisplay = GameObject.Find("NumberDisplay");
        NumberText = GameObject.Find("NumberText");
        Player_Info = GameObject.Find("Player_Info");
        RollDiceButton = GameObject.Find("RollDice").GetComponent<Button>();
        WonAmountDisplay = GameObject.Find("WonAmountDisplay");
        WonAmountText = GameObject.Find("WonAmountText");
        DisplayOverlay = GameObject.Find("DisplayOverlay");

        DisplayOverlay.SetActive(false);
        NumberDisplay.SetActive(false);
        WonAmountDisplay.SetActive(false);
    }

    public IEnumerator DisplayWinNumber()
    {
        RollDiceButton.interactable = false;
        yield return new WaitForSeconds(2f);
        DisplayWinners();

        NumberText.GetComponent<TextMeshProUGUI>().text = DiceTotal.ToString();
        WonAmountText.GetComponent<TextMeshProUGUI>().text = "$" + TotalAmountWon.ToString();
        NumberDisplay.SetActive(true);
        WonAmountDisplay.SetActive(true);
        yield return new WaitForSeconds(3f);

        NumberDisplay.SetActive(false);
        WonAmountDisplay.SetActive(false);
        
        yield return new WaitForSeconds(1f);
        Debug.Log("TotalWon: " + TotalAmountWon);
        Player_Info.GetComponent<Player_Information>().AmountOfMoney += TotalAmountWon;
        UpdatePlayerInfo();
        if(Player_Info.GetComponent<Player_Information>().AmountOfMoney <= 0)
        {
            DisplayOverlay.SetActive(true);
        }
        NextGame();
        yield return new WaitForSeconds(1f);
        RollDiceButton.interactable = true;
    }

    public void UpdatePlayerInfo()
    {
        GameObject MoneyLeft = GameObject.Find("MoneyLeft");
        GameObject TotalBetAmount = GameObject.Find("TotalBetAmount");
        
        MoneyLeft.GetComponent<TextMeshProUGUI>().text = "$" + Player_Info.GetComponent<Player_Information>().AmountOfMoney;
        TotalBetAmount.GetComponent<TextMeshProUGUI>().text = "$" + Player_Info.GetComponent<Player_Information>().TotalBetAmount;
    }

    public void CollectDieRolls(int dieRoll)
    {
        dieRolls.Add(dieRoll);
    }


    public void RollTheDice()
    {
        Debug.Log("RollALL");
        DiceTotal = 0;
        dieRolls.Clear();

        GameObject Dice1 = GameObject.Find("Dice_01");
        GameObject Dice2 = GameObject.Find("Dice_02");
        GameObject Dice3 = GameObject.Find("Dice_03");

        Debug.Log(Dice1 + " "+ Dice2 + " " + Dice3);

        Dice1.GetComponent<Dice>().RollDie();
        Dice2.GetComponent<Dice>().RollDie();
        Dice3.GetComponent<Dice>().RollDie();
        
        SoundManager.DiceShuffleSound();

        StartCoroutine(DisplayWinNumber());
    }
    
    public void DisplayWinners()
    {
        Debug.Log(dieRolls[0] + " " + dieRolls[1] + " " + dieRolls[2]);
        GameObject Numbers = GameObject.Find("Numbers");
        foreach (Transform child in Numbers.GetComponentsInChildren<Transform>())
        {
            if(child.gameObject.tag == "Placements_Bet")
            {
                child.GetComponent<Placement_Details>().DisplayWin(dieRolls, DiceTotal);
            }
        }
    }

    public void NextGame()
    {
        GameObject Numbers = GameObject.Find("Numbers");
        foreach (Transform child in Numbers.GetComponentsInChildren<Transform>())
        {
            if(child.gameObject.tag == "Placements_Bet")
            {
                child.GetComponent<Placement_Details>().ResetBet();
            }
        }
        SoundManager.PokerChipSound();
        Player_Info.GetComponent<Player_Information>().TotalBetAmount = 0;
        TotalAmountWon = 0;
        UpdatePlayerInfo();
    }

    public void Rebuy()
    {
        SoundManager.PokerChipSound();
        DisplayOverlay.SetActive(false);
        Player_Info.GetComponent<Player_Information>().AmountOfMoney = 1000; 
        UpdatePlayerInfo();
    }
}
