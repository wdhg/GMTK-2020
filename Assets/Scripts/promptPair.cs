using Interactable;
using InteractableMethods;
using String;

public class promptPair {

    private String prompt;
    private Interactable interactable;

    public promptPair createPair(String input) {
        string[] halves = input.Split(';');
        prompt = halves[0];
        button = identifyInteractable(halves[1]);
        return this;
    }

    public String getString() {
        return prompt;
    }

    public Interactable getInteractable() {
        return interactable;
    }

}