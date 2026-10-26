using UnityEngine;

[CreateAssetMenu(fileName = "GameStateData", menuName = "Scriptable Objects/GameStateData")]
public class GameStateData : ScriptableObject
{
    public Sprite _senarioImage;
    public Sprite _forground;

    public AudioClip _soundclip;
    public int _playSoundIndex;

    public bool _snackCheck;
    public bool _dinnerCheck;

    public bool _dinner;
    public bool _reset;

    public string[] _senarioDescription;

    public GameStateData OptionAData;
    public string OptionADescription;

    public GameStateData OptionBData;
    public string OptionBDescription;

    public GameStateData OptionCData;
    public string OptionCDescription;
}
