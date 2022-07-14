using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemColactableCoin : ItemCollactableBoolBase
{
    protected override void OnCollect()
    {
        base.OnCollect();
        ItemManager.Instance.AddCoins();
    }
} 
