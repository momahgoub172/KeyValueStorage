namespace KeyValueStorage;

public class TrieNode
{
    public char Character { get; set; }
    public Dictionary<char, TrieNode> Children;
    public bool IsWord { get; set; }
    public object Data { get; set; }

    public TrieNode(char c)
    {
        Character = c;
        Children = new Dictionary<char, TrieNode>();
        IsWord = false;
    }
}