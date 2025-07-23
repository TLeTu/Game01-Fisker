using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseBtn : BaseBtn
{
    [SerializeField] private Canvas _pauseCanvas;
    public override void OnClick()
    {
        _pauseCanvas.gameObject.SetActive(true);
        GameManager.Instance.ChangeState(new PauseState(GameManager.Instance));
    
    }
}