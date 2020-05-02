using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyHandler{
    public List<KeyCode> keyCodes = new List<KeyCode>();
    public KeyHandler(List<KeyCode> k) {
        keyCodes = k;
    }
}
