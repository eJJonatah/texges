
namespace Texges.TextManipulation;
using Abstraction;

using StringBldr = System.Text.StringBuilder;

partial struct LazyFormattableString // internal source-implementation
{
    #region publicly shippep api-definition

    public partial TextExpansion GetStaticContent(ushort key)
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

    public partial void CloseAndCopyTo(Span<char> dest)
    {   throw new NotImplementedException()
    ;}
    public partial void CloseAndCopyTo(StringBldr sb)
    {   throw new NotImplementedException()
    ;}
    public partial void CloseAndCopyTo(TextWriter tw)
    {   throw new NotImplementedException()
    ;}
    public partial string CloseAndToString()
    {   throw new NotImplementedException()
    ;}
    public partial char[] CloseAndToArray()
    {   throw new NotImplementedException()
    ;}

    public partial void Dispose()
    {   throw new NotImplementedException()
    ;}

    #endregion
}
