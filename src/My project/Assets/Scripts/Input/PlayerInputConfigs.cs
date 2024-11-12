using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerInputConfigs : MonoBehaviour
{
    // Start is called before the first frame update
    public abstract KeyCode upKey {get;}
    public abstract KeyCode downKey {get;}
    public abstract KeyCode leftKey {get;}
    public abstract KeyCode rightKey {get;}
    public abstract KeyCode actionKey1 {get;}
    public abstract KeyCode actionKey2 {get;}
}
