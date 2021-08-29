using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public enum STATE_GAME{
        INICIALIZING,
        CHANGE_SCENE,
        WAITING_TO_START,
        READY_TO_START,
        INGAME,
        SPAWNING,
        WAITING
    }
}
