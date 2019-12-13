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
        public Sprite _IngredientIcon;
        public Sprite _CutIngredientIcon;

        public float _ChoppingDelay = 0.0f;

        public IngredientStatus pStatus { get; set; }
        public GameObject pObject {get; private set; }

        public GameObject CreateObject(Transform proxyTransform)
        {
            pStatus = IngredientStatus.NONE;
            pObject = GameObject.Instantiate(GameManager.pInstance._Ingredients._IngredientTemplate, proxyTransform);
            pObject.GetComponentInChildren<SpriteRenderer>().sprite = _IngredientIcon;
            return pObject;
        }

        public void PlaceObject(Transform proxyTransfor)
        {
            if (pObject != null)
            {
                pObject.transform.SetParent(proxyTransfor);
                pObject.transform.localPosition = Vector3.zero;
            }
        }

        public void DestroyObject()
        {
            GameObject.Destroy(pObject);
        }

        public  void SetStatus(IngredientStatus status)
        {
            pStatus = pStatus | status;
            GetSprite();
        }

        public void RemoveStatus(IngredientStatus status)
        {
            pStatus = pStatus & (~status);
            GetSprite();
        }

        public bool HasStatus(IngredientStatus status)
        {
            return (pStatus & status) == status;
        }

        private void GetSprite()
        {
            if(pObject != null && pObject.GetComponentInChildren<SpriteRenderer>() != null)
            {
                if(HasStatus(IngredientStatus.CHOPPED))
                pObject.GetComponentInChildren<SpriteRenderer>().sprite = _CutIngredientIcon;
            }
        }

    }

    [CreateAssetMenu(menuName = "IngredientData")]
    public class IngredientData : ScriptableObject
    {
        public GameObject _IngredientTemplate;
        public List<Ingredient> _Ingredients = new List<Ingredient>();

        public Ingredient GetIngredient(string name)
        {
            return _Ingredients.Find(x => x._Name == name);
        }
    }
}