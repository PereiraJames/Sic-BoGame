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
    public GameObject Player_Info;

    void Start()
    {
        Debug.Log(gameObject);
        gameObject.GetComponent<Image>().sprite = Side6;
        Player_Info = GameObject.Find("Player_Info");
        RollDie();
    }

    public void RollDie()
    {
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
        Player_Info.GetComponent<Player_Information>().DiceTotal += RolledValue;
        Debug.Log(Player_Info.GetComponent<Player_Information>().DiceTotal); 
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
