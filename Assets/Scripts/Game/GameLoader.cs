using UnityEngine;

public static class GameLoader
{
    private const string scoreKey = "Score";

    public static bool TryGetScore(out int score)
    {
        score = PlayerPrefs.GetInt(scoreKey, 0);
        return PlayerPrefs.HasKey(scoreKey);
    }
}
