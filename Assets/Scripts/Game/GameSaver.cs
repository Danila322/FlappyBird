using UnityEngine;

public static class GameSaver
{
    private const string scoreKey = "Score";

    public static void SaveScore(int score)
    {
        PlayerPrefs.SetInt(scoreKey, score);
    }
}