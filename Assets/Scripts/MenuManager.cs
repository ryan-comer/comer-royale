using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class MenuManager : MonoBehaviour
{

    public InputField addressInput; // The address to connect to
    public Text errorMessageText;   // The text component to print errors

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Create a game for players to join
    public void CreateGame()
    {
        NetworkManager.singleton.StartHost();
    }

    // Join a game based on the IP
    public void JoinGame()
    {
        if (!isValidIP(addressInput.text.Trim()))
        {
            // Not a valid IP
            errorMessageText.text = "Invalid IP Address";
            return;
        }

        NetworkManager.singleton.StartClient();
    }

    // Check if the IP address is valid
    private bool isValidIP(string ipAddress)
    {
        System.Net.IPAddress addr;
        return System.Net.IPAddress.TryParse(ipAddress, out addr);
    }

}
