using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class TestingNetcodeUI : MonoBehaviour
{
    [SerializeField] private Button startHostButton;
    [SerializeField] private Button startClientButton;

    private void Awake()
    {
        startHostButton.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartHost();
            Debug.Log("Host");
            Hide();
        });

        startClientButton.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartClient();
            Debug.Log("Client");
            Hide();
        });
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
