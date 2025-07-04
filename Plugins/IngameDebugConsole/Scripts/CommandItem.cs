using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace IngameDebugConsole
{
    public class CommandItem : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private TMP_Text commandNameText;

        private MethodInfo commandMethod;
        private object executeTarget;
        
        public void InitCommand(string commandName, MethodInfo method, object target)
        {
            this.commandNameText.text = commandName;
            this.commandMethod = method;
            this.executeTarget = target;
        }
        
        private void Awake()
        {
            this.button.onClick.AddListener(ClickCommandHandler);
        }

        private void ClickCommandHandler()
        {
            this.commandMethod.Invoke(this.executeTarget, null);
        }
    }
}