using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nametext;
    public TextMeshProUGUI Dtext;

    private Queue<string> sentences;

    public Animator animator;

    void Start()
    {
        sentences = new Queue<string>();
    }

  public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);
        //Debug.Log("StartingConversation with " + dialogue.characterName +"!");

        nametext.text = dialogue.characterName;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();

    }

    public void DisplayNextSentence()
    {
        if( sentences.Count == 0)
        {
            EndDialogue(); 
            return ;
        }

        string sentence = sentences.Dequeue();
        //Dtext.text = sentence; //asi el texto sale de corrido
        StopAllCoroutines(); //para que una frase no se anime sin antes haber acabado la anterior a ella
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence) //sirve para que el dialogo salga eltra por letra, solamente es estetico
    {
        Dtext.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            Dtext.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        Debug.Log("End of convewrsation!");
    }

}
