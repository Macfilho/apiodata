# apiodata
Consumindo API odata com C#
aqui estao apenas os C# criados relevantes mas é necessario preparar o projeto com migrations e entityframework.
 fiz o teste o fonte esta feito em c# (incluso todas os recursos para usar API Odata) 
poderao baixar o projeto no link: https://drive.google.com/file/d/1OkqJX2gqRFfTWUir0wA47nwu74zp8fQN/view
Instrucoes
1- Projeto feito e compilado no visual studio 2015 , usando C#
2- Ao compilar a solução ele abrirá o browser e rodará com serviço para consumir api Odata
3- No navegador local poderá usar http://localhost:52208/odata/Pessoas
irá retornar exemplos abaixo inseridos com Postman para testar a API Odata sugerida

{
  "odata.metadata":"http://localhost:52208/odata/$metadata#Pessoas","value":[
    {
      "id":1,"nome":"joao","sobrenome":null,"nomeusuario":null,"endereco":null
    },{
      "id":2,"nome":"henry","sobrenome":"Roy","nomeusuario":"henryRoy","endereco":"Street 1 District 04"
    },{
      "id":3,"nome":"Maria","sobrenome":"luzia","nomeusuario":"marialuzia","endereco":"rua das Marias"
    },{
      "id":4,"nome":"Pedro","sobrenome":"Augusto","nomeusuario":"Pedroaugusto","endereco":"rua canada divina"
    },{
      "id":5,"nome":"henry","sobrenome":"Roy","nomeusuario":"henryRoy","endereco":"Street 1 District 04"
    },{
      "id":6,"nome":"henry","sobrenome":"Roy","nomeusuario":"henryRoy","endereco":"Street 1 District 04"
    },{
      "id":7,"nome":"henry","sobrenome":"Roy","nomeusuario":"henryRoy","endereco":"Street 1 District 04"
    }
  ]
}
4- para inserir, deletar e consultar e melhor usar o postman (www.postman.com)

 e poder fazer operações de get, post, delete
