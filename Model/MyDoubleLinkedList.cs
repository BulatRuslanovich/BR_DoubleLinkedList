using System.Collections;

namespace MyDoubleLinkedList.Model {
    public class MyDoubleLinkedList<T> : IEnumerable<T> {
        private DuplexItem<T> Head;
        private DuplexItem<T> Tail;
        public int Count { get; private set; }

        public MyDoubleLinkedList() {}

        public MyDoubleLinkedList(T data) {
            var item = new DuplexItem<T>(data);
            Head = item;
            Tail = item;
            Count = 1;
        }

        public void Add(T data) {
            var item = new DuplexItem<T>(data);

            if (Count == 0) {
                Head = item;
                Tail = item;
                Count = 1;
                return;
            }

            Tail.Next = item;
            item.Previous = Tail;
            Tail = item;
            Count++;
        }

        public void Delete(T data) {
            if (Head.Data.Equals(data)) {
                Head.Next.Previous = null;
                Head = Head.Next;
                return;
            }

            var current = Head;

            while (current != null) {
                if (current.Data.Equals(data)) {
                    current.Previous.Next = current.Next;
                    current.Next.Previous = current.Previous;
                    Count--;
                    return;
                }

                current = current.Next;
            }
        }

        public MyDoubleLinkedList<T> Reverse() {
            var result = new MyDoubleLinkedList<T>();

            var current = Tail;

            while (current != null) {
                result.Add(current.Data);
                current = current.Previous;
            }

            return result;
        }

        public IEnumerator GetEnumerator() {
            var current = Head;

            while (current != null) {
                yield return current;
                current = current.Next;
            }
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator() {
            return (IEnumerator<T>)GetEnumerator();
        }
    }
}
