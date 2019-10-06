using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class diologSystem : MonoBehaviour
{
    [SerializeField]
   private string[] contents;
    [SerializeField]
    private Text boxs;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {

    }

   public void resetArray(int newSize, string[] newwords)
    {
        contents = new string[newSize];
        for(int i = 0; i < contents.Length; i++)
        {
            contents[i] = newwords[i];
        }
    }

    public void runInstance(int currentSentens)
    {
        if(currentSentens <= contents.Length )
        {
            boxs.text = contents[currentSentens];
        }
        else
        {

        }
        
    }
}
