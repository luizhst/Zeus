function CadastrarPerfil(){

	var txt_des_nome = document.getElementById("txt_des_nome").value;
	var result = document.getElementById("result");
    var xmlreq = CriaRequest();

	txt_des_nome = txt_des_nome.replace("'", "");	

	 xmlreq.open("GET", "function/CRUD_TB_Perfil.php?txt_des_nome=" + txt_des_nome + "&acao=0", true);

	result.innerHTML = '<img src="../plugins/images/gif/Progresso_Login.gif" height="40px" width="40px" />';
	
			 // Atribui uma função para ser executada sempre que houver uma mudança de ado
			 xmlreq.onreadystatechange = function(){
				  
					 // Verifica se foi concluído com sucesso e a conexão fechada (readyState=4)
					 if (xmlreq.readyState == 4) {
						 
						 // Verifica se o arquivo foi encontrado com sucesso
						 if (xmlreq.status == 200) {
							 
							 result2 = unescape(xmlreq.responseText);
							 
							 if (xmlreq.responseText == "1" || xmlreq.responseText == 1) {

								SelectPerfil();
								result.innerHTML = "<b>Perfil Cadastrado</b>";
								document.getElementById('txt_des_nome').value='';

							 }else if(xmlreq.responseText == "0" || xmlreq.responseText == 0){

								result.innerHTML = "<font color='#A52A2A'><b><center>Houve um erro ao cadastrar.</center></b></font>";

							 }else if(xmlreq.responseText == "3" || xmlreq.responseText == 3){

								result.innerHTML = "<font color='#A52A2A'><b>Nome inválido, por favor tente novamente.</b></font>";

							 }else{

								result.innerHTML = "<font color='#A52A2A'><b><center>Já existe um perfil cadastrado com esse nome.</center></b></font>";
								 
							 }							 
							 
						 }else{
							 result.innerHTML = "Erro: " + xmlreq.statusText;
						 }
					 }
				 };
				 
	xmlreq.send(null);


}

function SelectPerfil(paginaSelecionada){

var result = document.getElementById("tabela_perfis");
var result_combo = document.getElementById("SelectCombo");
var retorno;
var tabela = "";
var combo = "";
var cont = 0;
var xmlreq = CriaRequest();

xmlreq.open("GET", "function/CRUD_TB_Perfil.php?acao=1", true);

//result_combo.innerHTML = '<center><img src="../plugins/images/gif/Progresso_2.gif" height="40px" width="40px" /></center>';

// Atribui uma função para ser executada sempre que houver uma mudança de ado
	xmlreq.onreadystatechange = function(){
	
	// Verifica se foi concluído com sucesso e a conexão fechada (readyState=4)
		if (xmlreq.readyState == 4) {

		// Verifica se o arquivo foi encontrado com sucesso
			if (xmlreq.status == 200) {

			//result2 = unescape(xmlreq.responseText);

			retorno = xmlreq.responseText;

			for (i = 0; i < retorno.length; i++) {

				if (cont == 1) {
												
								combo = combo + retorno.substr(i, 1);
								
					}
				else{
												
						if (retorno.substr(i, 5) != "!end!") {

							tabela = tabela + retorno.substr(i, 1);
						
						
						}else{

							i = i + 4;
							cont = 1;				

						}

				}

			}

			if(paginaSelecionada == 0){

				result.innerHTML = tabela;

			}else if(paginaSelecionada == 1){

				result_combo.innerHTML = combo;

			}	


			}else{
			result.innerHTML = "Erro: " + xmlreq.statusText;
			}
		}
	};
xmlreq.send(null);

}