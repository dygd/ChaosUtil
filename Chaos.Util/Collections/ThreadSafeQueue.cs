﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chaos.Util.Collections
{
	public class ThreadSafeQueue<T>
	{
		private Queue<T> queue = new Queue<T>();

		public void Enqueue(T element)
		{
			lock (queue)
			{
				queue.Enqueue(element);
			}
		}

		public bool TryDequeue(out T element)
		{
			lock (queue)
			{
				if (queue.Count > 0)
				{
					element = queue.Dequeue();
					return true;
				}
				else
				{
					element = default(T);
					return false;
				}
			}
		}

		public bool TryPeek(out T element)
		{
			lock (queue)
			{
				if (queue.Count > 0)
				{
					element = queue.Peek();
					return true;
				}
				else
				{
					element = default(T);
					return false;
				}
			}
		}

		public int Count
		{
			get
			{
				lock (queue)
				{
					return queue.Count;
				}
			}
		}
	}
}
