using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;


    // Start is called before the first frame update
    public override void Interact(Player player)
    {
        if(!HasKitchenObject())
        {
            if (player.HasKitchenObject())
            {
                player.GetKitchenOject().SetKitchenObjectParent(this);
            }
        }else
        {
            if(player.HasKitchenObject())
            {
                if (player.GetKitchenOject().TryGetPlate(out PlateKitchenObject plateKitchenObject)) 
                {
                    if (plateKitchenObject.TryAddIngredient(GetKitchenOject().GetKitchenObjectSO()))
                    {
                        GetKitchenOject().DestroySelf();
                    }
                }else
                {
                    if (GetKitchenOject().TryGetPlate(out plateKitchenObject))
                    {
                        if(plateKitchenObject.TryAddIngredient(player.GetKitchenOject().GetKitchenObjectSO())) {
                            player.GetKitchenOject().DestroySelf();
                        }
                    }
                }
            }else
            {
                GetKitchenOject().SetKitchenObjectParent(player);
            }
        }
    }
}
