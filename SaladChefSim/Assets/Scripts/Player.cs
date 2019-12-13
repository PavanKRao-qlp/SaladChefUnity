using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaladChefGame
{
    public class Player : MonoBehaviour
    {
        public int _CarryLimit;
        public int _DefaultSpeed;
        public Transform _PlateTransform;

        public Queue<Ingredient> pIngredientsInHand { get; set; }
        public float pTimeLeft { get; set; }
        public int pScore { get; set; }
        public int pCurrentSpeed { get; set; }

        private CharacterController mMovementController;
        private IInteractableUtilities mCurrentUtility;

        void Start()
        {
            pCurrentSpeed = _DefaultSpeed;
            mMovementController = GetComponent<CharacterController>();
            pIngredientsInHand = new Queue<Ingredient>();
        }

        void Update()
        {
            Vector3 movementVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")) * pCurrentSpeed * Time.deltaTime;
            if (mMovementController != null)
            {
                mMovementController.Move(movementVector);
            }

            if(mCurrentUtility != null && Input.GetKeyDown(KeyCode.E))
            {
                mCurrentUtility.Use(this);
            }
        }

        public void HoldIngredient(Ingredient ingredient)
        {
            GameObject ingredientObj = ingredient.CreateObject(_PlateTransform);
            ingredientObj.transform.position += Vector3.up * 1 * (pIngredientsInHand.Count - 1);
        }

        public void ClearHand()
        {
            foreach (Ingredient ingredient in pIngredientsInHand)
                ingredient.DestroyObject();
        }

        private void OnTriggerEnter(Collider other)
        {
            IInteractableUtilities utility = other.GetComponent<IInteractableUtilities>();
            if (utility != null)
            {
                mCurrentUtility = utility;
               // mCurrentUtility.OnSelect(this);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            IInteractableUtilities utility = other.GetComponent<IInteractableUtilities>();
            if (utility != null && mCurrentUtility != null)
            {
                //mCurrentUtility.OnDeselect();
                mCurrentUtility = null;
            }
        }
    }
}
