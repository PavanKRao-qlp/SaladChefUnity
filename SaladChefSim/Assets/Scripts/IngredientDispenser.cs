using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaladChefGame
{
    public class IngredientDispenser : MonoBehaviour, IInteractableUtilities
    {
        public string _IngredientID;
        public Transform _InstanceTransform;
        public IngredientData _IngredientData;

        public Ingredient pIngredient { get; set; }    

        public void Start()
        {
            pIngredient = _IngredientData.GetIngredient(_IngredientID);
            Instantiate(pIngredient._InstanceObject, _InstanceTransform);
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
                return pIngredient;
            }
            else
                return null;
        }
    }
}
