using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : ScriptableObject
{
    public int PlayerId { get; private set; }
    public string PlayerName { get; private set; }
    private List<PlayerStats> _players = new List<PlayerStats>();
    public List<PlayerStats> Players
        { get { return _players; } }

    public int RoundScore;
    public int FinalScore;
    public int HighestCorrectStreak;
    public int HighestIncorrectStreak;
    public float AttemptsPerRound;
    public float PercentageCorrect;
    public float AvgTimePerAttempt;
    public float AvgTimePerCorrectAttempt;
    public float AvgTimePerIncorrectAttempt;

}
