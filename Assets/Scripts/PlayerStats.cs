using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {

    public Text ItemCount_HUD;
    public Text Health;
    public Text ItemCount2_HUD;

    float itemCounter = 0f;
    float itemCounter2 = 0f;
    float itemsNeeded = 20f;
    float hp = 20f;

    bool done1 = false;
    bool done2 = false;

    string healthBar;
    
    void Start() {
        hpDisplay(0f);
    }

    // Update is called once per frame
    void Update () {
        Health.text = "HP " + healthBar;

        if (!done1)
        {
            ItemCount_HUD.text = "Maze 1 Items: " + itemCounter + " / " + itemsNeeded;
        }
        if (!done2)
        { 
            ItemCount2_HUD.text = "Maze 2 Items: " + itemCounter2 + " / " + itemsNeeded;
        }

        //m1 check
        if (checkItems(itemCounter, itemsNeeded))
        {
            ItemCount_HUD.color = Color.green;
            ItemCount_HUD.text = "Maze 1 Items: COMPLETE!";
            done1 = true;
        }
        //m2 check
        if (checkItems(itemCounter2, itemsNeeded))
        {
            ItemCount2_HUD.color = Color.green;
            ItemCount2_HUD.text = "Maze 2 Items: COMPLETE!";
            done2 = true;
        }
        if (done1 && done2)
        {
            print("Technically Victory, now finish the maze.");
        }

    }

    public void IncreaseCounter(float n)
    {
        ///<summary>
        /// n == 1 -> maze1
        /// n == 2 -> maze2
        /// </summary>
        if (n == 1)
        {
            itemCounter += 1f;
        }
        else if (n == 2)
        {
            itemCounter2 += 1f;
        }
    }

    public void hpDisplay(float damage)
    {
        healthBar = "";
        hp -= damage;
        for (float p = 0f; p <= hp; ++p)
        {
            healthBar += "/";
        }
    }

    bool checkItems(float obtained, float needed)
    {
        if (obtained >= needed)
        {
            return true;
        }
        return false;
    }
}
