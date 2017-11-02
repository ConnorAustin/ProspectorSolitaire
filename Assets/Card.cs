using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour {
	Sprite cardSprite;
	string suit;
	int rank; // From 0 (which is a 2) upwards to Ace

	void Start () {
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
