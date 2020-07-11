using UnityEngine;
using TMPro;

public class PromptDisplayer : MonoBehaviour {

    public Transform promptText;
    public TextMeshProUGUI textMeshPro;

    void Start() {
        promptText = transform.Find("Canvas/PromptText");
        textMeshPro = promptText.GetComponent<TextMeshProUGUI>();
    }

    public void displayPrompt(string prompt) {
        if (textMeshPro != null) {
            textMeshPro.SetText(prompt);
        }
    }
}
