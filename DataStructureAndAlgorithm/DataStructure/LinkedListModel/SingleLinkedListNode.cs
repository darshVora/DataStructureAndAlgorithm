namespace DataStructureAndAlgorithm.DataStructure.LinkedListModel
{
    public class SingleLinkedListNode<T>(T value, SingleLinkedListNode<T>? next = default)
    {
        public T Value { get; set; } = value;
        public SingleLinkedListNode<T>? Next { get; set; } = next;
    }
}
