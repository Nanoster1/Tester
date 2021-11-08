using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Algorithms.FirstTask.ThirtTask
{
	public class LruCache<TKey, TValue>
	{
		private readonly int capacity;
		private readonly Dictionary<TKey, LinkedListNode<LruCacheItem<TKey, TValue>>> cache = new Dictionary<TKey, LinkedListNode<LruCacheItem<TKey, TValue>>>();
		private readonly System.Collections.Generic.LinkedList<LruCacheItem<TKey, TValue>> lastUsedItems = new System.Collections.Generic.LinkedList<LruCacheItem<TKey, TValue>>();

		public LruCache(int capacity)
		{
			this.capacity = capacity;
		}

		[MethodImpl(MethodImplOptions.Synchronized)]
		public bool TryGet(TKey key, out TValue value)
		{
			value = default(TValue);

			LinkedListNode<LruCacheItem<TKey, TValue>> node;
			if (!cache.TryGetValue(key, out node))
				return false;

			value = node.Value.Value;
			lastUsedItems.Remove(node);
			lastUsedItems.AddLast(node);
			return true;
		}

		[MethodImpl(MethodImplOptions.Synchronized)]
		public void Add(TKey key, TValue val)
		{
			if (cache.Count >= capacity)
				RemoveFirst();

			var cacheItem = new LruCacheItem<TKey, TValue>(key, val);
			var node = new LinkedListNode<LruCacheItem<TKey, TValue>>(cacheItem);
			lastUsedItems.AddLast(node);
			cache.Add(key, node);
		}

		private void RemoveFirst()
		{
			var node = lastUsedItems.First;
			lastUsedItems.RemoveFirst();

			/* Remove from cache */
			cache.Remove(node.Value.Key);
		}
	}

	internal class LruCacheItem<TKey, TValue>
	{
		public readonly TKey Key;
		public readonly TValue Value;

		public LruCacheItem(TKey k, TValue v)
		{
			Key = k;
			Value = v;
		}
	}
	interface INode<TValue>
	{
		public abstract TValue Value { get; }
		public INode<TValue> NextNode { get; }
		/// <summary>
		/// Connect node to this node
		/// </summary>
		/// <param name="node">node that will be linked with this node</param>
		public void ConnectNode(INode<TValue> node);
		public void RemoveConnect();
	}

	class OneLinkNode<TValue> : INode<TValue>
	{
		public OneLinkNode(TValue value)
		{
			this.Value = value;
		}
		public TValue Value { get; }
		public INode<TValue> NextNode { get; private set; }
		public void ConnectNode(INode<TValue> node)
		{
			if (node is OneLinkNode<TValue>)
				this.NextNode = node ?? throw new Exception("Array is Empty");
			else
				throw new Exception("not correct node");
		}
		public void RemoveConnect()
		{
			this.NextNode = null;
		}
		public override bool Equals(object obj)
		{
			if (obj is OneLinkNode<TValue> node)
				return Value.Equals(node.Value) && NextNode.Equals(node.NextNode);
			else
				return false;
		}

		public override int GetHashCode()
		{
			return Value == null ? 0 : Value.GetHashCode();
		}
		public static OneLinkNode<TValue> Copy(OneLinkNode<TValue> value)
		{
			if (value != null)
			{
				var node = new OneLinkNode<TValue>(value.Value);
				node.ConnectNode(value.NextNode);
				return node;
			}
			else
			{
				return null;
			}
		}
	}
	class TwoLinkNode<TValue> : INode<TValue>
	{
		public TwoLinkNode(TValue value)
		{
			this.Value = value;
		}
		public TValue Value { get; }
		public INode<TValue> NextNode { get; private set; }
		public INode<TValue> LastNode { get; private set; }

		public void ConnectNode(INode<TValue> node)
		{
			if (node is TwoLinkNode<TValue> twoNode)
			{
				twoNode.LastNode = this;
				this.NextNode = node ?? throw new Exception("Array is Empty");
			}
			else
			{
				throw new Exception("Uncorrect type of node");
			}
		}
		public void RemoveConnect()
		{
			this.NextNode = null;
		}
		public override bool Equals(object obj)
		{
			if (obj is OneLinkNode<TValue> node)
				return Value.Equals(node.Value) && NextNode.Equals(node.NextNode);
			else
				return false;
		}

		public override int GetHashCode()
		{
			return Value == null ? 0 : Value.GetHashCode();
		}
		public static TwoLinkNode<TValue> Copy(TwoLinkNode<TValue> value)
		{
			if (value != null)
			{
				var node = new TwoLinkNode<TValue>(value.Value);
				node.ConnectNode(value.NextNode);
				return node;
			}
			else
			{
				return null;
			}
		}
	}
	public class LinkedList<TValue> : IReadOnlyCollection<TValue>, IEnumerable<TValue>
	{
		private INode<TValue> firstNode;
		public LinkedList(TValue firstNode, int countOfTie)
		{
			switch (countOfTie)
			{
				case 1: this.firstNode = new OneLinkNode<TValue>(firstNode) ?? throw new Exception("Empty node"); break;
				case 2: this.firstNode = new TwoLinkNode<TValue>(firstNode) ?? throw new Exception("Empty node"); break;
			}
		}
		public TValue FirstNode => firstNode.Value;
		public int Count { get; private set; } = 1;
		public void AddOnBegin(TValue value)
		{
			var node = new OneLinkNode<TValue>(value);
			node.ConnectNode(firstNode);
			firstNode = node;
			Count++;
		}
		public void AddInEnd(TValue value)
		{
			var node = firstNode;

			if (firstNode == null)
				firstNode = new OneLinkNode<TValue>(value);
			while (node.NextNode != null)
				node = node.NextNode;

			Count++;
			node.ConnectNode(new OneLinkNode<TValue>(value));
		}
		public TValue RemoveLastNode()
		{
			var node = firstNode ?? throw new Exception("Collection is Empty");

			if (node.NextNode == null)
			{
				var value = firstNode.Value;
				this.firstNode = null;
				return value;
			}
			while (node.NextNode.NextNode != null)
			{
				node = node.NextNode;
			}

			Count--;
			var lastNode = node.NextNode.Value;
			node.NextNode.RemoveConnect();
			return lastNode;
		}
		public TValue RemoveFirstNode()
		{
			if (firstNode != null)
			{
				var node = firstNode.Value;
				if (firstNode.NextNode != null)
				{
					firstNode = firstNode.NextNode;
				}
				else
				{
					firstNode = null;
				}
				Count--;
				return node;
			}
			else
			{
				throw new Exception("List is Empty");
			}
		}
		public void Clear()
		{
			this.firstNode = null;
			this.Count = 0;
		}

		public IEnumerator<TValue> GetEnumerator()
		{
			INode<TValue> node = firstNode;
			yield return node.Value;
			while (node.NextNode != null)
			{
				node = node.NextNode;
				yield return node.Value;
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}

