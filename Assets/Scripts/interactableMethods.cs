using Interactable;

public static class interactableMethods {

    public static Interactable identifyInteractable(String id) {
        switch (id) {
            case "red_square":
                return RED_SQUARE;
            case "green_square":
                return GREEN_SQUARE;
            case "blue_square":
                return BLUE_SQUARE;
            case "big_circle":
                return BIG_CIRCLE;
            case "small_circle":
                return SMALL_CIRCLE;
            case "slider_1":
                return SLIDER_1;
            case "slider_2":
                return SLIDER_2;
            case "slider_3":
                return SLIDER_3;
            case "slider_4":
                return SLIDER_4;
            case "slider_5":
                return SLIDER_5;
            case "lever":
                return LEVER;
        }
    }

}