using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialougeManager : MonoBehaviour
{
    public Text nameText;
    public Text dialougeText;
    private Queue<string> sentences;

    public GameObject diagroup;
    void Start()
    {
        sentences = new Queue<string>();
    }
    private float timetillnext;
    private void Update() 
    {
        //timetillnext -= Time.deltaTime;
        if(corunning==false && diagroup.activeInHierarchy&&Input.GetKeyDown(KeyCode.Space))
        {
            DisplayNextSentence();
            FindObjectOfType<AudioManager>().PlayPlayerSound("SpaceText");
            StartCoroutine(Waittrue());  
        }
        if(corunning==true && diagroup.activeInHierarchy&&Input.GetKeyDown(KeyCode.Space))
        {
            StopAllCoroutines();
            dialougeText.text = story; 
            StartCoroutine(Waitfalse());
        }
    }
    IEnumerator PlayText()
	{                
        string sentence = sentences.Dequeue();
        story = sentence;
		dialougeText.text = "";
		foreach (char c in story) 
		{   
			dialougeText.text += c;
            FindObjectOfType<AudioManager>().PlayPlayerSound("Typing");
            yield return new WaitForSecondsRealtime(0.0625f);
        }
        if(dialougeText.text == story)
        {
            corunning = false;
        }
	}
    IEnumerator Waitfalse()
    {
        yield return new WaitForSecondsRealtime(0.05f);
        corunning=false;
    }
    IEnumerator Waittrue()
    {
 
        yield return new WaitForSecondsRealtime(0.05f);
        corunning=true;
    }
    public void StartDialouge(Dialouger dialouge)
    {
        nameText.text = dialouge.name;
        sentences.Clear();
        foreach(string sentence in dialouge.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }
    string story;
    public void DisplayNextSentence()
    {
        if(sentences.Count > 39-5)
        {
            StartCoroutine(PlayText());
            return;
        }
        if(sentences.Count == 39-5)
        {
            EndDialouge();
            return;
        }
        if(sentences.Count > 39-10)
        {
            StartCoroutine(PlayText());
            return;
        }
        if(sentences.Count == 39-10)
        {
            EndDialouge();
            return;
        }
        if(sentences.Count > 39-15)
        {
            StartCoroutine(PlayText());
            return;
        }
        if(sentences.Count == 39-15)
        {
            EndDialouge();
            return;
        }
        if(sentences.Count > 39-20)
        {
            StartCoroutine(PlayText());
            return;
        }
        if(sentences.Count == 39-20)
        {
            EndDialouge();
            return;
        }
        if(sentences.Count > 39-25)
        {
            StartCoroutine(PlayText());
            return;
        }
        if(sentences.Count == 39-25)
        {
            EndDialouge();
            return;
        }
        if(sentences.Count > 39-30)
        {
            StartCoroutine(PlayText());
            return;
        }
        if(sentences.Count == 39-30)
        {
            EndDialouge();
            return;
        }
        if(sentences.Count > 39-35)
        {
            StartCoroutine(PlayText());
            return;
        }
        if(sentences.Count == 39-35)
        {
            EndDialouge();
            return;
        }
        if(sentences.Count > 39-39)
        {
            StartCoroutine(PlayText());
            return;
        }
        if(sentences.Count == 39-39)
        {
            EndDialouge();
            return;
        }
    }

    public static bool corunning = true;
    void EndDialouge()
    {
        Time.timeScale = 1f;
        diagroup.SetActive(false);
    }
}
