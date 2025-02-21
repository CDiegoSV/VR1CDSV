using Dante.VR;
using UnityEngine;

namespace Dante {
	public class SW_InputManager : MonoBehaviour
	{
		#region References

		[SerializeField] protected GameObject[] uiInputs;
		[SerializeField] protected GameObject[] gameInputs;

        #endregion

        #region PublicVariables

        public static SW_InputManager Instance;

        #endregion

        #region RuntimeVariables

        protected bool snapTurn;

        #endregion

        #region UnityMethods

        private void Awake()
        {
            if(Instance != null && Instance != this)
            {
                Destroy(Instance);
            }
            else
            {
                Instance = this;
            }
            snapTurn = true;
        }

        #endregion

        #region PublicMethods

        public void SetInputToUI()
        {
            if (gameInputs[0].activeSelf)
            {
                foreach (GameObject input in gameInputs)
                {
                    input.SetActive(false);
                }
            }
            foreach (GameObject input in uiInputs)
            {
                input.SetActive(true);
            }
        }

        public void SetInputToGame()
        {
            if (uiInputs[0].activeSelf)
            {
                foreach (GameObject input in uiInputs)
                {
                    input.SetActive(false);
                }
            }
            gameInputs[0].SetActive(true);
            if (snapTurn)
            {
                gameInputs[1].SetActive(true);
                gameInputs[2].SetActive(false);
            }
            else
            {
                gameInputs[1].SetActive(false);
                gameInputs[2].SetActive(true);
            }
        }

        public void OnDropdownValueChanged()
        {
            if(SW_GUI_Manager.Instance.TurnDropdown.value == 0)
            {
                snapTurn = true;
            }
            else
            {
                snapTurn = false;
            }
        }

        #endregion

        #region LocalMethods



        #endregion

    }
}
