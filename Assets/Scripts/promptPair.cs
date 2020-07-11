using static interactableMethods;

public class promptPair {

    private string prompt;
    private Interactable interactable;

    public promptPair createPair(string input) {
        string[] halves = input.Split(';');
        prompt = halves[0];
        interactable = identifyInteractable(halves[1]);
        return this;
    }

    public string getString() {
        return prompt;
    }

    public Interactable getInteractable() {
        return interactable;
    }

}