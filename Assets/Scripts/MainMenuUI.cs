using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] Text goldTxt;
    // Start is called before the first frame update
    void Start()
    {
        goldTxt.text = PlayerData.gold.ToString() + "G";
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void startLevel1()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void upgradeCam1()
    {
        if(PlayerData.gold > 50)
        {
            PlayerData.weapon1DMG *= 1.25f;

            PlayerData.gold -= 50;
            goldTxt.text = PlayerData.gold.ToString() + "G";
            Debug.Log("Upgraded Cam1");
        }
        
    }

    public void upgradeCam2()
    {
        if (PlayerData.gold >= 50)
        {
            PlayerData.weapon2DMG *= 1.25f;

            PlayerData.gold -= 50;
            goldTxt.text = PlayerData.gold.ToString() + "G";
            Debug.Log("Upgraded Cam2");
        }
    }

    public void upgradeCam3()
    {
        if (PlayerData.gold >= 50)
        {
            PlayerData.weapon3DMG *= 1.25f;

            PlayerData.gold -= 50;
            goldTxt.text = PlayerData.gold.ToString() + "G";
            Debug.Log("Upgraded Cam3");
        }
    }

    public void upgradeHP()
    {
        if (PlayerData.gold >= 50)
        {
            PlayerData.playerHP += 10.0f;

            PlayerData.gold -= 50;
            goldTxt.text = PlayerData.gold.ToString() + "G";
            Debug.Log("Upgraded HP");
        }
            
    }
}