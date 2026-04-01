# 💰 Dima - Sistema de Gestão Financeira (SaaS)

## 📌 Sobre o Projeto
O **Dima** é um sistema de gestão financeira desenvolvido em **.NET 9**, voltado para controle de **entradas e saídas** financeiras em modo **SaaS**.  
Além da gestão financeira, o sistema possui integração com o **Stripe** para venda de cursos online.

---

## 🏗️ Estrutura do Projeto
O projeto é dividido em três camadas principais:

- **Dima.Core** → Biblioteca de classes com regras de negócio e modelos.
- **Dima.Api** → API REST construída em ASP.NET Core para exposição dos serviços.
- **Dima.Web** → Aplicação **Blazor WebAssembly** para interface do usuário.

---

## ⚙️ Tecnologias Utilizadas
- **.NET 10**
- **ASP.NET Core**
- **Blazor WebAssembly**
- **Entity Framework Core**
- **SQL Server**
- **Stripe API** (pagamentos e vendas de cursos)
- **Git** (versionamento)

---

## 📂 Banco de Dados
- Banco: **SQL Server**
- ORM: **Entity Framework Core**
- Migrações podem ser aplicadas com:
  ```bash
  dotnet ef database update
