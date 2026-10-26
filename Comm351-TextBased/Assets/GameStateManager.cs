using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameStateManager : MonoBehaviour
{

    public GameStateData gameStateData;

    public SpriteRenderer _senarioSpriteRenderer;

    public SpriteRenderer _forground;

    public GameStateData _BadSnack;
    public GameStateData _BadDinner;

    bool _dinner = false;

    public TMP_Text _senarioDescription;

    public Button[] _optionButtons;

    public float _speed;

    bool _canSkip;

    private Vector3 _size;

    public float _growSpeed;

    bool grow = true;

    private void Awake()
    {
        _size = _senarioSpriteRenderer.transform.lossyScale;
    }

    public void BackgroundBreath() 
    {
        if (_senarioSpriteRenderer.transform.localScale.x < (_size.x + .025f) && grow)
        {
            _senarioSpriteRenderer.transform.localScale = new Vector3(_senarioSpriteRenderer.transform.localScale.x + Time.deltaTime / _growSpeed, _senarioSpriteRenderer.transform.localScale.y + Time.deltaTime / _growSpeed, _senarioSpriteRenderer.transform.localScale.z);
        }
        else { grow = false; }

        if (!grow && _senarioSpriteRenderer.transform.localScale.x > _size.x)
        {
            _senarioSpriteRenderer.transform.localScale = new Vector3(_senarioSpriteRenderer.transform.localScale.x - Time.deltaTime / _growSpeed, _senarioSpriteRenderer.transform.localScale.y - Time.deltaTime / _growSpeed, _senarioSpriteRenderer.transform.localScale.z );
        }
        else { grow = true; }
    }

    public IEnumerator LoadText(int _senarioIndex = 0)
    {
        _senarioDescription.text = null;
        _canSkip = true;
        bool _play = true;
        int index = 0;

        foreach (char letter in gameStateData._senarioDescription[_senarioIndex])
        {
            _senarioDescription.text += letter;

            if (gameStateData._playSoundIndex == index)
            {
                if (gameStateData._soundclip != null)
                {
                    GetComponent<AudioManager>().PlayOnCharIndex(gameStateData._soundclip);
                }
            }
            index++;

            if (_play)
            {
                GetComponent<AudioManager>().PlayText();
            }
            _play = !_play;
            yield return new WaitForSecondsRealtime(_speed);
        }
        _canSkip = false;
        if (_senarioIndex == gameStateData._senarioDescription.Length - 1)
        {
            LoadButtons();
        }
        else
        {
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
            StartCoroutine(LoadText(_senarioIndex + 1));
        }
    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _canSkip) 
        {
            _canSkip = false;
            StopAllCoroutines();
            _senarioDescription.text = gameStateData._senarioDescription[0];
            LoadButtons();
        }
        BackgroundBreath();
    }


    private void LoadOptionA() 
    {
        foreach (var button in _optionButtons)
        {
            button.gameObject.SetActive(false);
            button.onClick.RemoveAllListeners();
        }

        gameStateData = gameStateData.OptionAData;
        StartCoroutine(LoadText());
    }

    private void LoadOptionB()
    {
        foreach (var button in _optionButtons)
        {
            button.gameObject.SetActive(false);
            button.onClick.RemoveAllListeners();
        }

        if (gameStateData._dinnerCheck && !_dinner) 
        {
            gameStateData = _BadSnack;
        }
        else if (gameStateData._snackCheck && _dinner )
        {
            gameStateData = _BadDinner;
        }
        else
        {
            gameStateData = gameStateData.OptionBData;
        }

        StartCoroutine(LoadText());

    }
    private void LoadOptionC()
    {
        foreach (var button in _optionButtons)
        {
            button.gameObject.SetActive(false);
            button.onClick.RemoveAllListeners();
        }

        gameStateData = gameStateData.OptionCData;
        StartCoroutine(LoadText());
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
        StartCoroutine(LoadText());
    }

}
