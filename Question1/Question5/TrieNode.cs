using System.Collections.Generic;
using System.Linq;
namespace Question5
{
    public class TrieNode
    {
        public List<string> words = new List<string>();
        public TrieNode[] children = new TrieNode[26];

        public void Add(string word)
        {
            if (!string.IsNullOrWhiteSpace(word))
            {
                this.Add(word, ToAnagram(word), 0);
            }
        }

        public bool Search(string word)
        {
            if (string.IsNullOrWhiteSpace(word))
            {
                return false;
            }

            return this.Search(word, ToAnagram(word), 0);
        }
        public List<string> FindAnagram(string word)
        {
            if (string.IsNullOrWhiteSpace(word))
            {
                return new List<string>();
            }

            return this.FindAnagram(ToAnagram(word), 0);
        }

        public List<string> PrefixSearch(string word)
        {
            if (string.IsNullOrWhiteSpace(word))
            {
                return new List<string>();
            }

            return this.PrefixSearch(ToAnagram(word), 0);
        }

        private string ToAnagram(string word)
        {
            string result = new string(word.ToCharArray().ToList().OrderBy(x => x).ToArray());
            return result;
        }
        private void Add(string word, string anagram, int index)
        {
            if (index == word.Length)
            {
                this.words.Add(word);
            }
            else
            {
                if (children[anagram[index] - 'a'] == null)
                {
                    children[anagram[index] - 'a'] = new TrieNode();
                }

                children[anagram[index] - 'a'].Add(word, anagram, index + 1);
            }
        }

        private List<string> FindAnagram(string anagram, int index)
        {
            var result = new List<string>();
            if (index == anagram.Length)
            {
                result = this.words;
            }
            else if (children[anagram[index] - 'a'] != null)
            {
                result = children[anagram[index] - 'a'].FindAnagram(anagram, index + 1);
            }
            return result;
        }

        private bool Search(string word, string anagram, int index)
        {
            if (index == word.Length)
            {
                foreach (var item in this.words)
                {
                    if (item == word)
                    {
                        return true;
                    }
                }
            }
            else if (children[anagram[index] - 'a'] != null)
            {
                if (children[anagram[index] - 'a'].Search(word, anagram, index + 1))
                    return true;
            }
            return false;
        }

        private List<string> PrefixSearch(string prefix, int index)
        {
            var result = new List<string>();
            if (index == prefix.Length)
            {
                result.AddRange(this.AllWords());
            }
            else if (children[prefix[index] - 'a'] != null)
            {
                result.AddRange(this.words);
                result.AddRange(children[prefix[index] - 'a'].PrefixSearch(prefix, index + 1));
            }

            return result;
        }

        private List<string> AllWords()
        {
            var result = new List<string>();
            result.AddRange(this.words);
            foreach (var item in children)
            {
                if (item != null)
                {
                    result.AddRange(item.AllWords());
                }
            }

            return result;
        }
    }
}
