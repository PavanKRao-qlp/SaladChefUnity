using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaladChefGame
{
    [Serializable]
    public class Ingredient
    {
        public enum IngredientStatus
        {
            NONE = 0,
            CHOPPED = 1 << 0,
            //BAKED = 1 << 1,
        }

        public string _Name;
        public GameObject _InstanceObject;

        public float _ChoppingDelay = 0.0f;

        public IngredientStatus pStatus { get; set; }

        public  void SetStatus(IngredientStatus status)
        {
            pStatus = pStatus | status;
        }

        public void RemoveStatus(IngredientStatus status)
        {
            pStatus = pStatus & (~status);
        }

        public bool HasStatus(IngredientStatus status)
        {
            return (pStatus & status) == status;
        }

    }

    [CreateAssetMenu(menuName = "IngredientData")]
    public class IngredientData : ScriptableObject
    {
        public List<Ingredient> _Ingredients = new List<Ingredient>();

        public Ingredient GetIngredient(string name)
        {
            return _Ingredients.Find(x => x._Name == name);
        }

        //public List<Ingredient> GetRandomSalad(int count)
        //{
        //     List<Ingredient> randomSalad = new Salad();
        //    List<int> randoms = Utilities.GetNonRepetitiveRandom(count, 0, m_Vegetables.Count - 1);

        //    for (int i = 0; i < count; i++)
        //        randomSalad.AddIngredients(m_Vegetables[randoms[i]]);

        //    return randomSalad;
        //}
    }
}