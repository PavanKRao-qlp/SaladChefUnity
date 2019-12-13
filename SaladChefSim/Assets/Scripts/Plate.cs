using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaladChefGame
{
    public class Plate : MonoBehaviour, IInteractableUtilities
    {
        public Transform _InstanceTransform;

        public Ingredient pIngredient { get; set; }

        public void OnDeselect()
        {
            throw new System.NotImplementedException();
        }

        public void OnSelect(Player player)
        {
            throw new System.NotImplementedException();
        }

        public Ingredient Use(Player player)
        {
            if (pIngredient != null)
            {
                if (player.pIngredientsInHand != null)
                {
                    if (player.pIngredientsInHand.Count < player._CarryLimit)
                    {
                        player.pIngredientsInHand.Enqueue(pIngredient);
                        pIngredient.DestroyObject();
                        player.HoldIngredient(pIngredient);
                        pIngredient = null;
                    }
                }
                else
                {

                }
            }
            else
            {
                if (player.pIngredientsInHand != null && player.pIngredientsInHand != null && player.pIngredientsInHand.Count != 0)
                {
                    pIngredient = player.pIngredientsInHand.Dequeue();
                    pIngredient.PlaceObject(_InstanceTransform);
                }
            }
            return null;
        }
    }
}