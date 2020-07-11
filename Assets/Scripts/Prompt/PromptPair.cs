using static InteractableMethods;

public class PromptPair {

    private string prompt;
    private Interactable interactable;

    public PromptPair(string input) {
        string[] halves = input.Split(';');
        prompt = halves[0];
        interactable = identifyInteractable(halves[1]);
    }

    public string getString() {
        return prompt;
    }

    public Interactable getInteractable() {
        return interactable;
    }

}