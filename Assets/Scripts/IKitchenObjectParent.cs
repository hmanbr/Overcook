using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public interface IKitchenObjectParent
{
    public Transform GetKitchenOjectFollowTransform();

    public void SetKitchenObject(KitchenObject kitchenObject);

    public KitchenObject GetKitchenOject();

    public void ClearKitchenObject();

    public bool HasKitchenObject();

    public NetworkObject GetNetworkObject();
}
