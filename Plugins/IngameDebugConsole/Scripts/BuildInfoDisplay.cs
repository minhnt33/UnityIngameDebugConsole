using TMPro;
using UnityEngine;

namespace IngameDebugConsole
{
    public class BuildInfoDisplay : MonoBehaviour
    {
        [SerializeField] private TMP_Text buildInfoText;

        public const string BuildInfoAssetName = "BuildInfo";
        private string buildInfoContent = string.Empty;

        private GUIStyle infoTextStyle;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            var buildInfoAsset = Resources.Load<TextAsset>(BuildInfoAssetName);

            this.buildInfoContent = buildInfoAsset != null
                ? buildInfoAsset.text
                : "<color=red>Missing file BuildInfo.txt in Assets/Resources</color>";
            this.buildInfoText.text = this.buildInfoContent;
        }
    }
}