using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaladChefGame
{
    public class TrashCan : MonoBehaviour, IInteractableUtilities
    {
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
            if (player.pIngredientsInHand != null)
            {
                player.pIngredientsInHand.Clear();
            }
            return null;
        }
    }
}