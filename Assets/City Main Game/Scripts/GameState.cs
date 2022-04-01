public class GameState
{
    private static bool isCompaignMode = false;

    public static void GameGameModeToCompaign(bool compaign) => isCompaignMode = compaign;

    public static bool IsCompaignMode() => isCompaignMode;
}