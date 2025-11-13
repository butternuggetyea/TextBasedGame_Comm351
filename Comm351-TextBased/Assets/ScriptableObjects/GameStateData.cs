using UnityEngine;

[CreateAssetMenu(fileName = "GameStateData", menuName = "Scriptable Objects/GameStateData")]
public class GameStateData : ScriptableObject
{
    public Sprite _senarioImage;
    public string _senarioDescription;

    public GameStateData OptionAData;
    public string OptionADescription;

    public GameStateData OptionBData;
    public string OptionBDescription;

    public GameStateData OptionCData;
    public string OptionCDescription;
}
