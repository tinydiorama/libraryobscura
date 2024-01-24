using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class CancelUIButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI characterText;
    [SerializeField] private string gamepadText;
    [SerializeField] private string keyboardText;

    private InputManager im;

    private void Start()
    {
        im = InputManager.GetInstance();
    }

    // Update is called once per frame
    void Update()
    {
        characterText.text = im.GetPlayerInput().currentActionMap.FindAction("CloseMenu").GetBindingDisplayString();
    }
}
