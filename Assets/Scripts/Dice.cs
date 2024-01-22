using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Dice : MonoBehaviour
{
    public Sprite Side1;
    public Sprite Side2;
    public Sprite Side3;
    public Sprite Side4;
    public Sprite Side5;
    public Sprite Side6;

    private int RolledValue = 0;
    public GameManager GameManager;

    void Start()
    {
        gameObject.GetComponent<Image>().sprite = Side6;
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void RollDie()
    {
        // GameManager.dieRolls.Add(5);
        // GameManager.dieRolls.Add(1);
        // GameManager.dieRolls.Add(2);

        StartCoroutine(DieRolling());
    }

    public IEnumerator DieRolling()
    {
        Debug.Log("Rolling");
        for (int i = 0; i <= 20; i++)
        {
            RolledValue = Random.Range(1, 6);
            DisplayDice(RolledValue);
            yield return new WaitForSeconds(0.05f);
        }
        GameManager.DiceTotal += RolledValue;
        GameManager.dieRolls.Add(RolledValue);
    }

    private void DisplayDice(int RolledValue)
    {
        if(RolledValue == 1)
        {
            gameObject.GetComponent<Image>().sprite = Side1;
        }
        else if(RolledValue == 2)
        {
            gameObject.GetComponent<Image>().sprite = Side2;
        }
        else if(RolledValue == 3)
        {
            gameObject.GetComponent<Image>().sprite = Side3;
        }
        else if(RolledValue == 4)
        {
            gameObject.GetComponent<Image>().sprite = Side4;
        }
        else if(RolledValue == 5)
        {
            gameObject.GetComponent<Image>().sprite = Side5;
        }
        else
        {
            gameObject.GetComponent<Image>().sprite = Side6;
        }
    }
    
}
