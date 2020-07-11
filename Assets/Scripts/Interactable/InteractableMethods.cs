using static Interactable;

public static class InteractableMethods {

    public static Interactable identifyInteractable(string id) {
        switch (id) {
            case "red_square":
                return RED_SQUARE;
            case "green_square":
                return GREEN_SQUARE;
            case "blue_square":
                return BLUE_SQUARE;
            case "red_circle":
                return RED_CIRCLE;
            case "yellow_circle":
                return YELLOW_CIRCLE;
            case "slider_0":
                return SLIDER_0;
            case "slider_1":
                return SLIDER_1;
            case "slider_2":
                return SLIDER_2;
            case "slider_3":
                return SLIDER_3;
            case "slider_4":
                return SLIDER_4;
            default:
                return LEVER;
        }
    }

}