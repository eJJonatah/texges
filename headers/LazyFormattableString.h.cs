
namespace Texges.TextManipulation;
using Abstraction;

using StringBldr = System.Text.StringBuilder;

/**
 * <doc>
 * <summary>
 * Carrega uma serie de instrucoes ainda nao executadas para criacao, alteracao e formatacao de instacias e representacoes de texto como 
 * <see cref="string"/>, <see cref="char"/>[], <see cref="VString"/> [...]. Especializada em postergar as operacoes para quando o texto é realmente
 * requisitado, se ele for.<para></para>
 * ( <i>contem possiveis referencias a recursos nao gerenciados, invocar <c></c>.<see cref="Dispose">Dispose</see>() apos o uso</i> )
 * </summary>
 * </doc>
*/
// carrega instrucoes de formatacao e alteracao mas cujas operacoes nao ocorreram ainda e, potencialmente, memoria compartilhada em forma de aluguel
// que precisa ser devolvida à piscina de origem. Por isso este objeto implementa o fluxo .Dispose() instancias deste objeto sao 
// o produto final do processo de preparacao de formatacao, utilizado somente para mover essa informacao pela sequencia de execucao
//
public readonly struct LazyFormattableString : IDisposable // devolucao de arrays/memoria repassados e exoneracao de responsabilidade
{
    // obtem o conteudo imutado inicial (possivelmente constante) repassado como formato a este agendamento. Invocar esta propriedade **nao** ira disparar o
    // processo de formatacao e retorna somente os blocos de texto absolutos imodificados. O conteudo estatico inicial de strings estarao sempre
    // nas primeiras posicoes As operacoes de replace sao alinhadas e retornadas no conteúdo dividas por um caractere nulo, sendo primeiro
    // o placeholder e o segundo o resultado. As operacoes sao organizadas na seguinte ordem { Prepend, Append e entao Replace } na
    // estrutura informada acima
    //
    /**
     * <doc>
     * <summary>
     * Obtem o conteudo de uma operacao de alteracao textual, com base no valor fornecido <paramref name="key"/> ( inicia 
     * em zero )
     * </summary>
     * </doc>
     * <param name="key">Um numero que representa o conteudo a ser obtido</param>
    */ public extern TextExpansion GetStaticContent(ushort key);

    // processa todas as etapas de formatacao e alteracao do texto e retorna o conteudo resultante essa operacao pode ocorrer multipas
    // vezes e nao causa efeitos colaterais. Nova memoria heap sera alocada para comportar os objetos resultantes string ou array
    //
    /**
     * <doc>
     * <summary>
     * Executa as operacoes de alteracao e formatacao e retorna o conteudo resultante em forma de <see cref="string"/> nao causa
     * efeitos colaterais e pode ser invocada multiplas vezes
     * </summary>
     * </doc>
     * <returns>A nova instancia <see cref="string"/> alocada na heap</returns>
    */ public extern override string ToString();
    /**
     * <doc>
     * <summary>
     * Executa as operacoes de alteracao e formatacao e retorna o conteudo resultante em forma de <see cref="char"/>[ ] nao causa
     * efeitos colaterais e pode ser invocada multiplas vezes
     * </summary>
     * </doc>
     * <returns>A nova instancia de <see cref="char"/>[ ] alocado na heap</returns>
    */ public extern char[] ToArray();

    // armazena o resultado internamente e move-o para os destinos informados. Dependedendo do tamanho do final pode ser necessario alugar ou
    // alocar mais memoria para satisfazer a extensao de todo o conteudo que sera movido
    //
    /**
     * <doc>
     * <summary>
     * Executa as operacoes de alteracao e formatacao e realiza a transferencia do conteudo. Esta chamada nao causa efeitos colaterais e
     * pode ser invocada multiplas vezes
     * </summary>
     * </doc>
     * <remarks>O conteudo resultante é transferido para <paramref name="dest"/></remarks>
     * <returns>
     * <see langword="true"/> se a transferencia seguiu normalmente, se nao, <see langword="false"/> quando nao havia espaco suficente no destino
     * </returns>
    */ public extern bool TryCopyTo(Span<char> dest);
    /**
     * <remarks>O conteudo resultante é transferido para <paramref name="sb"/></remarks>
     * <returns></returns>
     * <inheritdoc cref="TryCopyTo(Span{char})"/>
    */ public extern void CopyTo(StringBldr sb);
    /**
     * <remarks>O conteudo resultante é transferido para <paramref name="tw"/></remarks>
     * <returns></returns>
     * <inheritdoc cref="TryCopyTo(Span{char})"/>
    */ public extern void CopyTo(TextWriter tw);

    // mesmos procedimentos indicados acima porem estes metodos causam efeitos colaterais descartando este objeto, uma vez realizadas
    // quaisquer umas das chamadas a seguir impedira a execucao de novas pois os recursos dedicados à armazenagens das etapas e
    // formatacao da string final serao devolvidos a seus respectivos proprietarios
    //
    /**
     * <doc>
     * <summary>
     * Executa as operacoes de alteracao e formatacao e realiza a transferencia do conteudo. Esta chamada causa o descarte da instancia 
     * <see langword="this"/> e nenhuma outra chamada pode ser realizada na instancia atual
     * </summary>
     * <remarks>Causara um exception caso <paramref name="dest"/> nao possua tamanho suficiente para o conteudo completo (descarte ainda ocorre)</remarks>
     * </doc>
     * <remarks>O conteudo resultante é transferido para <paramref name="dest"/></remarks>
     * <returns>
     * <see langword="true"/> se a transferencia seguiu normalmente, se nao, <see langword="false"/> quando nao havia espaco suficente no destino
     * </returns>
     * <exception cref="InternalBufferOverflowException"/>
    */ public extern void CloseAndCopyTo(Span<char> dest);
    /**
     * <remarks>O conteudo resultante é transferido para <paramref name="sb"/></remarks>
     * <returns></returns>
     * <inheritdoc cref="CloseAndCopyTo(Span{char})"/>
    */ public extern void CloseAndCopyTo(StringBldr sb);
    /**
     * <remarks>O conteudo resultante é transferido para <paramref name="tw"/></remarks>
     * <returns></returns>
     * <inheritdoc cref="CloseAndCopyTo(Span{char})"/>
    */ public extern void CloseAndCopyTo(TextWriter tw);
    /**
     * <doc>
     * <summary>
     * Executa as operacoes de alteracao e formatacao e retorna o conteudo resultante em forma de <see cref="string"/>. <strong> esta 
     * operacao causa o decarte desse objeto e novas chamadas nao poderao ser realizadas</strong>
     * </summary>
     * </doc>
     * <returns>A nova instancia <see cref="string"/> alocada na heap</returns>
    */ public extern string CloseAndToString();
    /**
     * <doc>
     * <summary>
     * Executa as operacoes de alteracao e formatacao e retorna o conteudo resultante em forma de <see cref="char"/>[ ]. <strong> esta 
     * operacao causa o decarte desse objeto e novas chamadas nao poderao ser realizadas</strong>
     * </summary>
     * </doc>
     * <returns>A nova instancia de <see cref="char"/>[ ] alocado na heap</returns>
    */ public extern char[] CloseAndToArray();

    // ::IDisposable
    // devolve recursos propagados internamente para armazenar as etapas e valores referentes a formatacao e alteracao de texto
    // possivelmente retornando arrays alugados ou livrando memoria alocada em recursos nao gerenciados (ou nao automaticos). Pode ser que nao hajam
    // recursos a serem liberados, em situacoes de largo uso da memoria heap controlada pelo garbage collector sem piscinas compartilhdas o
    // (objeto se tona inutilizavel a partir desta chamada)
    //
    /**
     * <inheritdoc/>
    */ public extern void Dispose();
}