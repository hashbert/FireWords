using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<Clue> Clues;
    [SerializeField] private List<Transform> SpawnLocations;
    [SerializeField] private TextMeshProUGUI _clueText;
    [SerializeField] private GameObject _tilePrefab;
    [SerializeField] private GameObject _dummySpawnPanelArea;

    [SerializeField] private GameObject _answerPanelPrefab;
    [SerializeField] private GameObject _letterSlotPrefab;

    void Start()
    {
        StartCoroutine(DisplayRandomClue());
        CreatePuzzleSlots();
    }

    private IEnumerator DisplayRandomClue()
    {
        yield return new WaitForEndOfFrame(); //bullshit

        int randClueNum = UnityEngine.Random.Range(0, Clues.Count);
        Clue clue = Clues[randClueNum];
        _clueText.text = "Clue: " + clue.ClueDescription;

        foreach (char letter in Clues[randClueNum].ClueAnswer.ToCharArray())
        {
            if (letter.Equals((char)32)) continue; // skip spaces

            //create tile
            _tilePrefab.GetComponentInChildren<TextMeshProUGUI>().text = letter.ToString();
            GameObject letterTile = Instantiate(_tilePrefab);
            letterTile.transform.SetParent(_dummySpawnPanelArea.transform);

            //position the tile
            int randomIndex = UnityEngine.Random.Range(0, SpawnLocations.Count);
            letterTile.transform.position = SpawnLocations[randomIndex].position;
            SpawnLocations.RemoveAt(randomIndex); //do not allow repeat positions
        }

        Clues.RemoveAt(randClueNum);
    }

    private void CreatePuzzleSlots()
    {
        GameObject answerPrefab = Instantiate(_answerPanelPrefab);
    }

}
