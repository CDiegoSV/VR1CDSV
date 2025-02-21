using UnityEngine;

namespace Dante {
	public class UIInputTrigger : MonoBehaviour
	{
        #region References

        [SerializeField] GameObject uiInput;
        [SerializeField] GameObject normalInput;

        #endregion

        #region RuntimeVariables



        #endregion

        #region UnityMethods

        private void OnTriggerEnter(Collider other)
        {
            uiInput.SetActive(true);
            normalInput.SetActive(false);
            gameObject.SetActive(false);
        }

        #endregion

        #region PublicMethods



        #endregion

        #region LocalMethods



        #endregion

        #region GettersSetters



        #endregion
    }
}
