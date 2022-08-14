using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameModeData", menuName = "GameModeData")]
public class GameModeData : ScriptableObject
{
    public enum GameMode { Solo, Multiplayer };

    public GameMode gameMode;
}
