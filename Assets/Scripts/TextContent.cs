using UnityEngine;
using UnityEngine.UI;

public class TextContent : MonoBehaviour
{
    [SerializeField]
    private Text headerText;

    public void SetupHeader(string headerText)
    {
        this.headerText.text = headerText;
    }
}