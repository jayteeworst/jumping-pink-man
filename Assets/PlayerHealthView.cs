using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthView : MonoBehaviour
{
    [SerializeField] private Player.Player _player;
    [SerializeField] private TextMeshProUGUI _hpText;

    private void Update()
    {
        _hpText.text = _player.Hitpoints.ToString();
    }
}
