using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Mimi.Testing.AdminTools
{
    public class FilterAdInfo : MonoBehaviour
    {
        [SerializeField] private Button adInfoFilterButton;
        [SerializeField] private TMP_InputField searchBarInputField;

        private bool isFilterActive;

        private void Awake()
        {
            this.adInfoFilterButton.onClick.AddListener(AdInfoFilterClickHandler);
        }

        private void AdInfoFilterClickHandler()
        {
            this.isFilterActive = !this.isFilterActive;
            this.searchBarInputField.text = this.isFilterActive ? "[AdInfo]" : string.Empty;
        }
    }
}