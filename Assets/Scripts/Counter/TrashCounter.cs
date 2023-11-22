using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.UI;

public class TrashCounter : BaseCounter
{
    new public static void ResetStaticData()
    {
        OnAnyObjectTrashed = null;
    }

    public static event EventHandler OnAnyObjectTrashed;

    public override void Interact(Player player)
    {
        if(player.HasKitchenObject())
        {
            player.GetKitchenOject().DestroySelf();
            OnAnyObjectTrashed?.Invoke(this, EventArgs.Empty);
        }
    }
}
