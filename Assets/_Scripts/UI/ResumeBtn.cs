using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeBtn : BaseBtn
{
    [SerializeField] private Canvas _pauseCanvas;

    public override void OnClick()
    {
        _pauseCanvas.gameObject.SetActive(false);
        GameManager.Instance.ChangeState(new InGameState(GameManager.Instance));
    }
}
