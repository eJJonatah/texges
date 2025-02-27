
using System.Buffers;
namespace Texges.TextManipulation.Managers;
using Abstraction;
using StringBldr = System.Text.StringBuilder;

/**
 * <inheritdoc cref="IStringInterpolator"/>
 * <remarks>
 * <i>Marcado como tipo ref o que possibilita a utilizacao de referencias da stack (como stackallocs) para bloco de memoria 
 * nas alteracoes do texto</i>
 * </remarks>
*/
// especializado em realizar alteracoes no texto como adicoes antes e depois e substituicoes em strings possibilitando ou nao o aluguel
// de memoria para previnir alocacao. Builder para multiplas instancias do tipo string e transferencia de conteudo construido, alem disso é
// marcado como um tipo ref o que possibilita a utilizacao de referencias da stack (como stackallocs) como bloco de memoria para alteracao do texto
//
public ref struct ValueStringBuilder
{
    // definicoes de criacao do objeto, "InitialSpace" pode referir a um bloco criado com stackalloc e sera utilizado para as operacoes
    // de alteracao do texto até que o espaco nao seja mais suficiente. "TextPool" é utilizado em operacoes de crescimento do
    // conteudo, alugando memoria necessaria para seguir as operacoes de texto e, caso nao seja forneco, novos arrays serao criados e
    // alocados na heap
    //
    /**
     * <value>
     * Piscina de memoria do sistema que é usada para operacoes de crescimento no bloco de texto, caso nao fornecido, novos
     * arrays serao criados e alocados na heap
     * </value>
    */ public extern MemoryPool<char> TextPool { get; init; }
    /**
     * <value>
     * Um espaco inicial (possivelmente um ponteiro da stack) onde serao executadas as alteracoes do texto antes que o espaco fonecido
     * se torne insuficiente para execucao de uma nova operacao, onde entao, um novo bloco sera criado/alugado e este nao 
     * sera mais utilizado
     * </value>
    */ public extern Span<char> InitialSpace { init; }

    // Retorna o comprimento do conteudo relevante escrito ate entao. Relevante para o metodo .TryCopyTo(... e .CloseAndCopyTo(Span)
    //
    /**
     * <value>Comprimento atual em conteudo relevante escrito pelo builder no bloco interno</value>
    */ public extern uint Length { get; }

    // leia sobre estes metodos em LazyFormattableString.h.cs:136
    // causam efeitos colaterais descartando este objeto, uma vez realizadas quaisquer umas das chamadas a seguir impedira a execucao de novas
    // pois os recursos dedicados à armazenagens das etapas e formatacao da string final serao devolvidos a seus respectivos proprietarios
    //
    /**
     * <inheritdoc cref="LazyFormattableString.CloseAndToString"/>
    */ public extern string CloseAndToString();
    /**
     * <inheritdoc cref="LazyFormattableString.CloseAndToArray"/>
    */ public extern char[] CloseAndToArray();
    /**
     * <inheritdoc cref="LazyFormattableString.CloseAndCopyTo(Span{char})"/>
    */ public extern void CloseAndCopyTo(Span<char> destination);
    /**
     * <inheritdoc cref="LazyFormattableString.CloseAndCopyTo(StringBldr)"/>
    */ public extern void CloseAndCopyTo(StringBldr bstr);
    /**
     * <inheritdoc cref="LazyFormattableString.CloseAndCopyTo(TextWriter)"/>
    */ public extern void CloseAndCopyTo(TextWriter tw);

    // ::IDisposable
    // devolve recursos propagados internamente para armazenar as etapas e valores referentes a formatacao e alteracao de texto
    // possivelmente retornando arrays alugados ou livrando memoria alocada em recursos nao gerenciados (ou nao automaticos). Pode ser que nao hajam
    // recursos a serem liberados, em situacoes de largo uso da memoria heap controlada pelo garbage collector sem piscinas compartilhdas o
    // (objeto se tona inutilizavel a partir desta chamada)
    //
    /**
     * <inheritdoc cref="LazyFormattableString.Dispose"/>
    */ public extern void Dispose();

    #region inherited features from IStringInterpolator

    // copia o conteudo alterado internamente para uma nova instancia alocada na heap
    //
    /**
     * <inheritdoc cref="IStringInterpolator.ToString"/>
    */ public extern override string ToString();
    /**
     * <inheritdoc cref="IStringInterpolator.ToArray"/>
    */ public extern char[] ToArray();

    // copia o conteudo alterado intermanete para o destino fornecido
    //
    /**
     * <inheritdoc cref="IStringInterpolator.TryCopyTo(Span{char})"/>
    */ public extern bool TryCopyTo(Span<char> dest);
    /**
     * <inheritdoc cref="IStringInterpolator.CopyTo(StringBldr)"/>
    */ public extern void CopyTo(StringBldr sb);
    /**
     * <inheritdoc cref="IStringInterpolator.CopyTo(TextWriter)"/>
    */ public extern void CopyTo(TextWriter tw);

    #endregion
    #region inherited features from IChangeTextStructure

    // adiciona o conteudo fornecido ao final do texto
    //
    /**
     * <inheritdoc cref="IChangeTextStructure.Write(ArraySegment{char})"/>
    */ public extern void Write(ArraySegment<char> arr);
    /**
     * <inheritdoc cref="IChangeTextStructure.Write(IEnumerable{char})"/>
    */ public extern void Write(IEnumerable<char> many);
    /**
     * <inheritdoc cref="IChangeTextStructure.Write(char, ushort)"/>
    */ public extern void Write(char c, ushort repeat);
    /**
     * <inheritdoc cref="IChangeTextStructure.Write(string)"/>
    */ public extern void Write([Const] string s);
    /**
     * <inheritdoc cref="IChangeTextStructure.Write(string)"/>
    */ public extern void Write(VString s);
    /**
     * <inheritdoc cref="IChangeTextStructure.Write(char)"/>
    */ public extern void Write(char c);

    // adiciona conteudo ao inicio
    //
    /**
     * <inheritdoc cref="IChangeTextStructure.Insert(ArraySegment{char})"/>
    */ public extern void Insert(ArraySegment<char> arr);
    /**
     * <inheritdoc cref="IChangeTextStructure.Insert(IEnumerable{char})"/>
    */ public extern void Insert(IEnumerable<char> many);
    /**
     * <inheritdoc cref="IChangeTextStructure.Insert(char, ushort)"/>
    */ public extern void Insert(char c, ushort repeat);
    /**
     * <inheritdoc cref="IChangeTextStructure.Insert(string)"/>
    */ public extern void Insert([Const] string s);
    /**
     * <inheritdoc cref="IChangeTextStructure.Insert(ReadOnlySpan{char})"/>
    */ public extern void Insert(VString s);
    /**
     * <inheritdoc cref="IChangeTextStructure.Insert(char)"/>
    */ public extern void Insert(char c);

    // substitui o conteudo encontrado em uma ocorrencia do que foi passado como "the" pelo o que foi passado em "with"
    //
    /**
     * <inheritdoc cref="IChangeTextStructure.ReplaceOnce(string, string)"/>
    */ public extern void ReplaceOnce([Const] string the, [Const] string with);
    /**
     * <inheritdoc cref="IChangeTextStructure.ReplaceOnce(string, string)"/>
    */ public extern void ReplaceOnce(VString the, [Const] string with);
    /**
     * <inheritdoc cref="IChangeTextStructure.ReplaceOnce(string, string)"/>
    */ public extern void ReplaceOnce([Const] string the, VString with);
    /**
     * <inheritdoc cref="IChangeTextStructure.ReplaceOnce(string, string)"/>
    */ public extern void ReplaceOnce(VString the, VString with);
    /**
     * <inheritdoc cref="IChangeTextStructure.ReplaceOnce(string, string)"/>
    */ public extern void ReplaceOnce(char the, VString with);
    /**
     * <inheritdoc cref="IChangeTextStructure.ReplaceOnce(string, string)"/>
    */ public extern void ReplaceOnce(VString the, char with);
    /**
     * <inheritdoc cref="IChangeTextStructure.ReplaceOnce(string, string)"/>
    */ public extern void ReplaceOnce(char the, char with);

    // substitui o conteudo encontrado em cada ocorrencia do que foi passado como "the" pelo o que foi passado em "with"
    // substitui no maximo a quantidade informada em "repeat"
    //
    /**
     * <inheritdoc cref="IChangeTextStructure.Replace(ShouldRepeat, string, string)"/>
    */ public extern void Replace(ShouldRepeat repeat, [Const] string the, [Const] string with);
    /**
     * <inheritdoc cref="IChangeTextStructure.Replace(ShouldRepeat, string, string)"/>
    */ public extern void Replace(ShouldRepeat repeat, VString the, [Const] string with);
    /**
     * <inheritdoc cref="IChangeTextStructure.Replace(ShouldRepeat, string, string)"/>
    */ public extern void Replace(ShouldRepeat repeat, [Const] string the, VString with);
    /**
     * <inheritdoc cref="IChangeTextStructure.Replace(ShouldRepeat, string, string)"/>
    */ public extern void Replace(ShouldRepeat repeat, VString the, VString with);
    /**
     * <inheritdoc cref="IChangeTextStructure.Replace(ShouldRepeat, string, string)"/>
    */ public extern void Replace(ShouldRepeat repeat, char the, VString with);
    /**
     * <inheritdoc cref="IChangeTextStructure.Replace(ShouldRepeat, string, string)"/>
    */ public extern void Replace(ShouldRepeat repeat, VString the, char with);
    /**
     * <inheritdoc cref="IChangeTextStructure.Replace(ShouldRepeat, string, string)"/>
    */ public extern void Replace(ShouldRepeat repeat, char the, char with);

    // oferecem um bloco de texto mutavel no final do conteudo com tamanho especificado para o metodo fornecido em As
    //
    /**
     * <inheritdoc cref="IChangeTextStructure.WriteOn"/>
    */ public extern void WriteOn(uint length, ActionSpanOf<char> As);

    // no inicio do conteudo
    //
    /**
     * <inheritdoc cref="IChangeTextStructure.InsertOn"/>
    */ public extern void InsertOn(uint length, ActionSpanOf<char> As);

    // alocado um novo bloco de texto com o tamanho baseado em length na posicao onde at for encontrado
    // sera repassado para a acao de alteracao apontada em As, caso nao haja espaco suficiente para o bloco de texto
    // o conteudo completo sera redimensionado conforme, esta operacao ocorre somente uma vez
    // 
    /**
     * <inheritdoc cref="IChangeTextStructure.ReplaceOnce(VString, string)"/>
    */ public extern void ReplaceOnceOn(uint length, [Const] string at, ActionSpanOf<char> As);
    /**
     * <inheritdoc cref="IChangeTextStructure.ReplaceOnce(VString, string)"/>
    */ public extern void ReplaceOnceOn(uint length, VString at, ActionSpanOf<char> As);
    /**
     * <inheritdoc cref="IChangeTextStructure.ReplaceOnce(VString, string)"/>
    */ public extern void ReplaceOnceOn(uint length, char at, ActionSpanOf<char> As);

    // a operacao acontece multiplas vezes, sendo no máximo a quantidade de vezes indiciada por repeat
    //
    /**
     * <inheritdoc cref="IChangeTextStructure.ReplaceOn(uint, ShouldRepeat, string, ActionSpanOf{char})"/>
    */ public extern void ReplaceOn(uint length, ShouldRepeat repeat, [Const] string at, ActionSpanOf<char> As);
    /**
     * <inheritdoc cref="IChangeTextStructure.ReplaceOn(uint, ShouldRepeat, string, ActionSpanOf{char})"/>
    */ public extern void ReplaceOn(uint length, ShouldRepeat repeat, VString at, ActionSpanOf<char> As);
    /**
     * <inheritdoc cref="IChangeTextStructure.ReplaceOn(uint, ShouldRepeat, string, ActionSpanOf{char})"/>
    */ public extern void ReplaceOn(uint length, ShouldRepeat repeat, char at, ActionSpanOf<char> As);

    #endregion
}