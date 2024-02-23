using System;
using Platformer;
using TMPro;
using UnityEngine;

public class PlayerHealthView : MonoBehaviour
{
    private Player _player;
    [SerializeField] private TextMeshProUGUI _hpText;

    private void Start()
    {
        _player = FindObjectOfType<Player>();
        _player.onHealthChanged.AddListener(UpdateText);
    }

    private void UpdateText(int value)
    {
        _hpText.text = value.ToString();
    }
}
