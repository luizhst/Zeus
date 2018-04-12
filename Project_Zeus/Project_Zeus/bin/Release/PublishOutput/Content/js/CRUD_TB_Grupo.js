function CadastrarGrupo(){

	var txtNomeGrupo = document.getElementById("txtNomeGrupo").value;
	var ComboArea = document.getElementById("ComboArea").value;
	var result = document.getElementById("result2");
    var xmlreq = CriaRequest();

	txtNomeGrupo = txtNomeGrupo.replace("'", "");

	  xmlreq.open("GET", "function/CRUD_TB_Grupo.php?txtNomeGrupo=" + txtNomeGrupo
													+ "&ComboArea=" + ComboArea
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
								 
								 	SelectGrupo();
									result.innerHTML = "<b>Grupo Cadastrado</b>";								
									document.getElementById('txtNomeGrupo').value='';
								  	document.getElementById('ComboArea').value='0';

							 }else if(xmlreq.responseText == "0" || xmlreq.responseText == 0){

								result.innerHTML = "<font color='#A52A2A'><b>Houve um erro ao cadastrar.</b></font>";

							 }else if(xmlreq.responseText == "3" || xmlreq.responseText == 3){

								result.innerHTML = "<font color='#A52A2A'><b>Selecione uma área para continuar.</b></font>";

							 }else if(xmlreq.responseText == "4" || xmlreq.responseText == 4){

								result.innerHTML = "<font color='#A52A2A'><b>Nome inválido, por favor tente novamente.</b></font>";

							 }					 
							 else{

								result.innerHTML = "<font color='#A52A2A'><b>Já existe uma área cadastrada com este nome</b></font>";
								 
							 }							 
							 
						 }else{
							 result.innerHTML = "Erro: " + xmlreq.statusText;
						 }
					 }
				 };
				 
	xmlreq.send(null);

}

function SelectGrupo(){

	var result = document.getElementById("table_grupo");
	var retorno;
	var tabela = "";
	var combo = "";
	var cont = 0;
    var xmlreq = CriaRequest();

	 xmlreq.open("GET", "function/CRUD_TB_Grupo.php?acao=1", true);

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

function SelectGrupoFiltro(area){
	
	var result = document.getElementById("FiltroGrupo");
    var xmlreq = CriaRequest();

	
	 xmlreq.open("GET", "function/CRUD_TB_Grupo.php?acao=2&area="+area, true);

	result.innerHTML = '<img src="../plugins/images/gif/Progresso_Login.gif" height="40px" width="40px" />';
	
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
