using System.Collections;
using System.Xml.Schema;

namespace KeyValueStorage;

public class Trie
{
    private TrieNode Root;

    public Trie()
    {
        Root = new TrieNode('\0');
    }

    public TrieNode Get(string key)
    {
        TrieNode Current = Root;
        foreach (var ch in key)
        {
            //if we did not found any node that contain this char
            if (!Current.Children.ContainsKey(ch))
            {
                return null;
            }
            // if we found this node that contains this char
            //go deeply in this tree
            Current = Current.Children[ch];
        }

        if (Current.IsWord)
        {
            return Current;
        }

        return null;
    }


    public void Put(string key, object value)
    {
        TrieNode Current = Root;
        foreach (var ch in key)
        {
            //if we did not found any node that contain this char
            if (!Current.Children.ContainsKey(ch))
            {
                //create a new node with this char
                Current.Children[ch] = new TrieNode(ch);
            }

            // if we found this node that contains this char
            //go deeply in this tree
            Current = Current.Children[ch];
        }

        Current.IsWord = true;
        Current.Data = value;
    }

    public bool Delete(string key)
    {
        var Current = Root;
        var path = new Stack<(TrieNode, char)>();
        foreach (var c in key)
        {
            if (!Current.Children.ContainsKey(c))
                return false;
            path.Push((Current,c));
            Current = Current.Children[c];
        }

        if (!Current.IsWord)
            return false;
        Current.IsWord = false;
        Current.Data = "";
        
        while (path.Count > 0)
        {
            var (parent, c) = path.Pop();
            if (Current.Children.Count == 0)
            {
                parent.Children.Remove(c);
                Current = parent;
            }
            else
            {
                break;
            }
        }

        return true;
    }
}