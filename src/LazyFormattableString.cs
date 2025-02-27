// precisa corresponder a definicao a LazyFormattableString.h.cs

namespace Texges.TextManipulation;
using Abstraction;

using StringBldr = System.Text.StringBuilder;

public readonly partial struct LazyFormattableString : IDisposable // publicly shipped api-definition
{
    public partial TextExpansion GetStaticContent(ushort key);

    public override partial string ToString();
    public partial char[] ToArray();

    public partial bool TryCopyTo(Span<char> dest);
    public partial void CopyTo(StringBldr sb);
    public partial void CopyTo(TextWriter tw);

    public partial void CloseAndCopyTo(Span<char> dest);
    public partial void CloseAndCopyTo(StringBldr sb);
    public partial void CloseAndCopyTo(TextWriter tw);
    public partial string CloseAndToString();
    public partial char[] CloseAndToArray();

    public partial void Dispose();
}