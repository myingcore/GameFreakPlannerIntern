using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1InputConfigs : PlayerInputConfigs
{
    public override KeyCode upKey => KeyCode.W;
    public override KeyCode downKey => KeyCode.S;
    public override KeyCode leftKey => KeyCode.A;
    public override KeyCode rightKey => KeyCode.D;
    public override KeyCode actionKey1 => KeyCode.Q;
    public override KeyCode actionKey2 => KeyCode.E;
}
