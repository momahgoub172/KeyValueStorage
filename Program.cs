using KeyValueStorage;


//Testing app
try
{
    Trie Test = new Trie();
    Test.Put("a","Mahgoub");
    Test.Put("ab","Mahgoub2");
    Test.Put("abc","Mahgoub3");
    Test.Put("abd","Mahgoub2");
    Test.Put("abcdf","Mahgoub3");

    Console.WriteLine(Test.Get("abc").Data);
    Test.Delete("abc");
    var r2 = Test.Get("abc").Data;
    Console.WriteLine(r2);
}
catch
{
    Console.WriteLine("There is no value related to this key :( ");
}