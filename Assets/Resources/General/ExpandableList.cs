using UnityEngine;
using System;
using System.Collections.Generic;

[Serializable]
public class ExpandableList<T> {
	public List<T> list = new List<T>();

	public void Add(T item){
		if(list == null){
			list = new List<T>();
		}
		if(!list.Contains(item)){
			list.Add(item);
		}
	}

	public void Clear(){
		if(list == null){
			list = new List<T>();
		}
		list.Clear();
	}

	public bool Contains(T item){
		if(list == null){
			list = new List<T>();
		}
		return list.Contains(item);
	}

	public int Count(){
		if(list == null){
			list = new List<T>();
		}
		return list.Count;
	}

	public bool Equals(T item){
		if(list == null){
			list = new List<T>();
		}
		return list.Equals(item);
	}
	
	public T Get(int index){
		if(list == null){
			list = new List<T>();
		}
		return list[index];
	}

	public int Get(T item){
		if(list == null){
			list = new List<T>();
		}
		for(int i=0;i < list.Count;i++){
			if(list[i].Equals(item)){
				return i;
			}
		}
		list.Add(item);
		return list.Count-1;
	}

	public int IndexOf(T item){
		if(list == null){
			list = new List<T>();
		}
		return list.IndexOf(item);
	}

	public void Insert(int index,T item){
		if(list == null){
			list = new List<T>();
		}
		if(!list.Contains(item)){
			list.Insert(index,item);
		}
	}

	public void Remove(T item){
		if(list == null){
			list = new List<T>();
		}
		list.Remove(item);
	}

	public void RemoveAt(int index){
		if(list == null){
			list = new List<T>();
		}
		list.RemoveAt(index);
	}

	public void RemoveRange(int index,int count){
		if(list == null){
			list = new List<T>();
		}
		list.RemoveRange(index,count);
	}
}
