using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour {
	Sprite cardSprite;
	Sprite cardbackSprite;
	string suit;
	int rank; // From 0 (which is a 2) upwards to Ace

	[HideInInspector]
	public List<Card> coveredBy = new List<Card> ();

	public bool faceUp = false;

	void Start () {
		cardbackSprite = GetComponent<SpriteRenderer> ().sprite;
	}

	public void Flip() {
		faceUp = !faceUp;
		var s = GetComponent<SpriteRenderer> ();
		if (faceUp) {
			s.sprite = cardSprite;
		} else {
			s.sprite = cardbackSprite;
		}
	}

	public void SetCard(int rank, string suit) {
		this.rank = rank;
		this.suit = suit;
		cardSprite = Deck.deck.getCardSprite (rank, suit);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
