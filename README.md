# Cedro Restaurante BackEnd

Este projeto foi desenvolvido como forma de avaliação para o processo seletivo da [Cedro](https://www.cedrotech.com "Cedro"). 
O projeto consiste em um básico sistema para gerênciar cadastro de restaurantes e os seus respectivos pratos.

## BackEnd
O BackEnd foi desenvolvido em C# Utilizando o .NET Core 2.1 em conjunto com o Entity Framework.

Este BackEnd é uma API RestFul para o projeto desenvolvido em Angular ( [https://github.com/higorcavalcanti/cedro-restaurant-front-end](https://github.com/higorcavalcanti/cedro-restaurant-front-end)).

O sistema conta com as seguintes rotas:

#### Restaurantes:
- GET /restaurants - Obtém a lista de restaurantes cadastros;
- GET /restaurants/:id - Obtém as informações do restaurante de ID informado;
- POST /restaurants - Cadastra um novo restaurante;
- PUT /restaurants/:id - Editar o restaurante de ID informado;
- DELETE /restaurants/:id - Remove o restaurante informado.

#### Pratos
- GET /dishes - Obtém a lista de todos pratos cadastrados e o restaurante pertencente;
- GET /dishes/:id - Obtém as informações do prato informado;
- POST /dishes - Cadastra um novo prato no sistema;
- PUT /dishes/:id - Edita as informações do prato informado
- DELETE /dishes/:id - Remove o prato informado.
