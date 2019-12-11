using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaladChefGame
{
    public class ChoppingBoard : MonoBehaviour,IInteractableUtilities
    {
        public Queue<Ingredient> _ChoppedIngredients;

        public Ingredient pCurrentIngredient { get; set; }

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
            if(player.pIngredientsInHand != null && player.pIngredientsInHand.Count > 0)
            {
                Ingredient ingredient = player.pIngredientsInHand.Dequeue();
                if(ingredient != null)
                {
                    if (!ingredient.HasStatus(Ingredient.IngredientStatus.CHOPPED))
                    {
                        StartCoroutine("Chop", ingredient);
                    }
                }
            }
            else
            {
                player.pIngredientsInHand = _ChoppedIngredients;
            }
            return null;
        }

        private IEnumerator Chop(Ingredient choppedIngredient)
        {
            yield return new WaitForSeconds(choppedIngredient._ChoppingDelay);
            choppedIngredient.SetStatus(Ingredient.IngredientStatus.CHOPPED);
            _ChoppedIngredients.Enqueue(choppedIngredient);
        }
    }
}
