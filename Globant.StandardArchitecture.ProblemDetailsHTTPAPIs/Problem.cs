namespace Globant.Project.StandardArchitecture.ProblemDetailsHTTPAPIs
{
    public class Problem
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public int Status { get; set; }
        public List<string> Details { get; set; }
        public string Instance { get; set; }
        public string RequestID { get; set; }

        /*
         {
          "type": "https://example.com/probs/invalid-data",
          "title": "Invalid data",
          "status": 400,
          "detail": "O CPF fornecido já está cadastrado.",
          "instance": "/users"
        }


            Códigos de Status HTTP:
            2xx (Sucesso): Indica que a requisição foi processada com sucesso.
            200 OK: Requisição bem-sucedida.
            201 Created: Recurso criado com sucesso.
            4xx (Erros do Cliente): Indica que houve um erro por parte do cliente.
            400 Bad Request: A requisição é inválida ou malformada.
            401 Unauthorized: Falta de autenticação ou credenciais inválidas.
            403 Forbidden: O cliente não tem permissão para acessar o recurso.
            404 Not Found: O recurso solicitado não foi encontrado.
            422 Unprocessable Entity: A requisição foi bem formada, mas não pode ser processada (por exemplo, erro de validação).
            5xx (Erros do Servidor): Indica erros internos no servidor.
            500 Internal Server Error: Erro genérico no servidor.
            502 Bad Gateway: O servidor agiu como um gateway e recebeu uma resposta inválida de um servidor upstream.


         */
    }
}
