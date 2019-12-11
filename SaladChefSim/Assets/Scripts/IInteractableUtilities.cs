using System.Collections;
using System.Collections.Generic;

namespace SaladChefGame
{
    public interface IInteractableUtilities
    {
        Ingredient Use(Player player);
        void OnSelect(Player player);
        void OnDeselect();
    }
}