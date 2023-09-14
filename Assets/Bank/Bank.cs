using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 150;
    [SerializeField] int currentBalance;
    [SerializeField] TextMeshProUGUI displayBalance;
    public int CurrentBalance { get { return currentBalance; } }
    
    void Awake() {
        currentBalance = startingBalance;
        UpdateDisplay();
    }

   public void Deposit(int amount)
   {
        currentBalance += Mathf.Abs(amount);
        UpdateDisplay();
   }
   public void Withdraw(int amount)
   {
        currentBalance -= Mathf.Abs(amount);
        UpdateDisplay();
        
        if(currentBalance < 0)
        {
            //Lose the game  
            ReloadTheScene();
        }
   }

   void UpdateDisplay()
   {
        displayBalance.text = "Gold: " + currentBalance;
   }

   void ReloadTheScene()
   {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
   }
}
