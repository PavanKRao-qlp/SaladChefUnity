using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SaladChefGame;

public class GameManager : MonoBehaviour
{
    public IngredientData _Ingredients;

    public static GameManager pInstance { get; private set; }

    private void Awake()
    {
        if (pInstance == null)
            pInstance = this;
        else
            Destroy(this.gameObject);
    }
}
