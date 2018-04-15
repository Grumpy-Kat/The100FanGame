using UnityEngine;
using System;
using System.Collections.Generic;

[Serializable]
public class Friendship {
	public Character character1 { get; protected set; }
	public Character character2 { get; protected set; }
	public int amount { get; protected set; }

	public Friendship(Character character1,Character character2,int amount){
		this.character1 = character1;
		this.character2 = character2;
		this.amount = amount;
	}

	public void AddAmount(int amt){
		amount += amt;
	}

	public void SetAmount(int amt){
		amount = amt;
	}
}

public class Character : MonoBehaviour {
	public string characterName = "";
	public Sprite characterSprite = null;
	
	public ExpandableList<Friendship> friendships = new ExpandableList<Friendship>();

	public Friendship GetFriendship(string charName){
		for(int i=0;i < friendships.Count();i++){
			if(friendships.Get(i).character1.characterName == charName){
				return friendships.Get(i);
			}
			if(friendships.Get(i).character2.characterName == charName){
				return friendships.Get(i);
			}
		}
		Character otherCharacter = GameObject.Find(charName).GetComponent<Character>();
		friendships.Add(new Friendship(this,otherCharacter,0));
		otherCharacter.AddFriendship(friendships.Get(friendships.Count()-1));
		return friendships.Get(friendships.Count()-1);
	}

	public void AddFriendship(Friendship friendship){
		friendships.Add(friendship);
	}

	public void AddFriendshipAmount(Friendship friendship,int amt){
		friendships.Get(friendships.IndexOf(friendship)).AddAmount(amt);
	}
	
	public void AddFriendshipAmount(int index,int amt){
		friendships.Get(index).AddAmount(amt);
	}
	
	public void SetFriendshipAmount(Friendship friendship,int amt){
		friendships.Get(friendships.IndexOf(friendship)).SetAmount(amt);
	}
	
	public void SetFriendshipAmount(int index,int amt){
		friendships.Get(index).SetAmount(amt);
	}
}