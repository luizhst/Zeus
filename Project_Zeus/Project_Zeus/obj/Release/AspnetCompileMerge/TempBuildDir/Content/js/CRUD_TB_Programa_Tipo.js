function CadastrarTipoPrograma(){

	var txt_des_nome = document.getElementById("txt_des_nome").value;
	var result = document.getElementById("result");
    var xmlreq = CriaRequest();

	txt_des_nome = txt_des_nome.replace("'", "");	

	 xmlreq.open("GET", "function/CRUD_TB_Programa_Tipo.php?txt_des_nome=" + txt_des_nome + "&acao=0", true);

	result.innerHTML = '<img src="../plugins/images/gif/Progresso_Login.gif" height="40px" width="40px" />';
	
			 // Atribui uma função para ser executada sempre que houver uma mudança de ado
			 xmlreq.onreadystatechange = function(){
				  
					 // Verifica se foi concluído com sucesso e a conexão fechada (readyState=4)
					 if (xmlreq.readyState == 4) {
						 
						 // Verifica se o arquivo foi encontrado com sucesso
						 if (xmlreq.status == 200) {
							 
							 result2 = unescape(xmlreq.responseText);
							 
							 if (xmlreq.responseText == "1" || xmlreq.responseText == 1) {

									SelectTipoPrograma();
									result.innerHTML = "<b>Tipo Cadastrado</b>";
									document.getElementById('txt_des_nome').value='';	
																
									

							 }else if(xmlreq.responseText == "0" || xmlreq.responseText == 0){

								result.innerHTML = "<font color='#A52A2A'><b><center>Houve um erro ao cadastrar.</center></b></font>";

							 }else if(xmlreq.responseText == "3" || xmlreq.responseText == 3){

								result.innerHTML = "<font color='#A52A2A'><b>Nome inválido, por favor tente novamente.</b></font>";

							 }else{

								result.innerHTML = "<font color='#A52A2A'><b><center>Já existe um tipo de programa cadastrado com esse nome.</center></b></font>";
								 
							 }							 
							 
						 }else{
							 result.innerHTML = "Erro: " + xmlreq.statusText;
						 }
					 }
				 };
				 
	xmlreq.send(null);


}

function SelectTipoPrograma(){

var result = document.getElementById("tabela_tipo_programa");
var retorno;
var tabela = "";
var cont = 0;
var xmlreq = CriaRequest();

xmlreq.open("GET", "function/CRUD_TB_Programa_Tipo.php?acao=1", true);

//result.innerHTML = '<center><img src="../plugins/images/gif/Progresso_2.gif" height="40px" width="40px" /></center>';

// Atribui uma função para ser executada sempre que houver uma mudança de ado
	xmlreq.onreadystatechange = function(){
	
	// Verifica se foi concluído com sucesso e a conexão fechada (readyState=4)
		if (xmlreq.readyState == 4) {

		// Verifica se o arquivo foi encontrado com sucesso
			if (xmlreq.status == 200) {

			//result2 = unescape(xmlreq.responseText);

			result.innerHTML = xmlreq.responseText;


			}else{
			result.innerHTML = "Erro: " + xmlreq.statusText;
			}
		}
	};
xmlreq.send(null);

}