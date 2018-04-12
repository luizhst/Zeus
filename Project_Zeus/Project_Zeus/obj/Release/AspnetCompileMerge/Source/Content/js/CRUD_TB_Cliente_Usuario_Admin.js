function CadastrarClienteUsuarioAdmin(){

	var txt_Nome = document.getElementById("txt_Nome").value;
    var txt_NomeCompleto = document.getElementById("txt_NomeCompleto").value;
    var txt_Login = document.getElementById("txt_Login").value;
    var validacao = document.getElementById("validacao").innerHTML;
    var txt_Senha = document.getElementById("txt_Senha").value;
    var txt_Dta_Cadastro = document.getElementById("txt_Dta_Cadastro").value;
    var comboSituacao = document.getElementById("comboSituacao").value;
    var comboPerfil = document.getElementById("comboPerfil").value;
	var result = document.getElementById("result");
    var xmlreq = CriaRequest();
    var rdbAtivo = document.getElementById("rdbAtivo").value;

	txt_Nome = txt_Nome.replace("'", "");
    txt_NomeCompleto = txt_NomeCompleto.replace("'", "");
    txt_Login = txt_Login.replace("'", "");	

    txt_Nome = txt_Nome.trim();
    txt_NomeCompleto = txt_NomeCompleto.trim();
    txt_Login = txt_Login.trim();	

    validacao = validacao.replace(/[\\"]/g, '');

    if (comboPerfil != "0") {

        if(txt_Nome != "" &&  txt_NomeCompleto != "" && txt_Login != ""){

            if(validacao == "<font color=#006400><b>Login válido!</b></font>"){
    
                xmlreq.open("GET", "function/CRUD_TB_Cliente_Usuario_Admin.php?txt_Nome=" + txt_Nome
                                                                + "&txt_NomeCompleto=" + txt_NomeCompleto
                                                                + "&txt_Login=" + txt_Login
                                                                + "&txt_Senha=" + txt_Senha
                                                                + "&txt_Dta_Cadastro=" + txt_Dta_Cadastro
                                                                + "&comboSituacao=" + comboSituacao
                                                                + "&Ativo=" + rdbAtivo
                                                                + "&comboPerfil=" + comboPerfil
                                                                + "&acao=0", true);      

                result.innerHTML = '<img src="../plugins/images/gif/Progresso_Login.gif" height="40px" width="40px" />';
                
                        // Atribui uma função para ser executada sempre que houver uma mudança de ado
                        xmlreq.onreadystatechange = function(){
                            
                                // Verifica se foi concluído com sucesso e a conexão fechada (readyState=4)
                                if (xmlreq.readyState == 4) {
                                    
                                    // Verifica se o arquivo foi encontrado com sucesso
                                    if (xmlreq.status == 200) {
                                        
                                        result2 = unescape(xmlreq.responseText);
                                        
                                        if (xmlreq.responseText == "1" || xmlreq.responseText == 1) {

                                                limpa_formulario_form_usuario();
                                                SelectUsuarioAdmin();
                                                result.innerHTML = "<b>Usuário Cadastrado!</b>";	
                                                

                                        }else if(xmlreq.responseText == "0" || xmlreq.responseText == 0){

                                            result.innerHTML = "<font color='#A52A2A'><b>Houve um erro ao cadastrar.</b></font>";

                                        }
                                        //else{

                                    //     result.innerHTML = xmlreq.responseText;

                                    //   }				 
                                        
                                    }else{
                                        result.innerHTML = "Erro: " + xmlreq.statusText;
                                    }
                                }
                            };
                            
                xmlreq.send(null);

            }else{

                result.innerHTML = "<font color='#A52A2A'><b>Forneça um login de usuário válido para continuar!</b></font>";

            }                     

        }else{

            result.innerHTML = "<font color='#A52A2A'><b>Atenção: Preencha os dados corretamente!</b></font>";

        }

    }else{

        result.innerHTML = "<font color='#A52A2A'><b>Selecione um perfil</b></font>";

    } 

}

function SelectUsuarioAdmin(){

	var result = document.getElementById("tabela_usuarios");
	var retorno;
	var tabela = "";
	var combo = "";
	var cont = 0;
    var xmlreq = CriaRequest();

	 xmlreq.open("GET", "function/CRUD_TB_Cliente_Usuario_Admin.php?acao=1", true);

	//result.innerHTML = '<center><img src="../plugins/images/gif/Progresso_2.gif" height="40px" width="40px" /></center>';
	
			 // Atribui uma função para ser executada sempre que houver uma mudança de ado
			 xmlreq.onreadystatechange = function(){
				  
					 // Verifica se foi concluído com sucesso e a conexão fechada (readyState=4)
					 if (xmlreq.readyState == 4) {
						 
						 // Verifica se o arquivo foi encontrado com sucesso
						 if (xmlreq.status == 200) {
							 
							//result2 = unescape(xmlreq.responseText);

							retorno = xmlreq.responseText;

							result.innerHTML = retorno;

							 
						 }else{
							 result.innerHTML = "Erro: " + xmlreq.statusText;
						 }
					 }
				 };
				 
	xmlreq.send(null);


}

function limpa_formulario_form_usuario(){

    document.getElementById("txt_Nome").value = "";
    document.getElementById("txt_NomeCompleto").value = "";
    document.getElementById("txt_Login").value = "";
    document.getElementById("validacao").innerHTML = "";
    document.getElementById("txt_Senha").value;
    document.getElementById("txt_Dta_Cadastro").value = "";
    document.getElementById("comboSituacao").value = "0";
    document.getElementById("rdbAtivo").value = "1";
    document.getElementById("comboPerfil").value = "0";

}