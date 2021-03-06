using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Custom_Linked_List
{
    public class CustomLinkedList<T>
    {
        private Node<T> _head;
        private Node<T> _tail;

        public int Count { get; set; }

        public void AddNode(T data)
        {
            Node<T> node = new Node<T>(data);

            if (_head == null)
            {
                _head = node;
            }
            else
            {
                _tail.Next = node;
            }

            _tail = node;
            Count++;
        }

        public bool Remove(T data)
        {
            Node<T> current = _head;
            Node<T> previous = null;
 
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    // Если узел в середине или в конце
                    if (previous != null)
                    {
                        // убираем узел current, теперь previous ссылается не на current, а на current.Next
                        previous.Next = current.Next;
 
                        // Если current.Next не установлен, значит узел последний,
                        // изменяем переменную tail
                        if (current.Next == null)
                        {
                            _tail = previous;
                        }
                    }
                    else
                    {
                        // если удаляется первый элемент
                        // переустанавливаем значение head
                        _head = _head.Next;
 
                        // если после удаления список пуст, сбрасываем tail
                        if (_head == null)
                        {
                            _tail = null;
                        }
                    }
                    
                    Count--;
                    
                    return true;
                }
 
                previous = current;
                current = current.Next;
            }

            return false;
        }

        public void Print()
        {   
            Node<T> current = _head;

            while (current != null)
            {
                System.Console.WriteLine(current);
                current = current.Next;
            }
        }
    }
}