using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Dante.VR {
	public class SW_GUI_Manager : MonoBehaviour
	{
        #region References
        [SerializeField] protected SW_GameManager gameManager;

        [SerializeField] protected GameObject menuGO;
        [SerializeField] protected TMP_Dropdown turnDropdown;

        #endregion

        #region RuntimeVariables



        #endregion

        #region PublicVariables

        public static SW_GUI_Manager Instance;

        #endregion

        #region UnityMethods

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(Instance);
            }
            else
            {
                Instance = this;
            }
        }

        #endregion

        #region PublicMethods

        public void ActivateMenu()
        {
            menuGO.SetActive(true);
        }

        public void DeactivateMenu()
        {
            menuGO.SetActive(false);
        }

        public void PlayButton()
        {
            gameManager.StateMechanic(GameStates.GAME);
        }

        public void WinButton()
        {
            gameManager.StateMechanic(GameStates.VICTORY);
        }

        public void ReplayButton()
        {
            SceneManager.LoadScene(0);
        }

        public void Quit()
        {
            Application.Quit();
            
        }

        #endregion

        #region LocalMethods



        #endregion

        #region GettersSetters

        public TMP_Dropdown TurnDropdown
        {
            get { return turnDropdown; }
        }

        #endregion
    }
}
