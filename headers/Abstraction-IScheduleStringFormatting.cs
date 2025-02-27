
namespace Texges.TextManipulation.Abstraction;

/**
 * <doc>
 * <summary>
 * Possui funcionalidades para construcao de <see cref="string"/>(s) inicializadas de forma "Lazy" em instancias <see cref="LazyFormattableString"/> onde as
 * operacoes de alteracao e formatacao nao ocorrem quando chamadas mas sim quando o conteudo final for invocado na instancia criada
 * atraves dos metodos <see cref="LazyFormattableString.ToString">.ToString()</see>, <see cref="LazyFormattableString.ToArray">.ToArray()</see>, e os mecanismos de copia
 * </summary>
 * </doc>
*/
// esta interface visa fornecer rotinas de manipulacao de texto "atrasada" de forma que, a manipulacao nao ocorre exatamente quando os
// metodos sao invocados, mas sim, quando o texto sera consumido. Cada um dos metodos de alteracao ou formatacao do texto
// prepara uma sequencia de procedimentos a serem executados assim que a construcao do texto final for invocada, postergando a alocacao
// definitiva de memoria. Essas rotinas de preparacao se baseam fortemente em alugel de memoria das piscinas do sistema, a responsabilidade
// de descarte/devolucao dos valores alugados é propagada à string final que implementa o fluxo ".Dispose()"
//
public interface IScheduleStringFormatting : IChangeTextStructure // apesar de combinar essas funcionalidades todas as operacoes de alteracao sao postergadas para a 'LazyFormattableString'
{
    // define o conteudo substituivel por valores padrao, geralmente sera um caractere, como '§' ou uma string pequena como "<value>"
    //
    /**
     * <doc><summary>Valor padrao do conteudo substituivel por valores (em producao poderá ser tanto <see cref="string"/> quanto <see cref="char"/>)</summary></doc>
    */ public string DefaultPlaceHolder { get; }

    // principal metodo e objetivo dessa interface. Retorna uma versao imutavel dos procedimentos que foram preparados ao longo das chamadas neste
    // padrao "builder" repassando os delegados combinados de formatacao/alteracao, conteudo estatico e memoria alugada para dentro da string formatavel, herdando
    // tambem a responsabilidade de devolucao e descarte destes recursos alocados ao seus forncedores de origem
    //
    /**
     * <doc>
     * <summary>
     * Descarta o objeto <see langword="this"/> repassando a responsabilidade de memoria para a instancia retornada. <strong>Novas instancias nao poderam 
     * ser criadas a partir dessa interface</strong>
     * </summary>
     * </doc>
     * <returns>
     * A instancia configurada de <see cref="string"/> formatavel que foi construida com base nas combinacoes de chamadas dos metodos desta 
     * interface.
     * </returns>
    */ LazyFormattableString GetLazilyPrepared();
    /**
     * <returns>
     * A instancia configurada de <see cref="string"/> formatavel que foi construida com base nas combinacoes de chamadas dos metodos desta 
     * interface. Todo conteudo e etapas sao copiados para este novo objeto permitindo multiplas invocacoes deste metodo
     * </returns>
    */ LazyFormattableString CopyLazilyPrepared();

    // preparadores para metodos de formatacao dos valores considerados de "tipos universais" Combina às rotinas de construcao/formatacao da string final
    // as operacoes de converesao de cada um dos valores repassados para os metodos preparadores que serao representados em texto quando
    // o conteudo resultante for requisitado. Os metodos a seguir adicionarao ao final do texto, as representacoes textuais dos valores repassados
    //
    /**
     * <doc><summary>Prepara a escrita do valor de <paramref name="value"/> formatado como texto que sera adicionado ao final do conteudo</summary></doc>
     * <param name="value">A ser formatado como texto quando a <see cref="string"/> final for requisitada</param>
    */ void WriteFormat(bool value);
    /**
     * <inheritdoc cref="WriteFormat(bool)"/>
    */ void WriteFormat(byte value);
    /**
     * <inheritdoc cref="WriteFormat(bool)"/>
    */ void WriteFormat(char value);
    /**
     * <inheritdoc cref="WriteFormat(bool)"/>
    */ void WriteFormat(short value);
    /**
     * <inheritdoc cref="WriteFormat(bool)"/>
    */ void WriteFormat(int value);
    /**
     * <inheritdoc cref="WriteFormat(bool)"/>
    */ void WriteFormat(long value);
    /**
     * <inheritdoc cref="WriteFormat(bool)"/>
    */ void WriteFormat(float value);
    /**
     * <inheritdoc cref="WriteFormat(bool)"/>
    */ void WriteFormat(double value);
    /**
     * <inheritdoc cref="WriteFormat(bool)"/>
    */ void WriteFormat(DateOnly value);
    /**
     * <inheritdoc cref="WriteFormat(bool)"/>
    */ void WriteFormat(TimeOnly value);
    /**
     * <inheritdoc cref="WriteFormat(bool)"/>
    */ void WriteFormat(DateTime value);
    /**
     * <inheritdoc cref="WriteFormat(bool)"/>
    */ void WriteFormat(Guid value);

    // adicionarao ao inicio
    //
    /**
     * <doc><summary>Prepara a escrita do valor de <paramref name="value"/> formatado como texto que sera adicionado ao inicio do conteudo</summary></doc>
     * <inheritdoc cref="WriteFormat(bool)"/>
    */ void InsertFormat(bool value);
    /**
     * <inheritdoc cref="InsertFormat(bool)"/>
    */ void InsertFormat(byte value);
    /**
     * <inheritdoc cref="InsertFormat(bool)"/>
    */ void InsertFormat(char value);
    /**
     * <inheritdoc cref="InsertFormat(bool)"/>
    */ void InsertFormat(short value);
    /**
     * <inheritdoc cref="InsertFormat(bool)"/>
    */ void InsertFormat(int value);
    /**
     * <inheritdoc cref="InsertFormat(bool)"/>
    */ void InsertFormat(long value);
    /**
     * <inheritdoc cref="InsertFormat(bool)"/>
    */ void InsertFormat(float value);
    /**
     * <inheritdoc cref="InsertFormat(bool)"/>
    */ void InsertFormat(double value);
    /**
     * <inheritdoc cref="InsertFormat(bool)"/>
    */ void InsertFormat(DateOnly value);
    /**
     * <inheritdoc cref="InsertFormat(bool)"/>
    */ void InsertFormat(TimeOnly value);
    /**
     * <inheritdoc cref="InsertFormat(bool)"/>
    */ void InsertFormat(DateTime value);
    /**
     * <inheritdoc cref="InsertFormat(bool)"/>
    */ void InsertFormat(Guid value);

    // substituirao uma correncia do conteudo padrao definido em DefaultPlaceHolder pelas representacoes textuais dos valores
    //
    /**
     * <doc>
     * <summary>
     * Prepara a substituicao de uma ocorrencia do valor do <c>DEFAULT_PLACEHOLDER</c> pelo valor de <paramref name="with"/> formatado 
     * como texto
     * </summary>
     * </doc>
     * <param name="with">A ser formatado como texto quando a <see cref="string"/> final for requisitada</param>
    */ void ReplaceSectionOnceFormat(bool with);
    /**
     * <inheritdoc cref="ReplaceSectionOnceFormat(bool)"/>
    */ void ReplaceSectionOnceFormat(byte with);
    /**
     * <inheritdoc cref="ReplaceSectionOnceFormat(bool)"/>
    */ void ReplaceSectionOnceFormat(char with);
    /**
     * <inheritdoc cref="ReplaceSectionOnceFormat(bool)"/>
    */ void ReplaceSectionOnceFormat(short with);
    /**
     * <inheritdoc cref="ReplaceSectionOnceFormat(bool)"/>
    */ void ReplaceSectionOnceFormat(int with);
    /**
     * <inheritdoc cref="ReplaceSectionOnceFormat(bool)"/>
    */ void ReplaceSectionOnceFormat(long with);
    /**
     * <inheritdoc cref="ReplaceSectionOnceFormat(bool)"/>
    */ void ReplaceSectionOnceFormat(float with);
    /**
     * <inheritdoc cref="ReplaceSectionOnceFormat(bool)"/>
    */ void ReplaceSectionOnceFormat(double with);
    /**
     * <inheritdoc cref="ReplaceSectionOnceFormat(bool)"/>
    */ void ReplaceSectionOnceFormat(DateOnly with);
    /**
     * <inheritdoc cref="ReplaceSectionOnceFormat(bool)"/>
    */ void ReplaceSectionOnceFormat(TimeOnly with);
    /**
     * <inheritdoc cref="ReplaceSectionOnceFormat(bool)"/>
    */ void ReplaceSectionOnceFormat(DateTime with);
    /**
     * <inheritdoc cref="ReplaceSectionOnceFormat(bool)"/>
    */ void ReplaceSectionOnceFormat(Guid with);

    // substituirao varias ocorrencias do conteudo padrao definido em DefaultPlaceHolder pelas representacoes textuais dos valores conforme o limite fornecido (em
    // times)
    //
    /**
     * <doc>
     * <summary>
     * Prepara a substituicao de ocorrencia(s) do valor do <c>DEFAULT_PLACEHOLDER</c> a quantidade de vezes informada em 
     * <paramref name="repeat"/> pelo valor de <paramref name="with"/> formatado 
     * como texto
     * </summary>
     * </doc>
     * <param name="with">A ser formatado como texto quando a <see cref="string"/> final for requisitada</param>
     * <param name="repeat">Quantidade de ocorrencias a serem substituidas, aceitando os padroes "Um", "Todos" ou um numero especificado</param>
    */ void ReplaceSectionFormat(ShouldRepeat repeat, bool with);
    /**
     * <inheritdoc cref="ReplaceSectionFormat(ShouldRepeat, bool)"/>
    */ void ReplaceSectionFormat(ShouldRepeat repeat, byte with);
    /**
     * <inheritdoc cref="ReplaceSectionFormat(ShouldRepeat, bool)"/>
    */ void ReplaceSectionFormat(ShouldRepeat repeat, char with);
    /**
     * <inheritdoc cref="ReplaceSectionFormat(ShouldRepeat, bool)"/>
    */ void ReplaceSectionFormat(ShouldRepeat repeat, short with);
    /**
     * <inheritdoc cref="ReplaceSectionFormat(ShouldRepeat, bool)"/>
    */ void ReplaceSectionFormat(ShouldRepeat repeat, int with);
    /**
     * <inheritdoc cref="ReplaceSectionFormat(ShouldRepeat, bool)"/>
    */ void ReplaceSectionFormat(ShouldRepeat repeat, long with);
    /**
     * <inheritdoc cref="ReplaceSectionFormat(ShouldRepeat, bool)"/>
    */ void ReplaceSectionFormat(ShouldRepeat repeat, float with);
    /**
     * <inheritdoc cref="ReplaceSectionFormat(ShouldRepeat, bool)"/>
    */ void ReplaceSectionFormat(ShouldRepeat repeat, double with);
    /**
     * <inheritdoc cref="ReplaceSectionFormat(ShouldRepeat, bool)"/>
    */ void ReplaceSectionFormat(ShouldRepeat repeat, DateOnly with);
    /**
     * <inheritdoc cref="ReplaceSectionFormat(ShouldRepeat, bool)"/>
    */ void ReplaceSectionFormat(ShouldRepeat repeat, TimeOnly with);
    /**
     * <inheritdoc cref="ReplaceSectionFormat(ShouldRepeat, bool)"/>
    */ void ReplaceSectionFormat(ShouldRepeat repeat, DateTime with);
    /**
     * <inheritdoc cref="ReplaceSectionFormat(ShouldRepeat, bool)"/>
    */ void ReplaceSectionFormat(ShouldRepeat repeat, Guid with);

    // substituirao uma ocorrencia do texto fornecido pelas representacoes textuais
    //
    /**
     * <doc>
     * <summary>
     * Prepara a substituicao de uma ocorrencia do valor <paramref name="the"/> pelo valor de <paramref name="with"/> formatado como texto
     * </summary>
     * </doc>
     * <param name="with">A ser formatado como texto quando a <see cref="string"/> final for requisitada</param>
     * <param name="the">O conteudo cujas ocorrencias no texto deverao ser substituidas</param>
    */ void ReplaceOnceFormat([Const] string the, bool with);
    /**
     * <inheritdoc cref="ReplaceOnceFormat(string, bool)"/>
    */ void ReplaceOnceFormat([Const] string the, byte with);
    /**
     * <inheritdoc cref="ReplaceOnceFormat(string, bool)"/>
    */ void ReplaceOnceFormat([Const] string the, char with);
    /**
     * <inheritdoc cref="ReplaceOnceFormat(string, bool)"/>
    */ void ReplaceOnceFormat([Const] string the, short with);
    /**
     * <inheritdoc cref="ReplaceOnceFormat(string, bool)"/>
    */ void ReplaceOnceFormat([Const] string the, int with);
    /**
     * <inheritdoc cref="ReplaceOnceFormat(string, bool)"/>
    */ void ReplaceOnceFormat([Const] string the, long with);
    /**
     * <inheritdoc cref="ReplaceOnceFormat(string, bool)"/>
    */ void ReplaceOnceFormat([Const] string the, float with);
    /**
     * <inheritdoc cref="ReplaceOnceFormat(string, bool)"/>
    */ void ReplaceOnceFormat([Const] string the, double with);
    /**
     * <inheritdoc cref="ReplaceOnceFormat(string, bool)"/>
    */ void ReplaceOnceFormat([Const] string the, DateOnly with);
    /**
     * <inheritdoc cref="ReplaceOnceFormat(string, bool)"/>
    */ void ReplaceOnceFormat([Const] string the, TimeOnly with);
    /**
     * <inheritdoc cref="ReplaceOnceFormat(string, bool)"/>
    */ void ReplaceOnceFormat([Const] string the, DateTime with);
    /**
     * <inheritdoc cref="ReplaceOnceFormat(string, bool)"/>
    */ void ReplaceOnceFormat([Const] string the, Guid with);
    /**
     * <inheritdoc cref="ReplaceOnceFormat(string, bool)"/>
    */ void ReplaceOnceFormat(VString the, bool with);
    /**
     * <inheritdoc cref="ReplaceOnceFormat(string, bool)"/>
    */ void ReplaceOnceFormat(VString the, byte with);
    /**
     * <inheritdoc cref="ReplaceOnceFormat(string, bool)"/>
    */ void ReplaceOnceFormat(VString the, char with);
    /**
     * <inheritdoc cref="ReplaceOnceFormat(string, bool)"/>
    */ void ReplaceOnceFormat(VString the, short with);
    /**
     * <inheritdoc cref="ReplaceOnceFormat(string, bool)"/>
    */ void ReplaceOnceFormat(VString the, int with);
    /**
     * <inheritdoc cref="ReplaceOnceFormat(string, bool)"/>
    */ void ReplaceOnceFormat(VString the, long with);
    /**
     * <inheritdoc cref="ReplaceOnceFormat(string, bool)"/>
    */ void ReplaceOnceFormat(VString the, float with);
    /**
     * <inheritdoc cref="ReplaceOnceFormat(string, bool)"/>
    */ void ReplaceOnceFormat(VString the, double with);
    /**
     * <inheritdoc cref="ReplaceOnceFormat(string, bool)"/>
    */ void ReplaceOnceFormat(VString the, DateOnly with);
    /**
     * <inheritdoc cref="ReplaceOnceFormat(string, bool)"/>
    */ void ReplaceOnceFormat(VString the, TimeOnly with);
    /**
     * <inheritdoc cref="ReplaceOnceFormat(string, bool)"/>
    */ void ReplaceOnceFormat(VString the, DateTime with);
    /**
     * <inheritdoc cref="ReplaceOnceFormat(string, bool)"/>
    */ void ReplaceOnceFormat(VString the, Guid with);
    /**
     * <inheritdoc cref="ReplaceOnceFormat(string, bool)"/>
    */ void ReplaceOnceFormat(char the, bool with);
    /**
     * <inheritdoc cref="ReplaceOnceFormat(string, bool)"/>
    */ void ReplaceOnceFormat(char the, byte with);
    /**
     * <inheritdoc cref="ReplaceOnceFormat(string, bool)"/>
    */ void ReplaceOnceFormat(char the, char with);
    /**
     * <inheritdoc cref="ReplaceOnceFormat(string, bool)"/>
    */ void ReplaceOnceFormat(char the, short with);
    /**
     * <inheritdoc cref="ReplaceOnceFormat(string, bool)"/>
    */ void ReplaceOnceFormat(char the, int with);
    /**
     * <inheritdoc cref="ReplaceOnceFormat(string, bool)"/>
    */ void ReplaceOnceFormat(char the, long with);
    /**
     * <inheritdoc cref="ReplaceOnceFormat(string, bool)"/>
    */ void ReplaceOnceFormat(char the, float with);
    /**
     * <inheritdoc cref="ReplaceOnceFormat(string, bool)"/>
    */ void ReplaceOnceFormat(char the, double with);
    /**
     * <inheritdoc cref="ReplaceOnceFormat(string, bool)"/>
    */ void ReplaceOnceFormat(char the, DateOnly with);
    /**
     * <inheritdoc cref="ReplaceOnceFormat(string, bool)"/>
    */ void ReplaceOnceFormat(char the, TimeOnly with);
    /**
     * <inheritdoc cref="ReplaceOnceFormat(string, bool)"/>
    */ void ReplaceOnceFormat(char the, DateTime with);
    /**
     * <inheritdoc cref="ReplaceOnceFormat(string, bool)"/>
    */ void ReplaceOnceFormat(char the, Guid with);

    // substituirao varias ocorrencias do texto fornecido pelas representacoes textuais conforme o limite fornecido (em times)
    //
    /**
     * <doc>
     * <summary>
     * Prepara a substituicao de ocorrencia(s) do valor <paramref name="the"/> pela quantidade de vezes informada em <paramref name="repeat"/> 
     * pelo valor de <paramref name="with"/> formatado como texto
     * </summary>
     * </doc>
     * <param name="repeat">Quantidade de ocorrencias a serem substituidas, aceitando os padroes "Um", "Todos" ou um numero especificado</param>
     * <param name="with">A ser formatado como texto quando a <see cref="string"/> final for requisitada</param>
     * <param name="the">O conteudo cujas ocorrencias no texto deverao ser substituidas</param>
    */ void ReplaceFormat(ShouldRepeat repeat, [Const] string the, bool with);
    /**
     * <inheritdoc cref="ReplaceFormat(ShouldRepeat, string, bool)"/>
    */ void ReplaceFormat(ShouldRepeat repeat, [Const] string the, byte with);
    /**
     * <inheritdoc cref="ReplaceFormat(ShouldRepeat, string, bool)"/>
    */ void ReplaceFormat(ShouldRepeat repeat, [Const] string the, char with);
    /**
     * <inheritdoc cref="ReplaceFormat(ShouldRepeat, string, bool)"/>
    */ void ReplaceFormat(ShouldRepeat repeat, [Const] string the, short with);
    /**
     * <inheritdoc cref="ReplaceFormat(ShouldRepeat, string, bool)"/>
    */ void ReplaceFormat(ShouldRepeat repeat, [Const] string the, int with);
    /**
     * <inheritdoc cref="ReplaceFormat(ShouldRepeat, string, bool)"/>
    */ void ReplaceFormat(ShouldRepeat repeat, [Const] string the, long with);
    /**
     * <inheritdoc cref="ReplaceFormat(ShouldRepeat, string, bool)"/>
    */ void ReplaceFormat(ShouldRepeat repeat, [Const] string the, float with);
    /**
     * <inheritdoc cref="ReplaceFormat(ShouldRepeat, string, bool)"/>
    */ void ReplaceFormat(ShouldRepeat repeat, [Const] string the, double with);
    /**
     * <inheritdoc cref="ReplaceFormat(ShouldRepeat, string, bool)"/>
    */ void ReplaceFormat(ShouldRepeat repeat, [Const] string the, DateOnly with);
    /**
     * <inheritdoc cref="ReplaceFormat(ShouldRepeat, string, bool)"/>
    */ void ReplaceFormat(ShouldRepeat repeat, [Const] string the, TimeOnly with);
    /**
     * <inheritdoc cref="ReplaceFormat(ShouldRepeat, string, bool)"/>
    */ void ReplaceFormat(ShouldRepeat repeat, [Const] string the, DateTime with);
    /**
     * <inheritdoc cref="ReplaceFormat(ShouldRepeat, string, bool)"/>
    */ void ReplaceFormat(ShouldRepeat repeat, [Const] string the, Guid with);
    /**
     * <inheritdoc cref="ReplaceFormat(ShouldRepeat, string, bool)"/>
    */ void ReplaceFormat(ShouldRepeat repeat, VString the, bool with);
    /**
     * <inheritdoc cref="ReplaceFormat(ShouldRepeat, string, bool)"/>
    */ void ReplaceFormat(ShouldRepeat repeat, VString the, byte with);
    /**
     * <inheritdoc cref="ReplaceFormat(ShouldRepeat, string, bool)"/>
    */ void ReplaceFormat(ShouldRepeat repeat, VString the, char with);
    /**
     * <inheritdoc cref="ReplaceFormat(ShouldRepeat, string, bool)"/>
    */ void ReplaceFormat(ShouldRepeat repeat, VString the, short with);
    /**
     * <inheritdoc cref="ReplaceFormat(ShouldRepeat, string, bool)"/>
    */ void ReplaceFormat(ShouldRepeat repeat, VString the, int with);
    /**
     * <inheritdoc cref="ReplaceFormat(ShouldRepeat, string, bool)"/>
    */ void ReplaceFormat(ShouldRepeat repeat, VString the, long with);
    /**
     * <inheritdoc cref="ReplaceFormat(ShouldRepeat, string, bool)"/>
    */ void ReplaceFormat(ShouldRepeat repeat, VString the, float with);
    /**
     * <inheritdoc cref="ReplaceFormat(ShouldRepeat, string, bool)"/>
    */ void ReplaceFormat(ShouldRepeat repeat, VString the, double with);
    /**
     * <inheritdoc cref="ReplaceFormat(ShouldRepeat, string, bool)"/>
    */ void ReplaceFormat(ShouldRepeat repeat, VString the, DateOnly with);
    /**
     * <inheritdoc cref="ReplaceFormat(ShouldRepeat, string, bool)"/>
    */ void ReplaceFormat(ShouldRepeat repeat, VString the, TimeOnly with);
    /**
     * <inheritdoc cref="ReplaceFormat(ShouldRepeat, string, bool)"/>
    */ void ReplaceFormat(ShouldRepeat repeat, VString the, DateTime with);
    /**
     * <inheritdoc cref="ReplaceFormat(ShouldRepeat, string, bool)"/>
    */ void ReplaceFormat(ShouldRepeat repeat, VString the, Guid with);
    /**
     * <inheritdoc cref="ReplaceFormat(ShouldRepeat, string, bool)"/>
    */ void ReplaceFormat(ShouldRepeat repeat, char the, bool with);
    /**
     * <inheritdoc cref="ReplaceFormat(ShouldRepeat, string, bool)"/>
    */ void ReplaceFormat(ShouldRepeat repeat, char the, byte with);
    /**
     * <inheritdoc cref="ReplaceFormat(ShouldRepeat, string, bool)"/>
    */ void ReplaceFormat(ShouldRepeat repeat, char the, char with);
    /**
     * <inheritdoc cref="ReplaceFormat(ShouldRepeat, string, bool)"/>
    */ void ReplaceFormat(ShouldRepeat repeat, char the, short with);
    /**
     * <inheritdoc cref="ReplaceFormat(ShouldRepeat, string, bool)"/>
    */ void ReplaceFormat(ShouldRepeat repeat, char the, int with);
    /**
     * <inheritdoc cref="ReplaceFormat(ShouldRepeat, string, bool)"/>
    */ void ReplaceFormat(ShouldRepeat repeat, char the, long with);
    /**
     * <inheritdoc cref="ReplaceFormat(ShouldRepeat, string, bool)"/>
    */ void ReplaceFormat(ShouldRepeat repeat, char the, float with);
    /**
     * <inheritdoc cref="ReplaceFormat(ShouldRepeat, string, bool)"/>
    */ void ReplaceFormat(ShouldRepeat repeat, char the, double with);
    /**
     * <inheritdoc cref="ReplaceFormat(ShouldRepeat, string, bool)"/>
    */ void ReplaceFormat(ShouldRepeat repeat, char the, DateOnly with);
    /**
     * <inheritdoc cref="ReplaceFormat(ShouldRepeat, string, bool)"/>
    */ void ReplaceFormat(ShouldRepeat repeat, char the, TimeOnly with);
    /**
     * <inheritdoc cref="ReplaceFormat(ShouldRepeat, string, bool)"/>
    */ void ReplaceFormat(ShouldRepeat repeat, char the, DateTime with);
    /**
     * <inheritdoc cref="ReplaceFormat(ShouldRepeat, string, bool)"/>
    */ void ReplaceFormat(ShouldRepeat repeat, char the, Guid with);
}