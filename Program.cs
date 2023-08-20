public class Node<T>
{
    public T Value { get; set; }
    public Node<T>? Next { get; set; }
    public Node<T>? Previous { get; set; } 

    //выделяем еще одну ячейку в памяти которая будет указывать или ссылаться на пред элемент

    public Node(T value)
    {
        Value = value;
    }
}

public sealed class DoubleLinkedList<T> : IEnumerable<T>
{
    public Node<T>? Root { get; private set; } // корневоый элемент или первый элемент
    public Node<T>? Tail { get; private set; } // последний элемент или хвост
    public int Count { get; private set; }

    public IEnumerator<T> GetEnumerator()
    {
        Node<T>? currentNode = Root;
        while (currentNode is not null)
        {
            yield return currentNode.Value;
            currentNode = currentNode.Next;
        }
    }

	System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
	{
        return GetEnumerator();
	}

    public void AddFirst(T item)
    {
        Node<T> newNode = new(item);

        if (Root is null)
        {
            Root = newNode;
            Tail = newNode; //если рут пустой то получается новый нод становится так и хвостовом так и рутовым элементом
        }
        else
        {
            newNode.Next = Root;
            Root.Previous = newNode;
            Root = newNode;
        }

        Count++;
    }

    public void AddLast(T item)
    {
        Node<T> newNode = new(item);

        if (Tail is null)
        {
            Root = newNode;
            Tail = newNode; //тоже самое как и пред примере
        }
        else
        {
            newNode.Previous = Tail;
            Tail.Next = newNode;
            Tail = newNode;
        }

        Count++;
    }
}
