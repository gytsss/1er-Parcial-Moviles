using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface GameState 
{
    void Handle(GameManager gameManager);
}
