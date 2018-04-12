function CadastrarArea(){

	var txtNomeArea = document.getElementById("txtNomeArea").value;
	var result = document.getElementById("result");
    var xmlreq = CriaRequest();

	txtNomeArea = txtNomeArea.replace("'", "");	

	 xmlreq.open("GET", "function/CRUD_TB_Area.php?txtNomeArea=" + txtNomeArea + "&acao=0", true);

	result.innerHTML = '<img src="../plugins/images/gif/Progresso_Login.gif" height="40px" width="40px" />';
	
			 // Atribui uma função para ser executada sempre que houver uma mudança de ado
			 xmlreq.onreadystatechange = function(){
				  
					 // Verifica se foi concluído com sucesso e a conexão fechada (readyState=4)
					 if (xmlreq.readyState == 4) {
						 
						 // Verifica se o arquivo foi encontrado com sucesso
						 if (xmlreq.status == 200) {
							 
							 result2 = unescape(xmlreq.responseText);
							 
							 if (xmlreq.responseText == "1" || xmlreq.responseText == 1) {

									 SelectArea();
									result.innerHTML = "<b>Área Cadastrada</b>";								
									document.getElementById('txtNomeArea').value='';
									

							 }else if(xmlreq.responseText == "0" || xmlreq.responseText == 0){

								result.innerHTML = "<font color='#A52A2A'><b>Houve um erro ao cadastrar.</b></font>";

							 }else if(xmlreq.responseText == "3" || xmlreq.responseText == 3){

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


function SelectArea(){

	var result = document.getElementById("tabela_area");
	var result_combo = document.getElementById("combo");
	var retorno;
	var tabela = "";
	var combo = "";
	var cont = 0;
    var xmlreq = CriaRequest();

	 xmlreq.open("GET", "function/CRUD_TB_Area.php?acao=1", true);

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

							result.innerHTML = tabela;
							result_combo.innerHTML = combo;

							 
						 }else{
							 result.innerHTML = "Erro: " + xmlreq.statusText;
						 }
					 }
				 };
				 
	xmlreq.send(null);


}