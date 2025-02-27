
using System.Buffers;
namespace Texges.TextManipulation.Abstraction;

// assinatura de um metodo que encapsula uma acao que consome uma regiao span de instancias do tipo T
//
/**
 * <doc><summary>Encapsula uma acao que consome uma instancia <see cref="Span{T}"/> (regiao de instancias do tipo <typeparamref name="T"/>)</summary></doc>
*/ public delegate void ActionSpanOf<T>(Span<T> span); // tipo absoluto nao requere implementacao

// nomeia as orperacoes comuns na alteracao do corpo do texto
//
/**
 * <doc><summary>Nomeia operacoes em alteracao de textos para instancias compactadas <see cref="LazyFormattableString"/></summary></doc>
*/ public enum TextExpansionDirections 
    
    // operacao de subistituir um conteudo demoninado "placeholder" por um outro valor providenciado. A estrutura em memoria que esta operacao apresenta
    // em "Content" é a primeira parte da sequencia sendo o placeholder e a segunda sendo o valor subistituto
    {   /**
         * <doc><summary>Operacao para substituicao de conteudo do texto, de um valor <c>'x'</c> para um valor <c>'y'</c></summary></doc>
        */ Replace = 1

    // operacao de adicionar ao unicio do conteudo do texto um valor providenciado. A estrutura em memoria que esta operacao apresenta
    // em "Content" é uma unica parte com o todo o conteudo da adicao
    //
    ,   /**
         * <doc><summary>Operacao para adicao de conteudo ao inicio do texto</summary></doc>
        */ Prepend

    // operacao de adicionar ao fim do conteudo do texto um valor providenciadoA estrutura em memoria que esta operacao apresenta em
    // "Content" é uma unica parte com o todo o conteudo da adicao
    //
    ,   /**
         * <doc><summary>Operacao para adicao de conteudo ao final do texto</summary></doc>
        */ Append
} // tipo absoluto nao requere implementacao

// Padrao mocking para um valor int que presenta uma indexacao com propriedades adicionais como "um" "varios" ou um limite numerico
//
/**
 * <doc>
 * <summary>Adiciona propriedades como "Um" e "Todos" a um valor <see cref="int"/> definindo a repeticao de operacoes 'replace'</summary>
 * </doc>
*/ public readonly struct ShouldRepeat(int limit)
{
    // instancias prontas com as propriedades adicionais de representarem valores "um" ou "varios"
    //
    /**
     * <doc><summary>Um valor <see cref="int"/> com a propriedade adicional de substituir somente uma vez</summary></doc>
    */ public static ShouldRepeat One => new(1);
    /**
     * <doc><summary>Um valor <see cref="int"/> com a propriedade adicional de substituir para todas as ocorrencias</summary></doc>
    */ public static ShouldRepeat All => new(0);

    // propriedades para verificacao rapida se o limite se refere a todos os valores 
    //
    private readonly int intern_value = limit;
    /**
     * <value><see langword="true"/> se todos as ocorrencias deverao ser substituidas, se nao, <see langword="false"/></value>
    */ public bool Always => intern_value is 0;
    /**
     * <value><see langword="true"/> se somente uma ocorrencia devera ser substituida, se nao, <see langword="false"/></value>
    */ public bool Once => intern_value is 1;
    /**
     * <doc><summary>Fornece um possivel valor limite para as ocorrencias de substituicoes</summary></doc>
     * <returns>
     * <see langword="true"/> se há um limite numerico definido para a quantidade de repeticoes, se nao, <see langword="false"/> quando 
     * somente um ou todos
     * </returns>
    */ public bool HasLimit(out ushort count)
    {
        if (Always)
        {
            count = default;
            return false;
        }
        if (Once)
        {
            count = 1;
            return true;
        }

        count = (ushort)intern_value;
        return true;
    }

    // como o valor "mockado" é de um "int" entao as conversoes vice e versa sao implementadas
    //
    /**
     * <inheritdoc/>
    */ [Skip] public static implicit operator int(ShouldRepeat from)
    {   return from.intern_value
    ;}
    /**
     * <inheritdoc/>
    */ [Skip] public static implicit operator ShouldRepeat(int onto)
    {   return new(onto)
    ;}
} // tipo absoluto nao requere implementacao

// armazena o conteudo referente a uma operacao de alteracao textual que pode ser da natureza de alguma das indicadas em
// "TextExpansionDirections" juntamente com um aviso logico se existem outros blocos textuais em sequencia assim como esse
//
/**
 * <doc><summary>Armazena uma operacao de alteracao conteudo para construcao de uma <see cref="LazyFormattableString"/></summary></doc>
 * <param name="Direction">Define a natureza do conteudo armazenado para operacao em <paramref name="Content"/></param>
 * <param name="Content">Valores abstratos em caracteres. O seu uso é indicado por sua natureza em <paramref name="Direction"/></param>
 * <param name="MoveNext">Se existem ou nao outras operacoes a seguir</param>
*/ public readonly record struct TextExpansion

    // define a natureza da operacao e a estrutura em que os valores necessarios se encontram em content
    //
    (   TextExpansionDirections Direction

    // um conteudo abstrato em caracteres. O seu uso é indicado pela natureza em Direction
    //
    ,   ReadOnlySequence<char> Content

    // se existem mais operacoes de alteracao presentes na estring formatavel
    //
    ,   bool MoveNext
); // tipo absoluto nao requere implementacao