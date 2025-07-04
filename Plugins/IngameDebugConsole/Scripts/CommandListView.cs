using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace IngameDebugConsole
{
    public class CommandListView : MonoBehaviour
    {
        [SerializeField] private GameObject commandItemPrefab;
        [SerializeField] private Button commandViewToggleButton;
        [SerializeField] private GameObject[] consoleViewGameObjects;
        [SerializeField] private GameObject commandViewGo;
        [SerializeField] private RectTransform commandItemRoot;

        private void Awake()
        {
            this.commandViewToggleButton.onClick.AddListener(ToggleCommandViewHandler);
        }

        private void Start()
        {
            InitCommandItems();
        }

        private void InitCommandItems()
        {
            List<ConsoleMethodInfo> commands = GetCommands();

            foreach (ConsoleMethodInfo command in commands)
            {
                CreateCommandItem(command);
            }
        }

        private void CreateCommandItem(ConsoleMethodInfo command)
        {
            GameObject commandGo = Instantiate(this.commandItemPrefab, this.commandItemRoot, false);
            commandGo.transform.localPosition = Vector3.zero;
            commandGo.transform.localRotation = Quaternion.identity;
            var commandItem = commandGo.GetComponent<CommandItem>();
            commandItem.InitCommand(command.signature, command.method, command.instance);
        }

        private List<ConsoleMethodInfo> GetCommands()
        {
            FieldInfo methodField =
                typeof(DebugLogConsole).GetField("methods", BindingFlags.NonPublic | BindingFlags.Static);
            Assert.IsNotNull(methodField);
            var methods = (List<ConsoleMethodInfo>)methodField.GetValue(null);
            methods.RemoveAll(x => x.signature.Contains("help"));
            return methods;
        }

        private void ToggleCommandViewHandler()
        {
            foreach (GameObject consoleGo in this.consoleViewGameObjects)
            {
                consoleGo.SetActive(!consoleGo.activeSelf);
            }

            this.commandViewGo.SetActive(!this.commandViewGo.activeSelf);
        }
    }
}