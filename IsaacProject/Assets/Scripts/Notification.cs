using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Notification : MonoBehaviour
{
    private TextMeshProUGUI textBox;
    // Start is called before the first frame update
    void Start()
    {
        textBox = gameObject.GetComponent<TextMeshProUGUI>();
    }

    public void DisplayText(string pText)
    {
        textBox.text = pText;
        StartCoroutine(ClearText());
    }

    IEnumerator ClearText()
    {
        yield return new WaitForSeconds(2);
        textBox.text = "";
    }
}
