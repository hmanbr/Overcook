using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
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
            KitchenObject.DestroyKitchenObject(player.GetKitchenOject());
            InteractLogicServerRpc();  
        }
    }

    [ServerRpc(RequireOwnership = false)]
    private void InteractLogicServerRpc()
    {
        InteractLogicClientRpc();
    }

    [ClientRpc]
    private void InteractLogicClientRpc()
    {
        OnAnyObjectTrashed?.Invoke(this, EventArgs.Empty);
    }
}
