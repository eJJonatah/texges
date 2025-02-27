// precisa corresponder a definicao a ValueStringBuilder.h.cs

using System.Buffers;
namespace Texges.TextManipulation.Managers;
using Abstraction;
using StringBldr = System.Text.StringBuilder;

partial struct ValueStringBuilder  // internal source-implementation
{
    #region publicly shipped api-definition

    public partial MemoryPool<char> TextPool 
    {
        get => throw new NotImplementedException();
        init => throw new NotImplementedException();
    }
    public partial Span<char> InitialSpace 
    {   init => throw new NotImplementedException()
    ;}

    public partial uint Length
        => throw new NotImplementedException()
    ;

    public partial string CloseAndToString()
    {   throw new NotImplementedException()
    ;}
    public partial char[] CloseAndToArray()
    {   throw new NotImplementedException()
    ;}
    public partial void CloseAndCopyTo(Span<char> destination)
    {   throw new NotImplementedException()
    ;}
    public partial void CloseAndCopyTo(StringBldr bstr)
    {   throw new NotImplementedException()
    ;}
    public partial void CloseAndCopyTo(TextWriter tw)
    {   throw new NotImplementedException()
    ;}

    public partial void Dispose()
    {   throw new NotImplementedException()
    ;}

    public override partial string ToString()
    {   throw new NotImplementedException()
    ;}
    public partial char[] ToArray()
    {   throw new NotImplementedException()
    ;}

    public partial bool TryCopyTo(Span<char> dest)
    {   throw new NotImplementedException()
    ;}
    public partial void CopyTo(StringBldr sb)
    {   throw new NotImplementedException()
    ;}
    public partial void CopyTo(TextWriter tw)
    {   throw new NotImplementedException()
    ;}

    public partial void Write(ArraySegment<char> arr)
    {   throw new NotImplementedException()
    ;}
    public partial void Write(IEnumerable<char> many)
    {   throw new NotImplementedException()
    ;}
    public partial void Write(char c, ushort repeat)
    {   throw new NotImplementedException()
    ;}
    public partial void Write(string s)
    {   throw new NotImplementedException()
    ;}
    public partial void Write(VString s)
    {   throw new NotImplementedException()
    ;}
    public partial void Write(char c)
    {   throw new NotImplementedException()
    ;}

    public partial void Insert(ArraySegment<char> arr)
    {   throw new NotImplementedException()
    ;}
    public partial void Insert(IEnumerable<char> many)
    {   throw new NotImplementedException()
    ;}
    public partial void Insert(char c, ushort repeat)
    {   throw new NotImplementedException()
    ;}
    public partial void Insert(string s)
    {   throw new NotImplementedException()
    ;}
    public partial void Insert(VString s)
    {   throw new NotImplementedException()
    ;}
    public partial void Insert(char c)
    {   throw new NotImplementedException()
    ;}

    public partial void ReplaceOnce(string the, string with)
    {   throw new NotImplementedException()
    ;}
    public partial void ReplaceOnce(VString the, string with)
    {   throw new NotImplementedException()
    ;}
    public partial void ReplaceOnce(string the, VString with)
    {   throw new NotImplementedException()
    ;}
    public partial void ReplaceOnce(VString the, VString with)
    {   throw new NotImplementedException()
    ;}
    public partial void ReplaceOnce(char the, VString with)
    {   throw new NotImplementedException()
    ;}
    public partial void ReplaceOnce(VString the, char with)
    {   throw new NotImplementedException()
    ;}
    public partial void ReplaceOnce(char the, char with)
    {   throw new NotImplementedException()
    ;}

    public partial void Replace(ShouldRepeat repeat, string the, string with)
    {   throw new NotImplementedException()
    ;}
    public partial void Replace(ShouldRepeat repeat, VString the, string with)
    {   throw new NotImplementedException()
    ;}
    public partial void Replace(ShouldRepeat repeat, string the, VString with)
    {   throw new NotImplementedException()
    ;}
    public partial void Replace(ShouldRepeat repeat, VString the, VString with)
    {   throw new NotImplementedException()
    ;}
    public partial void Replace(ShouldRepeat repeat, char the, VString with)
    {   throw new NotImplementedException()
    ;}
    public partial void Replace(ShouldRepeat repeat, VString the, char with)
    {   throw new NotImplementedException()
    ;}
    public partial void Replace(ShouldRepeat repeat, char the, char with)
    {   throw new NotImplementedException()
    ;}

    public partial void WriteOn(uint length, ActionSpanOf<char> As)
    {   throw new NotImplementedException()
    ;}

    public partial void InsertOn(uint length, ActionSpanOf<char> As)
    {   throw new NotImplementedException()
    ;}

    public partial void ReplaceOnceOn(uint length, string at, ActionSpanOf<char> As)
    {   throw new NotImplementedException()
    ;}
    public partial void ReplaceOnceOn(uint length, VString at, ActionSpanOf<char> As)
    {   throw new NotImplementedException()
    ;}
    public partial void ReplaceOnceOn(uint length, char at, ActionSpanOf<char> As)
    {   throw new NotImplementedException()
    ;}

    public partial void ReplaceOn(uint length, ShouldRepeat repeat, string at, ActionSpanOf<char> As)
    {   throw new NotImplementedException()
    ;}
    public partial void ReplaceOn(uint length, ShouldRepeat repeat, VString at, ActionSpanOf<char> As)
    {   throw new NotImplementedException()
    ;}
    public partial void ReplaceOn(uint length, ShouldRepeat repeat, char at, ActionSpanOf<char> As)
    {   throw new NotImplementedException()
    ;}

    #endregion
}