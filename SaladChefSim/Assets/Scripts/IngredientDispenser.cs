using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaladChefGame
{
    public class IngredientDispenser : MonoBehaviour, IInteractableUtilities
    {
        public string _IngredientID;
        public Transform _InstanceTransform;

        public Ingredient pIngredient { get; set; }

        public void Start()
        {
            if (GameManager.pInstance != null)
            {
                pIngredient = GameManager.pInstance._Ingredients.GetIngredient(_IngredientID);
                pIngredient.CreateObject(_InstanceTransform);
            }
        }

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
            if (player.pIngredientsInHand.Count < player._CarryLimit)
            {
                player.pIngredientsInHand.Enqueue(pIngredient);
                player.HoldIngredient(pIngredient);
                return pIngredient;
            }
            else
                return null;
        }
    }
}
