using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBtn : BaseBtn
{
    public override void OnClick()
    {
        GameManager.Instance.ChangeState(new InGameState(GameManager.Instance));
    }
}
