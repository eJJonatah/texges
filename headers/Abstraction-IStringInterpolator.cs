
namespace Texges.TextManipulation.Abstraction;

using StringBldr = System.Text.StringBuilder;

/**
 * <doc>
 * <summary>
 * Builder especializado em instancias e representacoes de texto como <see cref="string"/>(s) para realizar alteracoes como adicao no inicio
 * e no final do conteudo e substituicao de valores encapsulando o gerenciamento de memoria alocado ou alugado de piscinas do sistema
 * </summary>
 * </doc>
*/ 
// especializado em realizar alteracoes no texto como adicoes antes e depois e substituicoes em strings possibilitando ou nao o aluguel
// de memoria para previnir alocacao. Builder para multiplas instancias do tipo string e transferencia de conteudo construido
//
public interface IStringInterpolator : IChangeTextStructure
{
    // copia o conteudo alterado internamente para uma nova instancia alocada na heap
    //
    /**
     * <returns>Uma nova instancia <see cref="string"/> com o conteudo alterado internamente</returns>
    */ string ToString();
    /**
     * <returns>Uma nova instancia <see cref="char"/>[ ] com o conteudo alterado internamente</returns>
    */ char[] ToArray();

    // copia o conteudo alterado intermanete para o destino fornecido
    //
    /**
     * <doc><summary>Copia o conteudo alterado internamente para o destino fornecido</summary></doc>
     * <returns>
     * <see langword="true"/> se a transferencia seguiu normalmente, se nao, <see langword="false"/> quando nao havia espaco suficente no destino
     * </returns>
    */ bool TryCopyTo(Span<char> dest);
    /**
     * <returns></returns>
     * <inheritdoc cref="TryCopyTo(Span{char})"/>
    */ void CopyTo(StringBldr sb);
    /**
     * <returns></returns>
     * <inheritdoc cref="TryCopyTo(Span{char})"/>
    */ void CopyTo(TextWriter tw);
}