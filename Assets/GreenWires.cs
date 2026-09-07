using System.Collections;
using KModkit;
using Rnd = UnityEngine.Random;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Text.RegularExpressions;

public class GreenWires : MonoBehaviour {
    public TextMesh CounterText;
    public GameObject Battery;
    private List<char> colorNames = new List<char>() {'B', 'D', 'E', 'F', 'G', 'J', 'L', 'M', 'O', 'P'};
    private List<Color> possibleColors = new List<Color>() { new Color32(27, 77, 62, 255), new Color32(0, 105, 62, 255), new Color32(80, 200, 120, 255), new Color32(34, 139, 34, 255), new Color32(5, 81, 5, 255), new Color32(0, 163, 108, 255), new Color32(50, 205, 50, 255), new Color32(62, 180, 137, 255), new Color32(88, 128, 0, 255), new Color32(160, 32, 240, 255)};
    private List<int> colors = new List<int>();
    public KMSelectable[] Wires;
    public TextMesh[] ColorText;
    public MeshRenderer[] wireRenders;
    public List<int> cutable_wires = new List<int>();
    public int battery;
    public int number_text;
    public int purple_wire;
    public int purple_wire_index;
    private bool module_solved;
    public KMBombModule module;
    private int rule_taken;

    
    int _moduleID = 0;
    static int _moduleIdCounter = 1;

    // Use this for initialization
    void Start () {
	    
    }
	
    // Update is called once per frame
    void Update () {
		
    }
    void Awake()
    {
        rule_taken = 0;
        _moduleID = _moduleIdCounter++;
        number_text = Rnd.Range(0, 100);
        CounterText.text = number_text.ToString("00");
        module_solved = false;
        if (CounterText.text == "69")
        {
            Debug.LogFormat("[Green Wires #{0}] has the number #{1}, NICE.", _moduleID, CounterText.text);
        }
        else
        {
            Debug.LogFormat("[Green Wires #{0}] has the number #{1}.", _moduleID, CounterText.text);
        }
        for (int i = 0; i < Wires.Length; i++)
        {
            colors.Add(Rnd.Range(0, possibleColors.Count() - 1));
            Wires[i].GetComponent<MeshRenderer>().material.color = possibleColors[colors[i]];
            ColorText[i].text = colorNames[colors[i]].ToString();
        }
        if (Rnd.Range(0, 100) < 31)
        {
            var rand = Rnd.Range(0, colors.Count());
            colors[rand] = 9;
            purple_wire = 1;
            Wires[rand].GetComponent<MeshRenderer>().material.color = possibleColors[9];
            ColorText[rand].text = "P";
            purple_wire_index = rand;
            Debug.LogFormat("[Green Wires #{0}] Wire #{1} is purple.", _moduleID, rand);
        }
        if (Rnd.Range(0, 100) == 0)
        {
            Battery.SetActive(true);
            battery = 1;
        }
        else
        {
            Battery.SetActive(false);
            battery = 0;
        }
            if (battery == 1)
            {
                retryWires:
                for (int j = 0; j < Wires.Length; j++)
                {
                    if (colors[j] % 4 == 0)
                    {
                        cutable_wires.Add(j);
                        Debug.LogFormat("[Green Wires #{0}] Wire #{1} is Brunswick Green, Green, or Olive.", _moduleID, j);
                        rule_taken = 1;
                    }
                }
                if (!cutable_wires.Any())
                {
                    for (int i = 0; i < Wires.Length; i++)
                    {
                        colors[i] = Rnd.Range(0, possibleColors.Count() - 1);
                        Wires[i].GetComponent<MeshRenderer>().material.color = possibleColors[colors[i]];
                        ColorText[i].text = colorNames[colors[i]].ToString();
                    }
                    goto retryWires;
                }
            }
            else if (purple_wire == 1)
            {
                if (purple_wire_index == 0)
                {
                    rule_taken = 1;
                    if (number_text < 10)
                    {
                        cutable_wires.Add(0);
                        Debug.LogFormat("[Green Wires #{0}] Cut wire 1.", _moduleID);
                    }
                    else if (number_text < 20)
                    {
                        cutable_wires.Add(1);
                        Debug.LogFormat("[Green Wires #{0}] Cut wire 2.", _moduleID);
                    }
                    else if (number_text < 30)
                    {
                        cutable_wires.Add(2);
                        Debug.LogFormat("[Green Wires #{0}] Cut wire 3.", _moduleID);
                    }
                    else if (number_text < 40)
                    {
                        cutable_wires.Add(3);
                        Debug.LogFormat("[Green Wires #{0}] Cut wire 4.", _moduleID);
                    }
                    else if (number_text < 50)
                    {
                        cutable_wires.Add(4);
                        Debug.LogFormat("[Green Wires #{0}] Cut wire 5.", _moduleID);
                    }
                    else if (number_text < 60)
                    {
                        cutable_wires.Add(5);
                        Debug.LogFormat("[Green Wires #{0}] Cut wire 6.", _moduleID);
                    }
                    else if (number_text < 70)
                    {
                        cutable_wires.Add(6);
                        Debug.LogFormat("[Green Wires #{0}] Cut wire 7.", _moduleID);
                    }
                    else if (number_text < 80)
                    {
                        cutable_wires.Add(0);
                        Debug.LogFormat("[Green Wires #{0}] Cut wire 1.", _moduleID);
                    }
                    else if (number_text < 90)
                    {
                        cutable_wires.Add(1);
                        Debug.LogFormat("[Green Wires #{0}] Cut wire 2.", _moduleID);
                    }
                    else if (number_text < 100)
                    {
                        cutable_wires.Add(2);
                        Debug.LogFormat("[Green Wires #{0}] Cut wire 3.", _moduleID);
                    }
                }
                else if (purple_wire_index == 1)
                {
                    if (number_text < 10)
                    {
                        cutable_wires.Add(1);
                        Debug.LogFormat("[Green Wires #{0}] Cut wire 2.", _moduleID);
                    }
                    else if (number_text < 20)
                    {
                        cutable_wires.Add(2);
                        Debug.LogFormat("[Green Wires #{0}] Cut wire 3.", _moduleID);
                    }
                    else if (number_text < 30)
                    {
                        cutable_wires.Add(3);
                        Debug.LogFormat("[Green Wires #{0}] Cut wire 4.", _moduleID);
                    }
                    else if (number_text < 40)
                    {
                        cutable_wires.Add(4);
                        Debug.LogFormat("[Green Wires #{0}] Cut wire 5.", _moduleID);
                    }
                    else if (number_text < 50)
                    {
                        cutable_wires.Add(5);
                        Debug.LogFormat("[Green Wires #{0}] Cut wire 6.", _moduleID);
                    }
                    else if (number_text < 60)
                    {
                        cutable_wires.Add(6);
                        Debug.LogFormat("[Green Wires #{0}] Cut wire 7.", _moduleID);
                    }
                    else if (number_text < 70)
                    {
                        cutable_wires.Add(0);
                        Debug.LogFormat("[Green Wires #{0}] Cut wire 1.", _moduleID);
                    }
                    else if (number_text < 80)
                    {
                        cutable_wires.Add(1);
                        Debug.LogFormat("[Green Wires #{0}] Cut wire 2.", _moduleID);
                    }
                    else if (number_text < 90)
                    {
                        cutable_wires.Add(2);
                        Debug.LogFormat("[Green Wires #{0}] Cut wire 3.", _moduleID);
                    }
                    else if (number_text < 100)
                    {
                        cutable_wires.Add(3);
                        Debug.LogFormat("[Green Wires #{0}] Cut wire 4.", _moduleID);
                    }
                }
                else if (purple_wire_index == 2)
                {
                    if (number_text < 10)
                    {
                        cutable_wires.Add(2);
                        Debug.LogFormat("[Green Wires #{0}] Cut wire 3.", _moduleID);
                    }
                    else if (number_text < 20)
                    {
                        cutable_wires.Add(3);
                        Debug.LogFormat("[Green Wires #{0}] Cut wire 4.", _moduleID);
                    }
                    else if (number_text < 30)
                    {
                        cutable_wires.Add(4);
                        Debug.LogFormat("[Green Wires #{0}] Cut wire 5.", _moduleID);
                    }
                    else if (number_text < 40)
                    {
                        cutable_wires.Add(5);
                        Debug.LogFormat("[Green Wires #{0}] Cut wire 6.", _moduleID);
                    }
                    else if (number_text < 50)
                    {
                        cutable_wires.Add(6);
                        Debug.LogFormat("[Green Wires #{0}] Cut wire 7.", _moduleID);
                    }
                    else if (number_text < 60)
                    {
                        cutable_wires.Add(0);
                        Debug.LogFormat("[Green Wires #{0}] Cut wire 1.", _moduleID);
                    }
                    else if (number_text < 70)
                    {
                        cutable_wires.Add(1);
                        Debug.LogFormat("[Green Wires #{0}] Cut wire 2.", _moduleID);
                    }
                    else if (number_text < 80)
                    {
                        cutable_wires.Add(2);
                        Debug.LogFormat("[Green Wires #{0}] Cut wire 3.", _moduleID);
                    }
                    else if (number_text < 90)
                    {
                        cutable_wires.Add(3);
                        Debug.LogFormat("[Green Wires #{0}] Cut wire 4.", _moduleID);
                    }
                    else if (number_text < 100)
                    {
                        cutable_wires.Add(4);
                        Debug.LogFormat("[Green Wires #{0}] Cut wire 5.", _moduleID);
                    }
                }
                else if (purple_wire_index == 3)
                {
                    if (number_text < 10)
                    {
                        cutable_wires.Add(3);
                        Debug.LogFormat("[Green Wires #{0}] Cut wire 4.", _moduleID);
                    }
                    else if (number_text < 20)
                    {
                        cutable_wires.Add(4);
                        Debug.LogFormat("[Green Wires #{0}] Cut wire 5.", _moduleID);
                    }
                    else if (number_text < 30)
                    {
                        cutable_wires.Add(5);
                        Debug.LogFormat("[Green Wires #{0}] Cut wire 6.", _moduleID);
                    }
                    else if (number_text < 40)
                    {
                        cutable_wires.Add(6);
                        Debug.LogFormat("[Green Wires #{0}] Cut wire 7.", _moduleID);
                    }
                    else if (number_text < 50)
                    {
                        cutable_wires.Add(0);
                        Debug.LogFormat("[Green Wires #{0}] Cut wire 1.", _moduleID);
                    }
                    else if (number_text < 60)
                    {
                        cutable_wires.Add(1);
                        Debug.LogFormat("[Green Wires #{0}] Cut wire 2.", _moduleID);
                    }
                    else if (number_text < 70)
                    {
                        cutable_wires.Add(2);
                        Debug.LogFormat("[Green Wires #{0}] Cut wire 3.", _moduleID);
                    }
                    else if (number_text < 80)
                    {
                        cutable_wires.Add(3);
                        Debug.LogFormat("[Green Wires #{0}] Cut wire 4.", _moduleID);
                    }
                    else if (number_text < 90)
                    {
                        cutable_wires.Add(4);
                        Debug.LogFormat("[Green Wires #{0}] Cut wire 5.", _moduleID);
                    }
                    else if (number_text < 100)
                    {
                        cutable_wires.Add(5);
                        Debug.LogFormat("[Green Wires #{0}] Cut wire 6.", _moduleID);
                    }
                }
                else if (purple_wire_index == 4)
                {
                    if (number_text < 10)
                    {
                        cutable_wires.Add(4);
                        Debug.LogFormat("[Green Wires #{0}] Cut wire 5.", _moduleID);
                    }
                    else if (number_text < 20)
                    {
                        cutable_wires.Add(5);
                        Debug.LogFormat("[Green Wires #{0}] Cut wire 6.", _moduleID);
                    }
                    else if (number_text < 30)
                    {
                        cutable_wires.Add(6);
                        Debug.LogFormat("[Green Wires #{0}] Cut wire 7.", _moduleID);
                    }
                    else if (number_text < 40)
                    {
                        cutable_wires.Add(0);
                        Debug.LogFormat("[Green Wires #{0}] Cut wire 1.", _moduleID);
                    }
                    else if (number_text < 50)
                    {
                        cutable_wires.Add(1);
                        Debug.LogFormat("[Green Wires #{0}] Cut wire 2.", _moduleID);
                    }
                    else if (number_text < 60)
                    {
                        cutable_wires.Add(2);
                        Debug.LogFormat("[Green Wires #{0}] Cut wire 3.", _moduleID);
                    }
                    else if (number_text < 70)
                    {
                        cutable_wires.Add(3);
                        Debug.LogFormat("[Green Wires #{0}] Cut wire 4.", _moduleID);
                    }
                    else if (number_text < 80)
                    {
                        cutable_wires.Add(4);
                        Debug.LogFormat("[Green Wires #{0}] Cut wire 5.", _moduleID);
                    }
                    else if (number_text < 90)
                    {
                        cutable_wires.Add(5);
                        Debug.LogFormat("[Green Wires #{0}] Cut wire 6.", _moduleID);
                    }
                    else if (number_text < 100)
                    {
                        cutable_wires.Add(6);
                        Debug.LogFormat("[Green Wires #{0}] Cut wire 7.", _moduleID);
                    }
                }
                else if (purple_wire_index == 5)
                {
                    if (number_text < 10)
                    {
                        cutable_wires.Add(5);
                        Debug.LogFormat("[Green Wires #{0}] Cut wire 6.", _moduleID);
                    }
                    else if (number_text < 20)
                    {
                        cutable_wires.Add(6);
                        Debug.LogFormat("[Green Wires #{0}] Cut wire 7.", _moduleID);
                    }
                    else if (number_text < 30)
                    {
                        cutable_wires.Add(0);
                        Debug.LogFormat("[Green Wires #{0}] Cut wire 1.", _moduleID);
                    }
                    else if (number_text < 40)
                    {
                        cutable_wires.Add(1);
                        Debug.LogFormat("[Green Wires #{0}] Cut wire 2.", _moduleID);
                    }
                    else if (number_text < 50)
                    {
                        cutable_wires.Add(2);
                        Debug.LogFormat("[Green Wires #{0}] Cut wire 3.", _moduleID);
                    }
                    else if (number_text < 60)
                    {
                        cutable_wires.Add(3);
                        Debug.LogFormat("[Green Wires #{0}] Cut wire 4.", _moduleID);
                    }
                    else if (number_text < 70)
                    {
                        cutable_wires.Add(4);
                        Debug.LogFormat("[Green Wires #{0}] Cut wire 5.", _moduleID);
                    }
                    else if (number_text < 80)
                    {
                        cutable_wires.Add(5);
                        Debug.LogFormat("[Green Wires #{0}] Cut wire 6.", _moduleID);
                    }
                    else if (number_text < 90)
                    {
                        cutable_wires.Add(6);
                        Debug.LogFormat("[Green Wires #{0}] Cut wire 7.", _moduleID);
                    }
                    else if (number_text < 100)
                    {
                        cutable_wires.Add(0);
                        Debug.LogFormat("[Green Wires #{0}] Cut wire 1.", _moduleID);
                    }
                }
                else if (purple_wire_index == 6)
                {
                    if (number_text < 10)
                    {
                        cutable_wires.Add(6);
                        Debug.LogFormat("[Green Wires #{0}] Cut wire 7.", _moduleID);
                    }
                    else if (number_text < 20)
                    {
                        cutable_wires.Add(0);
                        Debug.LogFormat("[Green Wires #{0}] Cut wire 1.", _moduleID);
                    }
                    else if (number_text < 30)
                    {
                        cutable_wires.Add(1);
                        Debug.LogFormat("[Green Wires #{0}] Cut wire 2.", _moduleID);
                    }
                    else if (number_text < 40)
                    {
                        cutable_wires.Add(2);
                        Debug.LogFormat("[Green Wires #{0}] Cut wire 3.", _moduleID);
                    }
                    else if (number_text < 50)
                    {
                        cutable_wires.Add(3);
                        Debug.LogFormat("[Green Wires #{0}] Cut wire 4.", _moduleID);
                    }
                    else if (number_text < 60)
                    {
                        cutable_wires.Add(4);
                        Debug.LogFormat("[Green Wires #{0}] Cut wire 5.", _moduleID);
                    }
                    else if (number_text < 70)
                    {
                        cutable_wires.Add(5);
                        Debug.LogFormat("[Green Wires #{0}] Cut wire 6.", _moduleID);
                    }
                    else if (number_text < 80)
                    {
                        cutable_wires.Add(6);
                        Debug.LogFormat("[Green Wires #{0}] Cut wire 7.", _moduleID);
                    }
                    else if (number_text < 90)
                    {
                        cutable_wires.Add(0);
                        Debug.LogFormat("[Green Wires #{0}] Cut wire 1.", _moduleID);
                    }
                    else if (number_text < 100)
                    {
                        cutable_wires.Add(1);
                        Debug.LogFormat("[Green Wires #{0}] Cut wire 2.", _moduleID);
                    }
                }
            }
            else if (number_text % 50 == 00)
            {
                rule_taken = 1;
                cutable_wires.Add(1);
                Debug.LogFormat("[Green Wires #{0}] Cut wire 2.", _moduleID);
            }
            else if (number_text == 4 || number_text == 8 || number_text == 15 || number_text == 16 || number_text == 23 || number_text == 42)
            {
                rule_taken = 1;
                cutable_wires.Add(2);
                Debug.LogFormat("[Green Wires #{0}] Cut wire 3.", _moduleID);
            }
            else if (colors[2] == 8 || colors[5] == 8)
            {
                rule_taken = 1;
                cutable_wires.Add(3);
                Debug.LogFormat("[Green Wires #{0}] Cut wire 4.", _moduleID);
            }
            else if (colors[4] == 0)
            {
                rule_taken = 1;
                cutable_wires.Add(4);
                Debug.LogFormat("[Green Wires #{0}] Cut wire 5.", _moduleID);
            }
            else if (number_text == 69)
            {
                rule_taken = 1;
                cutable_wires.Add(6);
                Debug.LogFormat("[Green Wires #{0}] Cut wire 7.", _moduleID);
            }
            else if (colors[4] == 3)
            {
                rule_taken = 1;
                cutable_wires.Add(5);
                Debug.LogFormat("[Green Wires #{0}] Cut wire 6.", _moduleID);
            }
            else if (number_text == 7 || number_text == 14)
            {
                rule_taken = 1;
                cutable_wires.Add(0);
                Debug.LogFormat("[Green Wires #{0}] Cut wire 1.", _moduleID);
            }
            else if (colors[4] == 4 || colors[6] == 4)
            {
                rule_taken = 1;
                cutable_wires.Add(1);
                Debug.LogFormat("[Green Wires #{0}] Cut wire 2.", _moduleID);
            }
            else if (number_text % 17 == 0)
            {
                rule_taken = 1;
                cutable_wires.Add(3);
                Debug.LogFormat("[Green Wires #{0}] Cut wire 4.", _moduleID);
            }
            else if (colors[0] % 5 == 0)
            {
                rule_taken = 1;
                cutable_wires.Add(2);
                Debug.LogFormat("[Green Wires #{0}] Cut wire 3.", _moduleID);
            }
            else if (number_text == 28)
            {
                rule_taken = 1;
                cutable_wires.Add(6);
                Debug.LogFormat("[Green Wires #{0}] Cut wire 7.", _moduleID);
            }
            else if (number_text >= 90)
            {
                rule_taken = 1;
                cutable_wires.Add(4);
                Debug.LogFormat("[Green Wires #{0}] Cut wire 5.", _moduleID);
            }
            else if (colors[3] == 8)
            {
                rule_taken = 1;
                cutable_wires.Add(0);
                Debug.LogFormat("[Green Wires #{0}] Cut wire 1.", _moduleID);
            }
            else if (number_text == 48)
            {
                rule_taken = 1;
                cutable_wires.Add(5);
                Debug.LogFormat("[Green Wires #{0}] Cut wire 6.", _moduleID);
            }
            else if (colors[3] == 2)
            {
                rule_taken = 1;
                cutable_wires.Add(3);
                Debug.LogFormat("[Green Wires #{0}] Cut wire 4.", _moduleID);
            }
            else if (rule_taken == 0)
            {
                cutable_wires.Add(6);
                Debug.LogFormat("[Green Wires #{0}] Cut wire 7.", _moduleID);
            }
        for (int k = 0; k < Wires.Length; k++)
        {
            int x = k;
            Wires[x].OnInteract += delegate { CutWire(x); return false; };
        }
           
    }
    void CutWire(int pos)
    {
        if (module_solved)
        {
            return;
        }
        if (cutable_wires.Contains(pos))
        {
            module.HandlePass();
            CounterText.text = "GJ";
            module_solved = true;
            colors.Clear();
            cutable_wires.Clear();
            for (int i = 0; i < Wires.Length; i++)
            {
                if (i == 0)
                {
                    colors.Add(4);
                    Wires[i].GetComponent<MeshRenderer>().material.color = possibleColors[colors[i]];
                    ColorText[i].text = colorNames[colors[i]].ToString();
                }
                if (i == 1)
                {
                    colors.Add(8);
                    Wires[i].GetComponent<MeshRenderer>().material.color = possibleColors[colors[i]];
                    ColorText[i].text = colorNames[colors[i]].ToString();
                }
                if (i == 2)
                {
                    colors.Add(8);
                    Wires[i].GetComponent<MeshRenderer>().material.color = possibleColors[colors[i]];
                    ColorText[i].text = colorNames[colors[i]].ToString();
                }
                if (i == 3)
                {
                    colors.Add(1);
                    Wires[i].GetComponent<MeshRenderer>().material.color = possibleColors[colors[i]];
                    ColorText[i].text = colorNames[colors[i]].ToString();
                }
                if (i == 4)
                {
                    colors.Add(5);
                    Wires[i].GetComponent<MeshRenderer>().material.color = possibleColors[colors[i]];
                    ColorText[i].text = colorNames[colors[i]].ToString();
                }
                if (i == 5)
                {
                    colors.Add(8);
                    Wires[i].GetComponent<MeshRenderer>().material.color = possibleColors[colors[i]];
                    ColorText[i].text = colorNames[colors[i]].ToString();
                }
                if (i == 6)
                {
                    colors.Add(0);
                    Wires[i].GetComponent<MeshRenderer>().material.color = possibleColors[colors[i]];
                    ColorText[i].text = colorNames[colors[i]].ToString();
                }
            }
        }
        else
        {
            module.HandleStrike();
            module_solved = false;
        }
    }
}
