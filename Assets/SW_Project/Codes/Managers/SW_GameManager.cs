using System;
using UnityEngine;

namespace Dante.VR {

	#region Enums

	public enum GameStates
	{
		NONE, MENU, GAME, VICTORY, DEFEAT
	}

	#endregion

	public class SW_GameManager : MonoBehaviour
	{
		#region References



		#endregion

		#region RuntimeVariables

		[SerializeField] protected GameStates currentGameState;



        #endregion

        #region UnityMethods

        private void Start()
        {
            InitializeGameFSM();
        }

        #endregion

        #region PublicMethods

        /// <summary>
        /// Changes the current game state.
        /// </summary>
        /// <param name="nextState"></param>
        public void StateMechanic(GameStates nextState)
		{
			switch (currentGameState)
			{
				case GameStates.NONE:
					if(nextState == GameStates.MENU)
					{
						ChangeToState(nextState);
					}
					break;

				case GameStates.MENU:
                    if (nextState == GameStates.GAME)
                    {
                        ChangeToState(nextState);
                    }
                    break;

				case GameStates.GAME:
                    if (nextState == GameStates.VICTORY || nextState == GameStates.DEFEAT)
                    {
                        ChangeToState(nextState);
                    }
                    break;

				case GameStates.VICTORY:
                    if (nextState == GameStates.MENU)
                    {
                        ChangeToState(nextState);
                    }
                    break;

				case GameStates.DEFEAT:
                    if (nextState == GameStates.MENU)
                    {
                        ChangeToState(nextState);
                    }
                    break;
			}
		}

		#endregion

		#region LocalMethods

        protected void InitializeGameFSM()
        {
            StateMechanic(GameStates.MENU);
        }

		#region FSM Methods

		protected void ChangeToState(GameStates nextState)
		{
			FinalizeFSMState();
			currentGameState = nextState;
			InitializeFSMState();
		}

		protected void InitializeFSMState()
		{
            switch (currentGameState)
            {
                case GameStates.MENU:
					InitializeMenuState();
                    break;

                case GameStates.GAME:
					InitializeGameState();
                    break;

                case GameStates.VICTORY:
					InitializeVictoryState();
                    break;

                case GameStates.DEFEAT:
					InitializeDefeatState();
                    break;
            }
        }

		protected void ExecuteFSMState()
		{
            switch (currentGameState)
            {
                case GameStates.MENU:
					ExecuteMenuState();
                    break;

                case GameStates.GAME:
					ExecuteGameState();
                    break;

                case GameStates.VICTORY:
					ExecuteVictoryState();
                    break;

                case GameStates.DEFEAT:
					ExecuteDefeatState();
                    break;
            }
        }

		protected void FinalizeFSMState()
		{
            switch (currentGameState)
            {
                case GameStates.MENU:
					FinalizeMenuState();
                    break;

                case GameStates.GAME:
					FinalizeGameState();
                    break;

                case GameStates.VICTORY:
					FinalizeVictoryState();
                    break;

                case GameStates.DEFEAT:
					FinalizeDefeatState();
                    break;
            }
        }

		#region MenuState

		protected void InitializeMenuState()
		{
            SW_GUI_Manager.Instance.ActivateMenu();
            SW_InputManager.Instance.SetInputToUI();
		}

		protected void ExecuteMenuState()
		{

		}

		protected void FinalizeMenuState()
		{
            SW_GUI_Manager.Instance.DeactivateMenu();
		}

		#endregion

		#region GameState

		protected void InitializeGameState()
		{
            SW_InputManager.Instance.SetInputToGame();
		}

		protected void ExecuteGameState()
		{

		}

		protected void FinalizeGameState()
		{
            SW_InputManager.Instance.SetInputToUI();
		}

        #endregion

        #region VictoryState

        protected void InitializeVictoryState()
        {
            SW_InputManager.Instance.SetInputToUI();
        }

        protected void ExecuteVictoryState()
        {

        }

        protected void FinalizeVictoryState()
        {

        }

        #endregion

        #region DefeatState

        protected void InitializeDefeatState()
        {

        }

        protected void ExecuteDefeatState()
        {

        }

        protected void FinalizeDefeatState()
        {

        }

        #endregion

        #endregion FSM Methods



        #endregion LocalMethods

        #region GettersSetters



        #endregion
    }
}
