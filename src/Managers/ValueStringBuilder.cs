// precisa corresponder a definicao a ValueStringBuilder.h.cs

using System.Buffers;
namespace Texges.TextManipulation.Managers;
using Abstraction;
using StringBldr = System.Text.StringBuilder;

public ref partial struct ValueStringBuilder  // publicly shipped api-definition
{
    public partial MemoryPool<char> TextPool { get; init; }
    public partial Span<char> InitialSpace { init; }

    public partial uint Length { get; }

    public partial string CloseAndToString();
    public partial char[] CloseAndToArray();
    public partial void CloseAndCopyTo(Span<char> destination);
    public partial void CloseAndCopyTo(StringBldr bstr);
    public partial void CloseAndCopyTo(TextWriter tw);

    public partial void Dispose();

    #region inherited features from IStringInterpolator

    public override partial string ToString();
    public partial char[] ToArray();

    public partial bool TryCopyTo(Span<char> dest);
    public partial void CopyTo(StringBldr sb);
    public partial void CopyTo(TextWriter tw);

    #endregion
    #region inherited features from IChangeTextStructure

    public partial void Write(ArraySegment<char> arr);
    public partial void Write(IEnumerable<char> many);
    public partial void Write(char c, ushort repeat);
    public partial void Write([Const] string s);
    public partial void Write(VString s);
    public partial void Write(char c);

    public partial void Insert(ArraySegment<char> arr);
    public partial void Insert(IEnumerable<char> many);
    public partial void Insert(char c, ushort repeat);
    public partial void Insert([Const] string s);
    public partial void Insert(VString s);
    public partial void Insert(char c);

    public partial void ReplaceOnce([Const] string the, [Const] string with);
    public partial void ReplaceOnce(VString the, [Const] string with);
    public partial void ReplaceOnce([Const] string the, VString with);
    public partial void ReplaceOnce(VString the, VString with);
    public partial void ReplaceOnce(char the, VString with);
    public partial void ReplaceOnce(VString the, char with);
    public partial void ReplaceOnce(char the, char with);

    public partial void Replace(ShouldRepeat repeat, [Const] string the, [Const] string with);
    public partial void Replace(ShouldRepeat repeat, VString the, [Const] string with);
    public partial void Replace(ShouldRepeat repeat, [Const] string the, VString with);
    public partial void Replace(ShouldRepeat repeat, VString the, VString with);
    public partial void Replace(ShouldRepeat repeat, char the, VString with);
    public partial void Replace(ShouldRepeat repeat, VString the, char with);
    public partial void Replace(ShouldRepeat repeat, char the, char with);

    public partial void WriteOn(uint length, ActionSpanOf<char> As);

    public partial void InsertOn(uint length, ActionSpanOf<char> As);

    public partial void ReplaceOnceOn(uint length, [Const] string at, ActionSpanOf<char> As);
    public partial void ReplaceOnceOn(uint length, VString at, ActionSpanOf<char> As);
    public partial void ReplaceOnceOn(uint length, char at, ActionSpanOf<char> As);

    public partial void ReplaceOn(uint length, ShouldRepeat repeat, [Const] string at, ActionSpanOf<char> As);
    public partial void ReplaceOn(uint length, ShouldRepeat repeat, VString at, ActionSpanOf<char> As);
    public partial void ReplaceOn(uint length, ShouldRepeat repeat, char at, ActionSpanOf<char> As);

    #endregion
}