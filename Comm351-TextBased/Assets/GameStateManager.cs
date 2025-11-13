using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameStateManager : MonoBehaviour
{

    public GameStateData gameStateData;

    public SpriteRenderer _senarioSpriteRenderer;

    public TMP_Text _senarioDescription;

    public Button[] _optionButtons;

    private void LoadGameState() 
    {
        foreach (var button in _optionButtons) 
        {
            button.gameObject.SetActive( false);
            button.onClick.RemoveAllListeners();
        }
        LoadButtons();

        _senarioSpriteRenderer.sprite = gameStateData._senarioImage;
        _senarioDescription.text = gameStateData._senarioDescription;



    }

    private void LoadOptionA() 
    {
        gameStateData = gameStateData.OptionAData;
        LoadGameState();
    }

    private void LoadOptionB()
    {
        gameStateData = gameStateData.OptionBData;
        LoadGameState();
    }
    private void LoadOptionC()
    {
        gameStateData = gameStateData.OptionCData;
        LoadGameState();
    }

    private void LoadButtons() 
    {
        if (gameStateData.OptionAData != null) 
        {
            _optionButtons[0].gameObject.SetActive( true);
            _optionButtons[0].onClick.AddListener(LoadOptionA);
            _optionButtons[0].GetComponentInChildren<TMP_Text>().text = gameStateData.OptionADescription;
        }
        if (gameStateData.OptionBData != null)
        {
            _optionButtons[1].gameObject.SetActive(true);
            _optionButtons[1].onClick.AddListener(LoadOptionB);
            _optionButtons[1].GetComponentInChildren<TMP_Text>().text = gameStateData.OptionBDescription;
        }
        if (gameStateData.OptionCData != null)
        {
            _optionButtons[2].gameObject.SetActive(true);
            _optionButtons[2].onClick.AddListener(LoadOptionC);
            _optionButtons[2].GetComponentInChildren<TMP_Text>().text = gameStateData.OptionCDescription;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LoadGameState();
    }

}
