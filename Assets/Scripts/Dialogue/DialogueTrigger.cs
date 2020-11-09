using UnityEngine;

namespace Dialogue
{
	public class DialogueTrigger : MonoBehaviour {

		public global::Dialogue.Dialogue dialogue;
		[SerializeField] private DialogueManager _dialogueManager;

		private void OnEnable()
		{
			_dialogueManager.StartDialogue(dialogue);
		}

		public void TriggerDialogue ()
		{
			_dialogueManager.NextSentence();
		}

	}
}
