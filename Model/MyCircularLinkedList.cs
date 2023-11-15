using System.Collections;
using System.Collections.Generic;

namespace MyDoubleLinkedList.Model {
    public class MyCircularLinkedList<T> : IEnumerable {
        private DuplexItem<T> Head;
        public int Count { get; private set; }

        public MyCircularLinkedList() {}

        public MyCircularLinkedList(T data) {
            SetHeadItem(data);
        }

        public void Add(T data) {
            if (Count == 0) {
                SetHeadItem(data);
                return;
            }

            var item = new DuplexItem<T>(data);
            item.Next = Head;
            item.Previous = Head.Previous;
            Head.Previous.Next = item;
            Head.Previous = item;
        }

        private void SetHeadItem(T data) {
            Head = new DuplexItem<T>(data);
            Head.Next = Head;
            Head.Previous = Head;
            Count = 1;
        }

        public void Delete(T data) {
            if (Head.Data.Equals(data)) {
                RemoveItem(Head);
                Head = Head.Next;
                return;
            }

            var current = Head;

            for (int i = Count; i >= 0; i--) {
                if (current != null && current.Data.Equals(data)) {
                    RemoveItem(Head);
                    return;
                }

                current = current.Next;
            }
        }

        private void RemoveItem(DuplexItem<T> current) {
            current.Next.Previous = current.Previous;
            current.Previous.Next = current.Next;
            Count--;
        }

        public IEnumerator GetEnumerator() {
            var current = Head;

            for (int i = 0; i < Count; i++) {
                yield return current;
                current = current.Next;
            }
        }
    }
}
