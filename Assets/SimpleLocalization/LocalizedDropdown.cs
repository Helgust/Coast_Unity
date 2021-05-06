using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.SimpleLocalization
{
	/// <summary>
	/// Localize dropdown component.
	/// </summary>
    //[RequireComponent(typeof(Dropdown))]
	[RequireComponent(typeof(TMP_Dropdown))]
    public class LocalizedDropdown : MonoBehaviour
    {
        public string[] LocalizationKeys;

        public void Start()
        {
            Localize();
            LocalizationManager.LocalizationChanged += Localize;
        }

        public void OnDestroy()
        {
            LocalizationManager.LocalizationChanged -= Localize;
        }

        private void Localize()
        {
	        if (GetComponent<Dropdown>() == null)
	        {
		        var dropdown = GetComponent<TMP_Dropdown>();
		         
		        for (var i = 0; i < LocalizationKeys.Length; i++)
		        {
			        dropdown.options[i].text = LocalizationManager.Localize(LocalizationKeys[i]);
		        }

		        if (dropdown.value < LocalizationKeys.Length)
		        {
			        dropdown.captionText.text = LocalizationManager.Localize(LocalizationKeys[dropdown.value]);
		        }
	        }
	        else
	        {
		        var dropdown = GetComponent<Dropdown>();
		         
		        for (var i = 0; i < LocalizationKeys.Length; i++)
		        {
			        dropdown.options[i].text = LocalizationManager.Localize(LocalizationKeys[i]);
		        }

		        if (dropdown.value < LocalizationKeys.Length)
		        {
			        dropdown.captionText.text = LocalizationManager.Localize(LocalizationKeys[dropdown.value]);
		        }
	        }
	       
        }
    }
}