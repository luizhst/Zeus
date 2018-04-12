function InserirPrograma(){

	var txtNomePrograma = document.getElementById("txtNomePrograma").value;
	var txtNomeExecutavel = document.getElementById("txtNomeExecutavel").value;
	var idTipo = document.getElementById("comboGrupo").value;
	var idArea = document.getElementById("comboArea").value;
	var idGrupo = document.getElementById("SelectComboGrupo").value;
	var idCategoria = document.getElementById("comboCategoria").value;

	var result = document.getElementById("result");
	var xmlreq = CriaRequest();
	
	txtNomePrograma = txtNomePrograma.replace("'", "");//Tira as áspas do nome do grupo
	//txtNomePrograma = txtNomePrograma.replace("  ", "");
	
	 xmlreq.open("GET", "function/CRUD_TB_Programa_Lista.php?txtNomeExecutavel=" + txtNomeExecutavel 
																					+ "&txtNomePrograma="+ txtNomePrograma 
																					+ "&idTipo="+ idTipo 
																					+ "&idArea="+ idArea
																					+ "&idGrupo="+ idGrupo
																					+ "&idCategoria="+ idCategoria
																					+"&acao=0", true);

																				

	result.innerHTML = '<img src="../plugins/images/gif/Progresso_Login.gif" height="40px" width="40px" />';
	
			 // Atribui uma função para ser executada sempre que houver uma mudança de ado
			 xmlreq.onreadystatechange = function(){
				  
					 // Verifica se foi concluído com sucesso e a conexão fechada (readyState=4)
					 if (xmlreq.readyState == 4) {
						 
						 // Verifica se o arquivo foi encontrado com sucesso
						 if (xmlreq.status == 200) {
							 
							 result2 = unescape(xmlreq.responseText);
							 
							 if (xmlreq.responseText == "1" || xmlreq.responseText == 1) {

									SelectPrograma();
									result.innerHTML = "<b>Executável Categorizado</b>";								
									document.getElementById("txtNomePrograma").value='';
									document.getElementById("txtNomeExecutavel").value='';
									document.getElementById("comboGrupo").value = 0;
									document.getElementById("comboArea").value = 0;
									document.getElementById("SelectComboGrupo").value = 0;
									document.getElementById("comboCategoria").value = 0;
									

							 }else if(xmlreq.responseText == "0" || xmlreq.responseText == 0){

								result.innerHTML = "<font color='#A52A2A'><b>Houve um erro ao cadastrar.</b></font>";

							 }else if(xmlreq.responseText == "3" || xmlreq.responseText == 3){

								result.innerHTML = "<font color='#A52A2A'><b>Nome inválido, por favor tente novamente.</b></font>";

							 }else if(xmlreq.responseText == "4" || xmlreq.responseText == 4){
								
								result.innerHTML = "<font color='#A52A2A'><b>Combo inválido, por favor tente novamente.</b></font>";
								
							}else{

								result.innerHTML = "<font color='#A52A2A'><b>Já existe uma área cadastrada com este nome</b></font>";
								 
							 }							 
							 
						 }else{
							 result.innerHTML = "Erro: " + xmlreq.statusText;
						 }
					 }
				 };
				 
	xmlreq.send(null);


}


function InserirProgramaNaoCategorizado(){
	
		
		var txtNomeExecutavel = event.srcElement.innerText;
	
		var result = document.getElementById("NaoCategorizado");
		var xmlreq = CriaRequest();

		echo("Passou".txtNomeExecutavel);
		
		txtNomePrograma = txtNomePrograma.replace("'", "");//Tira as áspas do nome do grupo
		//txtNomePrograma = txtNomePrograma.replace("  ", "");
		
		 xmlreq.open("GET", "function/CRUD_TB_Programa_Lista.php?txtNomeExecutavel=" + txtNomeExecutavel 
																						+"&acao=2", true);
																						
	
		result.innerHTML = '<img src="../plugins/images/gif/Progresso_Login.gif" height="40px" width="40px" />';
		
				 // Atribui uma função para ser executada sempre que houver uma mudança de ado
				 xmlreq.onreadystatechange = function(){
					  
						 // Verifica se foi concluído com sucesso e a conexão fechada (readyState=4)
						 if (xmlreq.readyState == 4) {
							 
							 // Verifica se o arquivo foi encontrado com sucesso
							 if (xmlreq.status == 200) {
								 
								 result2 = unescape(xmlreq.responseText);
								 
								 if (xmlreq.responseText == "1" || xmlreq.responseText == 1) {
	
										SelectPrograma();
										result.innerHTML = "<b>Executável Categorizado</b>";								
									
								 }else if(xmlreq.responseText == "0" || xmlreq.responseText == 0){
	
									result.innerHTML = "<font color='#A52A2A'><b>Houve um erro ao cadastrar.</b></font>";
	
								 }else if(xmlreq.responseText == "3" || xmlreq.responseText == 3){
	
									result.innerHTML = "<font color='#A52A2A'><b>Nome inválido, por favor tente novamente.</b></font>";
	
								 }else if(xmlreq.responseText == "4" || xmlreq.responseText == 4){
									
									result.innerHTML = "<font color='#A52A2A'><b>Combo inválido, por favor tente novamente.</b></font>";
									
								}else{
	
									result.innerHTML = "<font color='#A52A2A'><b>Já existe uma área cadastrada com este nome</b></font>";
									 
								 }							 
								 
							 }else{
								 result.innerHTML = "Erro: " + xmlreq.statusText;
							 }
						 }
					 };
					 
		xmlreq.send(null);
	
	
	}


function SelectPrograma(){

	var result = document.getElementById("tabela_programas");
	var result_combo = document.getElementById("comboGrupo");
	var result_categorizados =  document.getElementById("tabela_programas_categorizados");
	var result_itens =  document.getElementById("total_itens");
	var retorno;
	var tabela = "";
	var combo = "";
	var tabela2 = "";
	var texto = "";
	var cont = 0;
    var xmlreq = CriaRequest();

	 xmlreq.open("GET", "function/CRUD_TB_Programa_Lista.php?acao=1", true);

	//result.innerHTML = '<center><img src="../plugins/images/gif/Progresso_2.gif" height="40px" width="40px" /></center>';
	
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
									
									
									if (retorno.substr(i, 6) != "!end2!") {

										combo = combo + retorno.substr(i, 1);

									}else {

										i = i + 5;
										cont = 2;

									}
								}
								else if (cont == 2){

									if (retorno.substr(i, 6) != "!end3!") {
										
										tabela2 = tabela2 + retorno.substr(i, 1);

									}else {

										i = i + 5;
										cont = 3;

									}

								}
								else if (cont == 3){

									texto = texto + retorno.substr(i, 1);

								}
								else {
																
										if (retorno.substr(i, 5) != "!end!") {

											tabela = tabela + retorno.substr(i, 1);

										}else{

											i = i + 4;
											cont = 1;
										

										}

								}

							}

							//result_itens.innerHTML = texto;
							result.innerHTML = tabela;
							result_combo.innerHTML = combo;
							result_categorizados.innerHTML = tabela2;
							
							 
						 }else{
							 result.innerHTML = "Erro: " + xmlreq.statusText;
						 }
					 }
				 };
				 
	xmlreq.send(null);


}

function PreencheCampo(){
    $("#txtNomeExecutavel").val("");
	document.getElementById('txtNomeExecutavel').value += event.srcElement.innerText;
}