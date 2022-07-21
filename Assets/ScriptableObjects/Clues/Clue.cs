using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Clue")]
public class Clue : ScriptableObject
{
    public string ClueDescription;
    public string ClueAnswer;
}
