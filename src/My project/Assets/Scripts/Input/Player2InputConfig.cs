using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2InputConfig : PlayerInputConfigs
{
    public override KeyCode upKey => KeyCode.I;
    public override KeyCode downKey => KeyCode.K;
    public override KeyCode leftKey => KeyCode.J;
    public override KeyCode rightKey => KeyCode.L;
    public override KeyCode actionKey1 => KeyCode.U;
    public override KeyCode actionKey2 => KeyCode.O;
}
