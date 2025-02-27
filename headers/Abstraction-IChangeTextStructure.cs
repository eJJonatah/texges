
namespace Texges.TextManipulation.Abstraction;

/**
 * <doc><summary>Fornece rotinas especializas em alteracao de um texto interno</summary></doc>
*/
// conjunto de funcoes especializadas em alteracao de textos, o objetivo dessa interface é fornecer uma padronizacao para construcao de instancias
// string encapsulando o gerenciamento de memoria sendo alugada ou alocada dependendo da implementacao
//
public interface IChangeTextStructure
{
    // adiciona o conteudo fornecido ao final do texto
    //
    /**
     * <doc><summary>Adiciona ao final do texto o conteudo de <paramref name="arr"/></summary></doc>
    */ void Write(ArraySegment<char> arr);
    /**
     * <doc><summary>Adiciona ao final do texto o conteudo de <paramref name="many"/></summary></doc>
    */ void Write(IEnumerable<char> many);
    /**
     * <doc>
     * <summary>
     * Adiciona ao final do texto o caractere "<paramref name="c"/>" a quantidade de vezes informadas em <paramref name="repeat"/>
     * </summary>
     * </doc>
    */ void Write(char c, ushort repeat);
    /**
     * <doc><summary>Adiciona ao final do texto o conteudo de <paramref name="s"/></summary></doc>
    */ void Write([Const] string s);
    /**
     * <doc><summary>Adiciona ao final do texto o conteudo de <paramref name="s"/></summary></doc>
    */ void Write(VString s);
    /**
     * <doc><summary>Adiciona ao final do texto o caractere "<paramref name="c"/>" uma vez</summary></doc>
    */ void Write(char c);

    // adiciona conteudo ao inicio
    //
    /**
     * <doc><summary>Adiciona ao inicio do texto o conteudo de <paramref name="arr"/></summary></doc>
    */ void Insert(ArraySegment<char> arr);
    /**
     * <doc><summary>Adiciona ao inicio do texto o conteudo de <paramref name="many"/></summary></doc>
    */ void Insert(IEnumerable<char> many);
    /**
     * <doc>
     * <summary>
     * Adiciona ao inicio do texto o caractere "<paramref name="c"/>" a quantidade de vezes informadas em <paramref name="repeat"/>
     * </summary>
     * </doc>
    */ void Insert(char c, ushort repeat);
    /**
     * <doc><summary>Adiciona ao inicio do texto o conteudo de <paramref name="s"/></summary></doc>
    */ void Insert([Const] string s);
    /**
     * <doc><summary>Adiciona ao inico do texto o conteudo de <paramref name="s"/></summary></doc>
    */ void Insert(VString s);
    /**
     * <doc><summary>Adiciona ao inicio do texto o caractere "<paramref name="c"/>" uma vez</summary></doc>
    */ void Insert(char c);

    // substitui o conteudo encontrado em uma ocorrencia do que foi passado como "the" pelo o que foi passado em "with"
    //
    /**
     * <doc><summary>Susbstitui uma ocorrencia do valor passado em <paramref name="the"/> pelo conteudo fornecido em <paramref name="with"/></summary></doc>
     * <param name="the">O valor a para ser localizado e substituido no texto</param>
     * <param name="with">O novo conteudo substituto para os valores encontrados</param>
    */ void ReplaceOnce([Const] string the, [Const] string with);
    /**
     * <inheritdoc cref="ReplaceOnce(string, string)"/>
    */ void ReplaceOnce(VString the, [Const] string with);
    /**
     * <inheritdoc cref="ReplaceOnce(string, string)"/>
    */ void ReplaceOnce([Const] string the, VString with);
    /**
     * <inheritdoc cref="ReplaceOnce(string, string)"/>
    */ void ReplaceOnce(VString the, VString with);
    /**
     * <inheritdoc cref="ReplaceOnce(string, string)"/>
    */ void ReplaceOnce(char the, VString with);
    /**
     * <inheritdoc cref="ReplaceOnce(string, string)"/>
    */ void ReplaceOnce(VString the, char with);
    /**
     * <inheritdoc cref="ReplaceOnce(string, string)"/>
    */ void ReplaceOnce(char the, char with);

    // substitui o conteudo encontrado em cada ocorrencia do que foi passado como "the" pelo o que foi passado em "with"
    // substitui no maximo a quantidade informada em "repeat"
    //
    /**
     * <doc>
     * <summary>
     * Susbstitui multiplas ocorrencia(s) do valor passado em <paramref name="the"/> a quantidade de vezes informada em <paramref name="repeat"/> 
     * pelo conteudo fornecido em <paramref name="with"/>
     * </summary>
     * </doc>
     * <param name="repeat">Quantidade de ocorrencias a serem substituidas, aceitando os padroes "Um", "Todos" ou um numero especificado</param>
     * <param name="with">O novo conteudo substituto para os valores encontrados</param>
     * <param name="the">O valor a para ser localizado e substituido no texto</param>
    */ void Replace(ShouldRepeat repeat, [Const] string the, [Const] string with);
    /**
     * <inheritdoc cref="Replace(ShouldRepeat, string, string)"/>
    */ void Replace(ShouldRepeat repeat, VString the, [Const] string with);
    /**
     * <inheritdoc cref="Replace(ShouldRepeat, string, string)"/>
    */ void Replace(ShouldRepeat repeat, [Const] string the, VString with);
    /**
     * <inheritdoc cref="Replace(ShouldRepeat, string, string)"/>
    */ void Replace(ShouldRepeat repeat, VString the, VString with);
    /**
     * <inheritdoc cref="Replace(ShouldRepeat, string, string)"/>
    */ void Replace(ShouldRepeat repeat, char the, VString with);
    /**
     * <inheritdoc cref="Replace(ShouldRepeat, string, string)"/>
    */ void Replace(ShouldRepeat repeat, VString the, char with);
    /**
     * <inheritdoc cref="Replace(ShouldRepeat, string, string)"/>
    */ void Replace(ShouldRepeat repeat, char the, char with);

    // oferecem um bloco de texto mutavel no final do conteudo com tamanho especificado para o metodo fornecido em As
    //
    /**
     * <doc>
     * <summary>
     * Obtem um bloco de texto mutavel com tamanho baseado em <paramref name="length"/> na posicao final do texto interno
     * e fornece esse bloco para a operacao de alteracao <paramref name="As"/>. (o texto sera expandido automaticamente)
     * </summary>
     * <param name="length">O tamanho do bloco de texto mutavel requerido para alteracao</param>
     * <param name="As">A acao que recebe o novo bloco de texto e o preenche conforme</param>
     * </doc>
    */ void WriteOn(uint length, ActionSpanOf<char> As);

    // no inicio do conteudo
    //
    /**
     * <doc>
     * <summary>
     * Obtem um bloco de texto mutavel com tamanho baseado em <paramref name="length"/> na posicao de inicio do texto interno
     * e fornece esse bloco para a operacao de alteracao <paramref name="As"/>. (caso nao haja tamanho suficiente no texto completo,
     * o redimensionamento acontecera automaticamente)
     * </summary>
     * <param name="length">O tamanho do bloco de texto mutavel requerido para alteracao</param>
     * <param name="As">A acao que recebe o novo bloco de texto e o preenche conforme</param>
     * </doc>
    */ void InsertOn(uint length, ActionSpanOf<char> As);

    // alocado um novo bloco de texto com o tamanho baseado em length na posicao onde at for encontrado
    // sera repassado para a acao de alteracao apontada em As, caso nao haja espaco suficiente para o bloco de texto
    // o conteudo completo sera redimensionado conforme, esta operacao ocorre somente uma vez
    // 
    /**
     * <doc>
     * <summary>
     * Obtem um bloco de texto mutavel com tamanho baseado em <paramref name="length"/> na posicao onde o conteudo do argumento
     * <paramref name="at"/> é encontrado no texto interno e, fornece esse bloco para a operacao de alteracao <paramref name="As"/>.
     * (caso nao haja tamanho suficiente no texto completo, o redimensionamento acontecera automaticamente). 
     * <strong>Esta operacao ocorre no maximo, uma vez</strong>
     * </summary>
     * <param name="length">O tamanho do bloco de texto mutavel requerido para alteracao</param>
     * <param name="at">O conteudo cuja posicao sera o inicio das alteracoes </param>
     * <param name="As">A acao que recebe o novo bloco de texto e o preenche conforme</param>
     * </doc>
    */ void ReplaceOnceOn(uint length, [Const] string at, ActionSpanOf<char> As);
    /**
     * <inheritdoc cref="ReplaceOn(uint, ShouldRepeat, string, ActionSpanOf{char})"/>
    */ void ReplaceOnceOn(uint length, VString at, ActionSpanOf<char> As);
    /**
     * <inheritdoc cref="ReplaceOn(uint, ShouldRepeat, string, ActionSpanOf{char})"/>
    */ void ReplaceOnceOn(uint length, char at, ActionSpanOf<char> As);

    // a operacao acontece multiplas vezes, sendo no máximo a quantidade de vezes indiciada por repeat
    //
    /**
     * <doc>
     * <summary>
     * Obtem um bloco de texto mutavel com tamanho baseado em <paramref name="length"/> na posicao onde o conteudo do argumento
     * <paramref name="at"/> é encontrado no texto interno e, fornece esse bloco para a operacao de alteracao <paramref name="As"/>.
     * (caso nao haja tamanho suficiente no texto completo, o redimensionamento acontecera automaticamente). Esta operacao ocorre no maximo, a quantidade de 
     * vezes indicada por <paramref name="repeat"/>
     * </summary>
     * <param name="length">O tamanho do bloco de texto mutavel requerido para alteracao</param>
     * <param name="repeat">Quantas vezes, no maximo, essa operacao pode se repetir</param>
     * <param name="at">O conteudo cuja posicao sera o inicio das alteracoes </param>
     * <param name="As">A acao que recebe o novo bloco de texto e o preenche conforme</param>
     * </doc>
    */ void ReplaceOn(uint length, ShouldRepeat repeat, [Const] string at, ActionSpanOf<char> As);
    /**
     * <inheritdoc cref="ReplaceOn(uint, ShouldRepeat, string, ActionSpanOf{char})"/>
    */ void ReplaceOn(uint length, ShouldRepeat repeat, VString at, ActionSpanOf<char> As);
    /**
     * <inheritdoc cref="ReplaceOn(uint, ShouldRepeat, string, ActionSpanOf{char})"/>
    */ void ReplaceOn(uint length, ShouldRepeat repeat, char at, ActionSpanOf<char> As);
}