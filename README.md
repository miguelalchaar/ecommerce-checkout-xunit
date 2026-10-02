# EcommerceCheckout

![C#](https://img.shields.io/badge/C%23-.NET%2010-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![xUnit](https://img.shields.io/badge/xUnit-Testes%20Unit%C3%A1rios-5E2D91?style=for-the-badge&logo=dotnet&logoColor=white)
![Git](https://img.shields.io/badge/Git-Versionamento-orange?style=for-the-badge&logo=git&logoColor=white)
![GitHub](https://img.shields.io/badge/GitHub-Reposit%C3%B3rio-black?style=for-the-badge&logo=github&logoColor=white)
![License](https://img.shields.io/badge/Licen%C3%A7a-MIT-blue?style=for-the-badge)
![Status](https://img.shields.io/badge/Status-Conclu%C3%ADdo-brightgreen?style=for-the-badge)

Projeto desenvolvido para a disciplina de **Garantia da Qualidade de Software**, com foco na prática de **testes unitários com xUnit** em uma solução **.NET 10** criada inteiramente pela linha de comando (**.NET CLI**).

A atividade simula a implementação de um **serviço de checkout de e-commerce**, com métodos que retornam diferentes tipos de dados (`string`, `int` e `bool`), todos cobertos por testes automatizados.

Além da implementação do serviço, o principal objetivo da atividade é compreender como testes unitários ajudam a validar o comportamento esperado do código antes de ele ser entregue.

## ▸ Conceito da atividade

A atividade consiste na criação de um repositório chamado `ecommerce-checkout-xunit` e na implementação de uma solução composta por dois projetos:

Cada projeto possui uma responsabilidade específica dentro da solução.

O projeto `EcommerceCheckout.App` contém a classe `PedidoService`, com as regras de negócio. O projeto `EcommerceCheckout.Tests` referencia o projeto da aplicação e valida cada uma dessas regras por meio de testes automatizados.

Essa separação simula a estrutura utilizada em projetos reais, onde o código de produção e o código de teste ficam isolados, mas conectados por uma referência.

## ▸ Camadas da solução

### `EcommerceCheckout.App` - Código de Produção

O projeto `EcommerceCheckout.App` é uma aplicação de console que reúne a lógica do serviço de pedidos.

Neste projeto são implementados:

- A classe `PedidoService`;
- As regras de código de rastreio, pontos de fidelidade e frete grátis;
- Métodos com retornos dos tipos `string`, `int` e `bool`.

É a camada que representa o comportamento real do sistema.

### `EcommerceCheckout.Tests` - Testes Unitários

O projeto `EcommerceCheckout.Tests` representa o ambiente de **validação automatizada**.

Neste projeto ocorre:

- A criação de testes com o atributo `[Fact]`;
- A verificação dos retornos esperados com `Assert.Equal`, `Assert.True` e `Assert.False`;
- A garantia de que as regras de negócio continuam corretas após qualquer alteração.

Os testes funcionam como uma camada de segurança entre o código escrito e a confiança de que ele se comporta como esperado.

## ▸ Serviço de Pedido

A classe `PedidoService` é responsável por centralizar as regras relacionadas ao checkout da loja online.

| Método                                           | Retorno  | Regra                                                                                          |
| ------------------------------------------------ | -------- | ---------------------------------------------------------------------------------------------- |
| `GerarCodigoRastreio(regiao, numeroPedido)`      | `string` | Une a região em maiúsculas ao número do pedido com 4 dígitos (ex.: `SUDESTE-0042`)             |
| `CalcularPontosFidelidade(valorTotal)`           | `int`    | A cada R$ 10 em compras, o cliente ganha 2 pontos de fidelidade                                |
| `TemDireitoAFreteGratis(valorTotal, eClienteVIP)` | `bool`   | Frete grátis se o valor for maior ou igual a R$ 200 **ou** se o comprador for cliente VIP     |

**Exemplos:**

```text
GerarCodigoRastreio("sudeste", 42)     →  "SUDESTE-0042"
CalcularPontosFidelidade(150)          →  30    (150 / 10 = 15 parcelas de R$ 10 → 15 * 2)
TemDireitoAFreteGratis(150, true)      →  true
TemDireitoAFreteGratis(150, false)     →  false
```

## ▸ Testes unitários realizados

Foram escritos quatro testes na classe `PedidoServiceTests`, cobrindo cada tipo de retorno exigido na atividade.

| Tipo       | Método testado           | Asserção utilizada                            | O que valida                                              |
| ---------- | ------------------------ | --------------------------------------------- | --------------------------------------------------------- |
| **string** | `GerarCodigoRastreio`    | `Assert.Equal("SUDESTE-0042", resultado)`     | Máscara exata da região em maiúsculas e do pedido com 4 dígitos |
| **int**    | `CalcularPontosFidelidade` | `Assert.Equal(30, resultado)`               | Cálculo correto dos pontos de fidelidade                  |
| **bool**   | `TemDireitoAFreteGratis` | `Assert.True(...)` e `Assert.False(...)`      | Regras de frete grátis para VIP e não-VIP abaixo de R$ 200 |

### Teste 1 - string

Valida se `GerarCodigoRastreio` gera a máscara exata `SUDESTE-0042` a partir da região `"sudeste"` e do número de pedido `42`.

### Teste 2 - int

Valida se `CalcularPontosFidelidade` calcula os pontos corretamente para uma compra de R$ 150, retornando `30`.

### Teste 3 - bool

Valida as regras de frete grátis:

- `Assert.True(...)` para compra VIP abaixo de R$ 200 (`150` e `true`);
- `Assert.False(...)` para compra não-VIP abaixo de R$ 200 (`150` e `false`).


## ▸ Configuração via .NET CLI

Comandos utilizados para criar a estrutura da solução:

```bash
# 1. Cria a solução
dotnet new sln -n EcommerceCheckout

# 2. Cria o projeto da aplicação (código de produção)
dotnet new console -n EcommerceCheckout.App -f net10.0

# 3. Cria o projeto de testes unitários com xUnit
dotnet new xunit -n EcommerceCheckout.Tests -f net10.0

# 4. Adiciona ambos os projetos à solução
dotnet sln add EcommerceCheckout.App/EcommerceCheckout.App.csproj
dotnet sln add EcommerceCheckout.Tests/EcommerceCheckout.Tests.csproj

# 5. Adiciona a referência do projeto de produção no projeto de testes
dotnet add EcommerceCheckout.Tests/EcommerceCheckout.Tests.csproj reference EcommerceCheckout.App/EcommerceCheckout.App.csproj
```

## ▸ Como executar

**Pré-requisito:** possuir o [SDK do .NET 10](https://dotnet.microsoft.com/download) instalado na máquina.

1. Clone o repositório:

```bash
git clone https://github.com/miguelalchaar/ecommerce-checkout-xunit.git
```

2. Acesse a pasta do projeto:

```bash
cd ecommerce-checkout-xunit
```

3. Execute os testes unitários:

```bash
dotnet test
```

**Resultado esperado:**

```text
Passed!  - Failed: 0, Passed: 4, Skipped: 0, Total: 4
```

## ▸ Licença

Este projeto está licenciado sob a **Licença MIT**. Consulte o arquivo [LICENSE](LICENSE) para mais detalhes.

## ▸ Autor

Projeto desenvolvido pelos responsáveis pela implementação e manutenção do serviço:

- **miguelalchaar** - Desenvolvedor
