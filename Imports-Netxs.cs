#pragma warning disable IDE0005

global using static NetxsGlobals;
global using Unsfe = System.Runtime.CompilerServices.Unsafe;
global using Mrshal = System.Runtime.InteropServices.Marshal;
global using MMrshal = System.Runtime.InteropServices.MemoryMarshal;
global using CLMrshal = System.Runtime.InteropServices.CollectionsMarshal;
global using NetRHelpers = System.Runtime.CompilerServices.RuntimeHelpers;
global using Interpl = System.Runtime.CompilerServices.DefaultInterpolatedStringHandler;
global using BString = System.ReadOnlySpan<byte>;
global using VString = System.ReadOnlySpan<char>;

global using ExpressionOfAttribute = System.Runtime.CompilerServices.CallerArgumentExpressionAttribute;
global using UnrequiresAttribute = System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute;
global using ConstAttribute = System.Diagnostics.CodeAnalysis.ConstantExpectedAttribute;
global using NNullAttribute = System.Diagnostics.CodeAnalysis.NotNullAttribute;
global using NNullIfAttribute = System.Diagnostics.CodeAnalysis.NotNullWhenAttribute;
global using NullAttribute = System.Diagnostics.CodeAnalysis.AllowNullAttribute;
global using MethodAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
global using EditorAttribute = System.ComponentModel.EditorBrowsableAttribute;
global using NoDebugAttribute = System.Diagnostics.DebuggerNonUserCodeAttribute;
global using UntraceAttribute = System.Diagnostics.StackTraceHiddenAttribute;
global using ViewAttribute = System.Diagnostics.DebuggerBrowsableAttribute;
global using EvalAttribute = System.Diagnostics.DebuggerDisplayAttribute;
global using HideAttribute = System.Diagnostics.DebuggerHiddenAttribute;
global using SkipAttribute = System.Diagnostics.DebuggerStepThroughAttribute;
global using LayAttribute = System.Runtime.InteropServices.StructLayoutAttribute;
global using IFAttribute = System.Diagnostics.ConditionalAttribute;
global using AttrAttribute = System.AttributeUsageAttribute;

using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.Globalization;
using System.Diagnostics;
using System.Buffers;
using System.Text;

/**
 * <doc>
 * <summary>This <see langword="class"/> is used statically as globally via ´<see langword="global using static"/>´ expression within this project or importer projects. All members in here exists everywhere simultaneously</summary>
 * </doc>
*/ [NoDebug] internal static partial class NetxsGlobals // global variables
{
    internal const string STRNQ = "{ToString(),nq}";
    internal const string DBGVL = "{debuggerDisplay(),nq}";
    internal const string DFLT_STR = "<default>$";
    internal const string DSPD_STR = @"/!\ _disposed";
    /**
     * <doc><summary>Is set to the definition in <see cref="byte"/>(s) of pointer instance's size, a <see langword="const"/> alternative for <see cref="nint.Size"/>. This is platform dependent</summary></doc>
     * <value><inheritdoc cref="CPU_ARCHITECTURE"/> <c>÷ <typeparamref name="_8"/></c></value>
    */ internal const byte CPUPTR_SIZE = CPU_ARCHITECTURE / 8; // eight bits per byte
    /**
     * <doc><summary>An integer value that represents a reasonably small allocation on the stack, for a <see langword="stackalloc"/> expression</summary></doc>
     * <value><inheritdoc cref="SMALLOC"/></value>
    */ internal const ushort SMALL_ONSTACK_SIZE = SMALLOC;
    /**
     * <doc><summary>An integer value that represents a large allocation on the stack, for a <see langword="stackalloc"/> expression</summary></doc>
     * <value><inheritdoc cref="BIGALOC"/></value>
    */ internal const ushort LARGE_ONSTACK_SIZE = BIGALOC;
    /**
     * <doc><summary>Max reasonable size for a <see cref="byte"/>[ ] array rental in the ´<c><see cref="System.Buffers.ArrayPool{T}.Shared"/></c>´ from the <i>.NET</i> <see langword="global"/> shared pool</summary></doc>
     * <value><c><typeparamref name="_65535"/></c></value>
    */ internal const ushort MAX_RENTABLE_SIZE = ushort.MaxValue; // which is *65535*
    /**
     * <doc><summary>Generic labeling for the ´<c>\n</c>´ expression as a <see cref="byte"/> in UTF-8</summary></doc>
    */ internal const byte NEW_LINE = (byte)'\n';
    /**
     * <doc><summary>Generic labeling for the ´ ´ expression as a <see cref="byte"/> in UTF-8</summary></doc>
    */ internal const byte EMPTY_SPACE = (byte)' ';
    /**
     * <doc><summary>Generic labeling for the ´<c>\0</c>´ expression as a <see cref="byte"/> in UTF-8</summary></doc>
    */ internal const byte ENDOF_STRING = (byte)'\0';
    /**
     * <doc><summary>Generic labeling for a number 1 take operation</summary></doc>
    */ internal const byte SINGLE_ITEM = 1;
    /**
     * <doc><summary>Generic labeling for a non-existent index integer</summary></doc>
    */ internal const short NOT_FOUND = -1;
    /**
     * <doc><summary>Generic labeling for the first index of an array</summary></doc>
    */ internal const byte FROM_START = 0;
    /**
     * <doc><summary>Generic labeling for a failed ´Try´ method pattern result</summary></doc>
    */ internal const bool FAILED = false;
    /**
     * <doc><summary>Generic labeling for an empty ´<see cref="System.Collections.IEnumerator.MoveNext()"/>´ of an IEnumerator</summary></doc>
    */ internal const bool EMPTY = false;
    /**
     * <doc><summary>Generic labeling for a zeroed return result</summary></doc>
    */ internal const byte ENDED = 0;
    /**
     * <doc><summary>Generic labeling for a number 2 in a division operation</summary></doc>
    */ internal const byte HALF = 2;

    internal const DebuggerBrowsableState DHIDE = DebuggerBrowsableState.Never;
    internal const EditorBrowsableState VSHIDE = EditorBrowsableState.Never;
    internal const MethodImplOptions INLINE = MethodImplOptions.AggressiveInlining;
    internal const MethodImplOptions FCALL = MethodImplOptions.NoInlining;
    internal const LayoutKind SEQC = LayoutKind.Sequential;
    internal const LayoutKind AUTO = LayoutKind.Auto;

    /**
     * <doc><summary>Shared <see langword="static global"/> instance of <see cref="Encoding"/> of UTF8, short term for <see cref="Encoding.UTF8"/></summary></doc>
    */ internal static readonly Encoding uTF8 = Encoding.UTF8;
    /**
     * <doc><summary>Shared <see langword="static global"/> instance of <see cref="CultureInfo"/> for Brazilian Portuguese. Use this instead of <see langword="new"/> instance expression. Used for input/output formatting</summary></doc>
    */ internal static readonly CultureInfo pt_Br = CultureInfo.CurrentCulture.Name == "pt-BR"? CultureInfo.CurrentCulture : CultureInfo.GetCultureInfo("pt-Br");
    /**
     * <doc><summary>Shared <see langword="static global"/> instance of <see cref="CultureInfo"/> for British English. Use this instead of <see langword="new"/> instance expression. Used for input/output formatting</summary></doc>
    */ internal static readonly CultureInfo en_Uk = CultureInfo.CurrentCulture.Name == "en-UK"? CultureInfo.CurrentCulture : CultureInfo.GetCultureInfo("en-Uk");
    /**
     * <doc><summary>Shared <see langword="static global"/> instance of <see cref="CultureInfo"/> for American English. Use this instead of <see langword="new"/> instance expression. Used for input/output formatting</summary></doc>
    */ internal static readonly CultureInfo en_Us = CultureInfo.InvariantCulture;
    /**
     * <doc>
     * <summary>The choosen memory pool. Might be ´<i>.NET shared</i>´ <see langword="global"/> memory pool from <see cref="System.Buffers.ArrayPool{T}.Shared"/><br/>
     * or <see langword="null"/> if it was specified not to use a shared pool when ´<c>DONT_SHARE_POOL</c>´ arg is present<br/>
     * or <see langword="new"/> internally created one if specified so when ´<c>AVOID_SHARED_POOL</c>´ arg is present <br/>
     * </summary>
     * </doc>
    */ internal static readonly ArrayPool<byte>? mempool;
    
    #region symbol dependent
    #region #define CPU_ARCHITECTURE
#if TARGET_64BIT
    /**
     * <value><c><typeparamref name="_64"/></c></value>
    */
#else
    /**
     * <value><c><typeparamref name="_32"/></c></value>
    */
#endif
    const byte CPU_ARCHITECTURE
#if TARGET_64BIT
        = 64;
#else
        = 32;
#endif
    #endregion
    #region #define SMALLOC
#if TARGET_64BIT
    /**
     * <value><c><typeparamref name="_512"/></c></value>
    */
#else
    /**
     * <value><c><typeparamref name="_256"/></c></value>
    */
#endif
    const ushort SMALLOC
#if TARGET_64BIT
        = 512;
#else
        = 256;
#endif
    #endregion
    #region #define BIGALOC
#if TARGET_64BIT
    /**
     * <value><c><typeparamref name="_4096"/></c></value>
    */
#else
    /**
     * <value><c><typeparamref name="_1024"/></c></value>
    */
#endif
    const ushort BIGALOC
#if TARGET_64BIT
        = 4096;
#else
        = 1024;
#endif
    #endregion
    #region #define DONT_SHARE_POOL
    const bool SYMBOL_DONTSHAREPOOL
#if !DEBUG && DONT_SHARE_POOL
        = true;
#else
        = false;
#endif
    #endregion
    #region #define AVOID_SHARED_POOL
    const bool SYMBOL_AVOIDSHAREDPOOL
#if !DEBUG && AVOID_SHARED_POOL
        = true;
#else
        = false;
#endif
    #endregion

    internal static readonly CultureInfo? cmdArgsCulture
#if NETXS_PTBR
        = pt_Br;
#elif NETXS_ENUK
        = en_Uk;
#elif NETXS_ENUS
        = en_Us;
#elif DEBUG
        = Environment.GetCommandLineArgs() switch
        {
            var args when args.Contains("NETXS_PTBR") => pt_Br,
            var args when args.Contains("NETXS_ENUK") => en_Uk,
            var args when args.Contains("NETXS_ENUS") => en_Us,
            _ => null
        };
#else
        = null;
#endif
    #endregion

    static NetxsGlobals()
    {
        var args = Environment.GetCommandLineArgs();
        mempool = args.Contains("DONT_SHARE_POOL") || SYMBOL_DONTSHAREPOOL ? null
            : args.Contains("AVOID_SHARED_POOL") || SYMBOL_AVOIDSHAREDPOOL
            ? ArrayPool<byte>.Create(MAX_RENTABLE_SIZE, CPU_ARCHITECTURE)
            : ArrayPool<byte>.Shared
        ;
    }

    // methods here are inlined manually
    /**
     * <doc>
     * <summary>
     * either 
     * <see cref="byte"/>,
     * <see cref="sbyte"/>,
     * <see cref="short"/>,
     * <see cref="ushort"/>,
     * <see cref="int"/>,
     * <see cref="uint"/>,
     * <see cref="long"/>,
     * <see cref="ulong"/>,
     * <see cref="float"/>,
     * <see cref="double"/>,
     * <br/>
     * or
     * <see cref="decimal"/>,
     * <see cref="object"/>,
     * <see cref="bool"/>,
     * <see cref="char"/>,
     * <see cref="string"/>,
     * <see cref="nint"/>,
     * <see cref="nuint"/>
     * <br/>
     * or <see cref="Type.FullName"/> when (<paramref name="fullName"/>: <see langword="true"/>)
     * <br/>
     * else <see cref="Type"/>.Name
     * </summary>
     * </doc>
    */ public static string nameofAlias<T>([Null] in T _0, bool fullName = false)
    {   return default(T) switch
        {
            byte => "byte",
            sbyte => "sbyte",
            short => "short",
            ushort => "ushort",
            int => "int",
            uint => "uint",
            long => "long",
            ulong => "ulong",
            float => "float",
            double => "double",
            decimal => "decimal",
            bool => "bool",
            char => "char",
            string => "string",
            nint => "nint",
            nuint => "nuint",
            object => "object",

            _ => fullName ? typeof(T).FullName ?? typeof(T).Name : typeof(T).Name,
        };
    }
    /**
     * <doc>
     * <summary>
     * either 
     * <see cref="byte"/>,
     * <see cref="sbyte"/>,
     * <see cref="short"/>,
     * <see cref="ushort"/>,
     * <see cref="int"/>,
     * <see cref="uint"/>,
     * <see cref="long"/>,
     * <see cref="ulong"/>,
     * <see cref="float"/>,
     * <see cref="double"/>,
     * <br/>
     * or
     * <see cref="decimal"/>,
     * <see cref="object"/>,
     * <see cref="bool"/>,
     * <see cref="char"/>,
     * <see cref="string"/>,
     * <see cref="nint"/>,
     * <see cref="nuint"/>
     * <br/>
     * or <see cref="Type.FullName"/> when (<paramref name="fullName"/>: <see langword="true"/>)
     * <br/>
     * else <see cref="Type"/>.Name
     * </summary>
     * </doc>
    */ public static string nameofAlias<T>(bool fullName = false)
    {   return default(T) switch
        {
            byte => "byte",
            sbyte => "sbyte",
            short => "short",
            ushort => "ushort",
            int => "int",
            uint => "uint",
            long => "long",
            ulong => "ulong",
            float => "float",
            double => "double",
            decimal => "decimal",
            bool => "bool",
            char => "char",
            string => "string",
            nint => "nint",
            nuint => "nuint",
            _ when typeof(T).Name == "object" => "object",

            _ => fullName ? typeof(T).FullName ?? typeof(T).Name : typeof(T).Name,
        };
    }
    /**
     * <inheritdoc cref="constAlias{T}()"/>
    */ public static ulong constAlias<T>(in T _0)
    {   return typeof(T) == typeof(string) ? (ulong)0x0000676e69727473 // 'string'
            : default(T) switch
            {                                   // (UTF8)
                byte    => 0x0000000065747962 , // 'byte'
                sbyte   => 0x0000006574796273 , // 'sbyte'
                short   => 0x00000074726f6873 , // 'short'
                ushort  => 0x000074726f687375 , // 'ushort'
                int     => 0x0000000000746e69 , // 'int'
                uint    => 0x00000000746e6975 , // 'uint'
                long    => 0x00000000676e6f6c , // 'long'
                ulong   => 0x000000676e6f6c75 , // 'ulong'
                float   => 0x00000074616f6c66 , // 'float'
                double  => 0x0000656c62756f64 , // 'double'
                decimal => 0x006c616d69636564 , // 'decimal'
                bool    => 0x000000006c6f6f62 , // 'bool'
                char    => 0x0000000072616863 , // 'char'
                nint    => 0x00000000746e696e , // 'nint'
                nuint   => 0x000000746e69756e , // 'nuint'
                object  => 0x00007463656a626f , // 'object'

                _ => default
            }
        ;

    }
    /**
     * <doc>
     * <summary>
     * <code>
     * ¨
     * |   type   |      returns      | (UTF8)
     * -------------------------------------------
     * is  <see cref="byte"/>    0x0000000065747962   'byte'
     * or  <see cref="sbyte"/>   0x0000006574796273   'sbyte'
     * or  <see cref="short"/>   0x00000074726f6873   'short'
     * or  <see cref="ushort"/>  0x000074726f687375   'ushort'
     * or  <see cref="int"/>     0x0000000000746e69   'int'
     * or  <see cref="uint"/>    0x00000000746e6975   'uint'
     * or  <see cref="long"/>    0x00000000676e6f6c   'long'
     * or  <see cref="ulong"/>   0x000000676e6f6c75   'ulong'
     * or  <see cref="float"/>   0x00000074616f6c66   'float'
     * or  <see cref="double"/>  0x0000656c62756f64   'double'
     * or  <see cref="decimal"/> 0x006c616d69636564   'decimal'
     * or  <see cref="bool"/>    0x000000006c6f6f62   'bool'
     * or  <see cref="char"/>    0x0000000072616863   'char'
     * or  <see cref="nint"/>    0x00000000746e696e   'nint'
     * or  <see cref="nuint"/>   0x000000746e69756e   'nuint'
     * or  <see cref="string"/>  0x0000676e69727473   'string'
     * or  <see cref="object"/>  0x00007463656a626f   'object'
     * else 0
     * </code>
     * </summary>
     * </doc>
    */ public static ulong constAlias<T>()
    {   return typeof(T) == typeof(string) ? (ulong)0x0000676e69727473 // 'string'
            : default(T) switch
            {                                   // (UTF8)
                byte    => 0x0000000065747962 , // 'byte'
                sbyte   => 0x0000006574796273 , // 'sbyte'
                short   => 0x00000074726f6873 , // 'short'
                ushort  => 0x000074726f687375 , // 'ushort'
                int     => 0x0000000000746e69 , // 'int'
                uint    => 0x00000000746e6975 , // 'uint'
                long    => 0x00000000676e6f6c , // 'long'
                ulong   => 0x000000676e6f6c75 , // 'ulong'
                float   => 0x00000074616f6c66 , // 'float'
                double  => 0x0000656c62756f64 , // 'double'
                decimal => 0x006c616d69636564 , // 'decimal'
                bool    => 0x000000006c6f6f62 , // 'bool'
                char    => 0x0000000072616863 , // 'char'
                nint    => 0x00000000746e696e , // 'nint'
                nuint   => 0x000000746e69756e , // 'nuint'
                object  => 0x00007463656a626f , // 'object'

                _ => default
            }
        ;

    }

    /**
     * <inheritdoc cref="msizeof{T}(ReadOnlySpan{T})"/>
    */ public static uint msizeof<T>([ReadOnly(true)] Span<T> valueSpan)
    {
        ushort eachSize; {
            int result = NetRHelpers.IsReferenceOrContainsReferences<T>()
                ? Unsfe.SizeOf<T>()
                : Mrshal.SizeOf<T>();

            Debug.Assert(ushort.MaxValue >= result, """
            No type should have a size bigger than ushort.MaxValue:65535
            """);

            eachSize = (ushort)result;
        }
        var fullSize = eachSize * (uint)valueSpan.Length;
        return fullSize;
    }
    /**
     * <doc>
     * <summary>
     * Identical to <see cref="msizeof{T}()"/> but this declaration calculates the binary-size of the whole <paramref name="valueSpan"/>
     * </summary>
     * </doc>
    */ public static uint msizeof<T>(ReadOnlySpan<T> valueSpan)
    {
        ushort eachSize; {
            int result = NetRHelpers.IsReferenceOrContainsReferences<T>()
                ? Unsfe.SizeOf<T>()
                : Mrshal.SizeOf<T>();

            Debug.Assert(ushort.MaxValue >= result, """
            No type should have a size bigger than ushort.MaxValue:65535
            """);

            eachSize = (ushort)result;
        }
        var fullSize = eachSize * (uint)valueSpan.Length;
        return fullSize;
    }
    /**
     * <doc>
     * <summary>
     * Identical to <see cref="msizeof{T}()"/> but this declaration calculates the binary-size of the whole memory allocated for ( <typeparamref name="T"/> ) within <paramref name="length"/>
     * </summary>
     * </doc>
    */ public static ulong msizeof<T>([Null] in T _0, uint length)
    {
        ushort eachSize; {
            int result = NetRHelpers.IsReferenceOrContainsReferences<T>()
                ? Unsfe.SizeOf<T>()
                : Mrshal.SizeOf<T>();

            Debug.Assert(ushort.MaxValue >= result, """
            No type should have a size bigger than ushort.MaxValue:65535
            """);

            eachSize = (ushort)result;
        }
        var fullSize = length * (ulong)eachSize;
        return fullSize;
    }
    /**
     * <doc><summary>Identical to <see cref="msizeof{T}()"/> but this declaration allows inference from a variable</summary></doc>
    */ public static ushort msizeof<T>([Null] in T _0)
    {
        int result = !NetRHelpers.IsReferenceOrContainsReferences<T>()
            ? Unsfe.SizeOf<T>()
            : Mrshal.SizeOf<T>();

        Debug.Assert(ushort.MaxValue >= result, """
            No type should have a size bigger than ushort.MaxValue:65535
            """);

        return (ushort)result;
    }
    /**
     * <doc>
     * <summary>
     * Identical to <see cref="msizeof{T}()"/> but this declaration calculates the binary-size of the whole <paramref name="array"/>
     * </summary>
     * </doc>
    */ public static uint msizeof<T>(T[] array)
    {
        ushort eachSize; {
            int result = NetRHelpers.IsReferenceOrContainsReferences<T>()
                ? Unsfe.SizeOf<T>()
                : Mrshal.SizeOf<T>();

            Debug.Assert(ushort.MaxValue >= result, """
            No type should have a size bigger than ushort.MaxValue:65535
            """);

            eachSize = (ushort)result;
        }
        var fullSize = eachSize * (uint)array.Length;
        return fullSize;
    }
    /**
     * <doc>
     * <summary>
     * Calcuates the binary-size of a ( <typeparamref name="T"/> ) instance through <see cref="Mrshal">Marshal</see> for classes and <see cref="Unsfe">Unsafe</see> for structures
     * </summary>
     * </doc>
    */ public static ushort msizeof<T>()
    {
        int result = !NetRHelpers.IsReferenceOrContainsReferences<T>()
            ? Unsfe.SizeOf<T>()
            : Mrshal.SizeOf<T>();

        Debug.Assert(ushort.MaxValue >= result, """
            No type should have a size bigger than ushort.MaxValue:65535
            """);

        return (ushort)result;
    }
}