# Sistema de Alocação de Espaços Acadêmicos (SAEA)

![Status do Projeto](https://img.shields.io/badge/status-em%20desenvolvimento-yellow)

---

## 📖 Sobre o Projeto

O **SAEA** é um sistema web projetado para otimizar e modernizar a gestão e reserva de espaços de estudo em ambientes universitários. Através de uma planta baixa interativa, os usuários podem visualizar a disponibilidade de mesas e salas em tempo real, realizando reservas de forma simples e intuitiva.

Este projeto está sendo desenvolvido como Trabalho de Conclusão de Curso (TCC), com o piloto inicial focado na planta da Biblioteca Central da universidade. A arquitetura foi pensada para ser escalável, permitindo a fácil integração de outros edifícios e pavilhões no futuro.

---

## ✨ Funcionalidades Principais

* **Visualização Interativa:** Navegue pela planta baixa do ambiente com funcionalidades de zoom e pan (arrastar).
* **Destaque Visual:** Espaços reserváveis são destacados visualmente e reagem à interação do usuário.
* **Consulta de Disponibilidade:** Filtre os espaços disponíveis por data e intervalo de horário.
* **Reserva Simplificada:** Realize a reserva de um espaço através de uma caixa de diálogo de confirmação intuitiva.
* **Arquitetura Containerizada:** O ambiente de desenvolvimento e produção é totalmente gerenciado com Docker, garantindo consistência e facilidade de configuração.

---

## 🛠️ Tecnologias Utilizadas

A aplicação é dividida em duas partes principais:

| Camada             | Tecnologia  | Descrição                                                     |
| :----------------- | :---------- | :------------------------------------------------------------ |
| **Frontend**       | **Angular** | Framework para a construção da interface reativa.             |
| **Backend**        | **.NET**    | Plataforma para a construção da API REST e lógica de negócio. |
| **Banco de Dados** | **MySQL**   | Sistema de gerenciamento para persistência dos dados.         |
| **Ambiente**       | **Docker**  | Plataforma de containerização para todo o ambiente.           |

---

## 📂 Estrutura do Repositório

O projeto está organizado na seguinte estrutura de pastas:

```
.
├── 📁 backend/         # Contém a aplicação .NET Web API
├── 📁 docs/            # Documentação do projeto
├── 📁 frontend/        # Contém a aplicação Angular
├── 📁 scripts/         # Scripts para processamento
├── 🐳 .dockerignore
├── 🐳 docker-compose.yml
└── 📖 README.md
```

---

## ✍️ Autor

**David dos Santos Machado**

* **Email:** `david_machado@ufrrj.br`
* **LinkedIn:** `https://linkedin.com/in/odavidmachado`
