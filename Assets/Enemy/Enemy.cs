using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public int goldReward = 25;
    [SerializeField] public int goldPenalty = 25; 

    Bank bank;

    void Start()
    {
        bank = FindObjectOfType<Bank>();
    }

    public void RewardGold()
    {
        if (bank == null) return;
        bank.Deposit(goldReward);
    }
    public void StealGold()
    {
        if (bank == null) return;
        bank.Withdraw(goldPenalty);
    }
}
