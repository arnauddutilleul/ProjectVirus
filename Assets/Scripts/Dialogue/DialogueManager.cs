using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Dialogue
{
    public class DialogueManager : MonoBehaviour
    {
        public TextMeshProUGUI nameText;
        public TextMeshProUGUI dialogueText;
        
        private Queue<string> _sentences = new Queue<string>();
        private static readonly int IsOpen = Animator.StringToHash("IsOpen");
        [SerializeField] private UnityEvent startGame;


        public void StartDialogue(global::Dialogue.Dialogue dialogue)
        {
            nameText.text = dialogue.name;

            _sentences.Clear();

            foreach (var sentence in dialogue.sentences)
            {
                _sentences.Enqueue(sentence);
            }

            NextSentence();
        }

        public void NextSentence()
        {
            if (_sentences.Count == 0)
            {
                EndDialogue();
                return;
            }

            var sentence = _sentences.Dequeue();
            StopAllCoroutines();
            StartCoroutine(SentencesRoutine(sentence));
        }

        private IEnumerator SentencesRoutine(string sentence)
        {
            var wait = new WaitForSeconds(0.1f);
            dialogueText.text = "";
            foreach (var letter in sentence.ToCharArray())
            {
                dialogueText.text += letter;
                yield return wait;
            }
        }

        private void EndDialogue()
        {
            startGame?.Invoke();
        }
    }
}